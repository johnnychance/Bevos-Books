using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using fa18Team28_FinalProject.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fa18Team28_FinalProject.Models;


namespace fa18Team28_FinalProject.Models
{
    public partial class ShoppingCart
    {
        private readonly AppDbContext _db;

        public ShoppingCart(AppDbContext db)
        {
            _db = db;
        }
        public ShoppingCart()
        {

        }
        string ShoppingCartID { get; set; }
        public const string CartSessionKey = "CartId";
        public static ShoppingCart GetCart()
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartID = cart.GetCartID();
            return cart;
        }
        // Helper method to simplify shopping cart calls
        /*public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }*/

        public void AddToCart(Book book)
        {
            // Get the matching cart and book instances
            var cartItem = _db.CartItems.SingleOrDefault(
                c => c.CartID == ShoppingCartID
                && c.BookId == book.BookID);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new CartItem
                {
                    BookId = book.BookID,
                    CartID = ShoppingCartID,
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };
                _db.CartItems.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                cartItem.Quantity++;
            }
            // Save changes
            _db.SaveChanges();
        }
        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = _db.CartItems.Single(
                cart => cart.CartID == ShoppingCartID
                && cart.ItemID == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    itemCount = cartItem.Quantity;
                }
                else
                {
                    _db.CartItems.Remove(cartItem);
                }
                // Save changes
                _db.SaveChanges();
            }
            return itemCount;
        }
        public void EmptyCart()
        {
            var cartItems = _db.CartItems.Where(
                cart => cart.CartID == ShoppingCartID);

            foreach (var cartItem in cartItems)
            {
                _db.CartItems.Remove(cartItem);
            }
            // Save changes
            _db.SaveChanges();
        }
        public List<CartItem> GetCartItems()
        {
            return _db.CartItems.Where(
                cart => cart.CartID == ShoppingCartID).ToList();
        }
        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in _db.CartItems
                          where cartItems.CartID == ShoppingCartID
                          select (int?)cartItems.Quantity).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }
        public decimal GetTotal()
        {
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            decimal? total = (from cartItems in _db.CartItems
                              where cartItems.CartID == ShoppingCartID
                              select (int?)cartItems.Quantity *
                              cartItems.Book.Price).Sum();

            return total ?? decimal.Zero;
        }
        public int CreateOrder(CustomerOrder customerOrder)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems)
            {
                /*var newBook = new Book
                {
                    BookID = item.BookId
                };*/

                //customerOrder.CustomerOrderID = ;

                var orderDetail = new CustomerOrderDetail
                {
                    ProductPrice = item.Book.Price,
                    Quantity = item.Quantity
                };
                // Set the order total of the shopping cart
                orderTotal += (item.Quantity * item.Book.Price);

                _db.CustomerOrderDetails.Add(orderDetail);

            }
            // Set the order's total to the orderTotal count
            //customerOrder.CustomerOrderTotal = orderTotal;

            // Save the order
            _db.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return customerOrder.CustomerOrderID;
        }
        // We're using HttpContextBase to allow access to cookies.
        public string GetCartID()
        {
            if (ShoppingCartID == null)
            {
                //a user is logged in, set a cart id to their username
                
                    System.DateTime today = System.DateTime.Today;
                    ShoppingCartID = Convert.ToString(today);
                
            }
            return ShoppingCartID;
        }
        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        /*public void MigrateCart(string userName)
        {
            var shoppingCart = _db.CartItems.Where(
                c => c.CartID == ShoppingCartID);

            foreach (CartItem item in shoppingCart)
            {
                item.CartID = userName;
            }
            storeDB.SaveChanges();
        }*/
    }
}