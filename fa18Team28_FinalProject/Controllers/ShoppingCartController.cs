using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;


namespace fa18Team28_FinalProject.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly AppDbContext _db;

        public ShoppingCartController(AppDbContext db)
        {
            _db = db;
        }

        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart();

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }
        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the book from the database
            var addedBook = _db.Books
                .Single(book => book.BookID == id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart();

            cart.AddToCart(addedBook);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }
        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart();

            // Get the name of the album to display confirmation
            string bookName = _db.CartItems
                .Single(item => item.ItemID == id).Book.Title;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = bookName +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary
        //[ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart();

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}