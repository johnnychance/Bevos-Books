/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;

namespace fa18Team28_FinalProject.Controllers
{
    public class CartItemsController : Controller
    {
        private readonly AppDbContext _context;

        public CartItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CartItems
        public async Task<IActionResult> Index()
        {
            return View(); //View(await _context.CartItems.ToListAsync());
        }

        // GET: CartItems/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(m => m.ItemID == id);
            if (cartItem == null)
            {
                return NotFound();
            }

            //return View(cartItem);
        }

        // GET: CartItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CartItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemID,CartID,Quantity,DateCreated")] CartItem cartItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cartItem);
        }

        // GET: CartItems/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            return View(cartItem);
        }

        // POST: CartItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemID,CartID,Quantity,DateCreated")] CartItem cartItem)
        {
            if (id != cartItem.ItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartItemExists(cartItem.ItemID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cartItem);
        }

        // GET: CartItems/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(m => m.ItemID == id);
            if (cartItem == null)
            {
                return NotFound();
            }

            return View(cartItem);
        }

        // POST: CartItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartItemExists(int id)
        {
            return _context.CartItems.Any(e => e.ItemID == id);
        }

        public string ShoppingCartID { get; set; }

        public const string CartSessionKey = "CartID";

        //int id
        public IActionResult AddToCart([Bind("BookID,PublishedDate,UniqueID,Title,Author,Description,Price,Cost,Reordered,PurchaseCount,CopiesOnHand,LastOrdered")] Book book)
        {
            //Retrieve the product from the database.           
            ShoppingCartID = GetCartID();

            var cartItem = _context.CartItems.SingleOrDefault(
                c => c.CartID == ShoppingCartID
                && c.Book.BookID == book.BookID);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists.                 
                cartItem = new CartItem
                {
                    ItemID = Guid.NewGuid().ToString(),                    
                    CartID = ShoppingCartID,
                    Book = _context.Books.SingleOrDefault(
                   p => p.BookID == book.BookID),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                _context.CartItems.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart,                  
                // then add one to the quantity.                 
                cartItem.Quantity++;
            }
            _context.SaveChanges();

            return View(cartItem);
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }

        public string GetCartID()
        {
            if (ShoppingCartID == null)
            {
                //a user is logged in, set a cart id to their username
                if (User.Identity.IsAuthenticated)
                {
                    ShoppingCartID = User.Identity.Name;
                }
                //give the non-logged in user a GUID id
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartID = Guid.NewGuid();
                    ShoppingCartID = tempCartID.ToString();
                }
            }
            return ShoppingCartID;
        }

        public List<CartItem> GetCartItems()
        {
            ShoppingCartID = GetCartID();

            return _context.CartItems.Where(
                c => c.CartID == ShoppingCartID).ToList();
        }

        //GET: AddToOrder
        public IActionResult AddToCart(int? id)
        {
            if (id == null)
            {
                return View("Error", new string[] { "You must specify an order to add!" });
            }

            //Creating a new customer order 
            //Booleans are automatically false

            CustomerOrderDetail cust_ord = new CustomerOrderDetail() { };

            CustomerOrder cod = _context.CustomerOrders.Find(id);
            if (cod == null)
            {
                return View("Error", new string[] { "Order not found!" });
            }

            //Creating a new order detail
            CustomerOrderDetail cd = new CustomerOrderDetail() { CustomerOrder = cod };

            //ViewBag.AllCustomerBooks = GetAllCustomerBooks();

            //Change the view to make sure there's no list that requires something to be passed to it
            return View("AddToOrder", cd);
        }

        //POST: AddToOrder
        [HttpPost]
        public IActionResult AddToCart(CustomerOrderDetail cod, int SelectedBook)
        {
            //Change it select the book id from details/the list

            //find the product associated with the selected product id
            Book book = _context.Books.Find(SelectedBook);

            //set the order detail's book equal to the book we just found
            cod.Book = book;

            //find the order based on the id and the property is pending
            //Set this status equal to false
            //**False will mean "Pending" and True will mean "Finished"
            CustomerOrder reg = _context.CustomerOrders.Find(cod.CustomerOrder.CustomerOrderID);

            //set the order detail's order equal to the order we just found
            cod.CustomerOrder = reg;

            //set the book price for this detail equal to the current book fee
            cod.ProductPrice = cod.Book.Price;

            //add total fees
            cod.ExtendedPrice = cod.Quantity * cod.ProductPrice;

            if (ModelState.IsValid)
            {
                _context.CustomerOrderDetails.Add(cod);
                _context.SaveChanges();
                return RedirectToAction("Details", new { id = cod.CustomerOrder.CustomerOrderID });
            }
            return View(cod);
        }
    }
}*/


