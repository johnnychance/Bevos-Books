using System;
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
        public async Task<IActionResult> Details(string id)
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
        public async Task<IActionResult> Edit(string id)
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
        public async Task<IActionResult> Edit(string id, [Bind("ItemID,CartID,Quantity,DateCreated")] CartItem cartItem)
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
        public async Task<IActionResult> Delete(string id)
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

        private bool CartItemExists(string id)
        {
            return _context.CartItems.Any(e => e.ItemID == id);
        }

        public string ShoppingCartID { get; set; }

        public const string CartSessionKey = "CartID";

        //GET
        //int id
        //Bind("BookID,PublishedDate,UniqueID,Title,Author,Description,Price,Cost,Reordered,PurchaseCount,CopiesOnHand,LastOrdered")] Book book
        public IActionResult AddToCart(int? id)
        {
            CustomerOrder cod = _context.CustomerOrders.Find(id);
            cod.CustomerOrderStatus = false;
            CustomerOrderDetail cust_ord = new CustomerOrderDetail() { CustomerOrder = cod };

            if (cod == null)
            {
                return View("Error", new string[] { "Order not found!" });
            }
                        
            //ViewBag.AllCustomerBooks = GetAllCustomerBooks();

            //Change the view to make sure there's no list that requires something to be passed to it
            return View("AddToCart", cust_ord);
        }

        //POST: AddToCart
        [HttpPost]
        public IActionResult AddToCart(CustomerOrderDetail cust_ord, int SelectedBook)
        {
            //Change it select the book id from details/the list

            //find the product associated with the selected product id
            Book book = _context.Books.Find(SelectedBook);

            //set the order detail's book equal to the book we just found
            cust_ord.Book = book;

            //find the order based on the id and the property is pending
            //Set this status equal to false
            //**False will mean "Pending" and True will mean "Finished"
            CustomerOrder reg = _context.CustomerOrders.Find(cust_ord.CustomerOrder.CustomerOrderID);

            //set the order detail's order equal to the order we just found
            cust_ord.CustomerOrder = reg;

            //set the book price for this detail equal to the current book fee
            cust_ord.ProductPrice = cust_ord.Book.Price;

            //add total fees
            cust_ord.ExtendedPrice = cust_ord.Quantity * cust_ord.ProductPrice;

            if (ModelState.IsValid)
            {
                _context.CustomerOrderDetails.Add(cust_ord);
                _context.SaveChanges();
                return RedirectToAction("Details", new { id = cust_ord.CustomerOrder.CustomerOrderID });
            }
            return View(cust_ord);
        }
        /*
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
    }*/

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
    }
}
    

