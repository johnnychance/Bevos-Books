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
    public class CustomerOrdersController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerOrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerOrders.Include(o => o.CustomerOrderDetails).ToListAsync());
        }

        // GET: CustomerOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerOrder = await _context.CustomerOrders
                .FirstOrDefaultAsync(m => m.CustomerOrderID == id);
            if (customerOrder == null)
            {
                return NotFound();
            }

            return View(customerOrder);
        }

        // GET: CustomerOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerOrderID,CustomerOrderDate,CustomerOrderNotes")] CustomerOrder customerOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerOrder);
        }

        public IActionResult AddToOrder(int? id)
        {
            if (id == null)
            {
                return View("Error", new string[] { "You must specify an order to add!" });
            }
            CustomerOrder cod = _context.CustomerOrders.Find(id);
            if (cod == null)
            {
                return View("Error", new string[] { "Order not found!" });
            }

            CustomerOrderDetail cd = new CustomerOrderDetail() { CustomerOrder = cod };

            ViewBag.AllCustomerBooks = GetAllCustomerBooks();
            return View("AddToOrder", cd);
        }

        [HttpPost]
        public IActionResult AddToOrder(CustomerOrderDetail cod, int SelectedBook)
        {
            //find the product associated with the selected product id
            Book book = _context.Books.Find(SelectedBook);

            //set the registration detail's course equal to the course we just found
            cod.Book = book;

            //find the registration based on the id
            CustomerOrder reg = _context.CustomerOrders.Find(cod.CustomerOrder.CustomerOrderID);

            //set the registration detail's registration equal to the registration we just found
            cod.CustomerOrder = reg;

            //set the course fee for this detail equal to the current course fee
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


        // GET: CustomerOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerOrder = _context.CustomerOrders
                                        .Include(r => r.CustomerOrderDetails)
                                            .ThenInclude(r => r.Book)
                                        .FirstOrDefault(r => r.CustomerOrderID == id);

            if (customerOrder == null)
            {
                return NotFound();
            }
            return View(customerOrder);

            /*if (id == null)
            {
                return NotFound();
            }

            var customerOrder = await _context.CustomerOrders.FindAsync(id);
            if (customerOrder == null)
            {
                return NotFound();
            }
            return View(customerOrder);*/
        }

        // POST: CustomerOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerOrderID,CustomerOrderDate,CustomerOrderNotes")] CustomerOrder customerOrder)
        {
            //Find the related registration in the database
            CustomerOrder DbCustOrd = _context.CustomerOrders.Find(customerOrder.CustomerOrderID);

            //Update the notes
            DbCustOrd.CustomerOrderNotes = customerOrder.CustomerOrderNotes;

            //Update the database
            _context.CustomerOrders.Update(DbCustOrd);

            //Save changes
            _context.SaveChanges();

            //Go back to index
            return RedirectToAction(nameof(Index));

            /*if (id != customerOrder.CustomerOrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerOrderExists(customerOrder.CustomerOrderID))
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
            return View(customerOrder);*/
        }

        // GET: CustomerOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerOrder = await _context.CustomerOrders
                .FirstOrDefaultAsync(m => m.CustomerOrderID == id);
            if (customerOrder == null)
            {
                return NotFound();
            }

            return View(customerOrder);
        }

        // POST: CustomerOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerOrder = await _context.CustomerOrders.FindAsync(id);
            _context.CustomerOrders.Remove(customerOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerOrderExists(int id)
        {
            return _context.CustomerOrders.Any(e => e.CustomerOrderID == id);
        }

        public IActionResult RemoveFromOrder(int? id)
        {
            if (id == null)
            {
                return View("Error", new string[] { "You need to specify an order id" });
            }

            CustomerOrder orr = _context.CustomerOrders.Include(r => r.CustomerOrderDetails).ThenInclude(r => r.Book).
                FirstOrDefault(r => r.CustomerOrderID == id);

            if (orr == null || orr.CustomerOrderDetails.Count == 0)//registration is not found
            {
                return RedirectToAction("Details", new { id = id });
            }

            //pass the list of order details to the view
            return View(orr.CustomerOrderDetails);
        }

        private SelectList GetAllCustomerBooks()
        {
            List<Book> Books = _context.Books.ToList();
            SelectList allBooks = new SelectList(Books, "BookID", "Title");
            return allBooks;
        }
    }
}
