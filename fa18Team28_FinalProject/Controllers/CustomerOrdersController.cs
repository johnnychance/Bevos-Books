using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;
using fa18Team28_FinalProject.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace fa18Team28_FinalProject.Controllers
{
    [Authorize]
    public class CustomerOrdersController : Controller
    {
        private AppDbContext _context;

        public CustomerOrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public IActionResult Index()
        {
            List<CustomerOrder> CustomerOrders = new List<CustomerOrder>();
            if (User.IsInRole("Customer"))
            {
                CustomerOrders = _context.CustomerOrders.Include(o => o.CustomerOrderDetails).Where(o => o.AppUser.UserName == User.Identity.Name).ToList();
            }
            else
            {
                CustomerOrders = _context.CustomerOrders.Include(o => o.CustomerOrderDetails).ToList();
            }

            return View(CustomerOrders);

        }

        // GET: CustomerOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var customerOrder = await _context.CustomerOrders.Include(o => o.CustomerOrderDetails).ThenInclude(o => o.Book).FirstOrDefaultAsync(m => m.CustomerOrderID == id);

            if (customerOrder == null)
            {
                return NotFound();
            }

            return View(customerOrder);
        }

        // GET: CustomerOrders/Create
        public IActionResult Create()
        {
            /*String strEmails = CustomerOrder.Email;
            String strSubject = "AccountRegistered";
            String strEmailBody = "You are now registered";
            EmailMessaging.SendEmail(strEmails, strSubject, strEmailBody);*/
            return View();
        }

        // POST: CustomerOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerOrderID,CustomerOrderDate,CustomerOrderNotes")] CustomerOrder customerOrder)
        {
            customerOrder.CustomerOrderNumber = GenerateNextOrderNumber.GetNextOrderNumber(_context);
            customerOrder.CustomerOrderDate = System.DateTime.Today;

            //This associates a customer with the order
            string name = User.Identity.Name;
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == name);
            customerOrder.AppUser = user;

            if (ModelState.IsValid)
            {
                _context.Add(customerOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction("AddToOrder", new { id = customerOrder.CustomerOrderID });
            }
            return View(customerOrder);
        }

        //GET: AddToOrder
        public IActionResult AddToOrder(int? id)
        {
            /*if (id == null)
            {
                return View("Error", new string[] { "You must specify an order to add!" });
            }*/

            //Creating a new customer order 
            //Booleans are automatically false

            CustomerOrder cust_ord = new CustomerOrder() { CustomerOrderStatus = false };

            CustomerOrder cod = _context.CustomerOrders.Find(id);
            if (cod == null)
            {
                return View("Error", new string[] { "Order not found!" });
            }

            //Creating a new order detail
            CustomerOrderDetail cd = new CustomerOrderDetail() { CustomerOrder = cod };

            ViewBag.AllCustomerBooks = GetAllCustomerBooks();
            //Change the view to make sure there's no list that requires something to be passed to it
            return View("AddToOrder", cd);
        }

        //POST: AddToOrder
        [HttpPost]
        public IActionResult AddToOrder(CustomerOrderDetail cod, int SelectedBook)
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


        //async warning - removed keyword async
        // GET: CustomerOrders/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string username = User.Identity.Name;



            var customerOrder = _context.CustomerOrders.Where(m => m.AppUser.UserName == username)
                                        .Include(r => r.CustomerOrderDetails)
                                            .ThenInclude(r => r.Book)
                                        .FirstOrDefault(r => r.CustomerOrderID == id);

            if (customerOrder == null)
            {
                return View("Error", new string[] { "Not authorized to edit this order!" });
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

        //async warning - removed keyword async
        // POST: CustomerOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CustomerOrderID,CustomerOrderDate,CustomerOrderNotes")] CustomerOrder customerOrder)
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


        //POST: Add a book to the shopping cart
        public async Task<IActionResult> ShoppingCart(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerOrder = await _context.CustomerOrders.Include(o => o.CustomerOrderDetails).ThenInclude(o => o.Book).FirstOrDefaultAsync(m => m.CustomerOrderID == id);

            if (customerOrder == null)
            {
                return NotFound();
            }

            return View(customerOrder);
        }

        //GET
        public async Task<IActionResult> AddToCart(int id)
        {
            List<CustomerOrder> myOrders = new List<CustomerOrder>();
            //logged in
            if (User.Identity.IsAuthenticated)
            {
                myOrders = _context.CustomerOrders.Where(r => r.CustomerOrderStatus == false).Where(r => r.AppUser.UserName == User.Identity.Name).ToList();

                if (myOrders.Count() > 1)
                {
                    return View("Error", new string[] { "You have more than one pending order open! Please delete excessive pending orders!" });
                }
                else if (myOrders.Count() == 0)
                {
                    CustomerOrder customerOrder = new CustomerOrder();
                    customerOrder.CustomerOrderNumber = GenerateNextOrderNumber.GetNextOrderNumber(_context);
                    customerOrder.CustomerOrderDate = System.DateTime.Today;

                    //This associates a customer with the order
                    string name = User.Identity.Name;
                    AppUser user = _context.Users.FirstOrDefault(u => u.UserName == name);
                    customerOrder.AppUser = user;
                    CustomerOrderDetail cd = new CustomerOrderDetail() { CustomerOrder = customerOrder };

                    if (ModelState.IsValid)
                    {
                        _context.Add(customerOrder);
                        await _context.SaveChangesAsync();
                        ViewBag.AllBooks = GetAllBooks(id);
                        return RedirectToAction("AddToCart", new { id = cd.CustomerOrderDetailID });
                    }

                    Book book = _context.Books.Find(id);

                    if (book == null)
                    {
                        return View("Error", new string[] { "Book not found!" });
                    }

                    ViewBag.AllBooks = GetAllBooks(id);

                    return View("AddToCart", cd);
                }
                else
                {

                    var query = _context.CustomerOrders.Include(o => o.CustomerOrderDetails).Where(o => o.AppUser.UserName == User.Identity.Name).ToList();
                    foreach (CustomerOrder ord in query)
                    {
                        CustomerOrder myOrder = _context.CustomerOrders.Find(ord.CustomerOrderID);
                        CustomerOrderDetail cod = new CustomerOrderDetail() { CustomerOrder = myOrder };

                        if (ModelState.IsValid)
                        {
                            _context.Add(myOrder);
                            await _context.SaveChangesAsync();
                            ViewBag.AllBooks = GetAllBooks(id);
                            return RedirectToAction("AddToCart", new { id = cod.CustomerOrderDetailID });
                        }
                    }
                                

                    ViewBag.AllBooks = GetAllBooks(id);
                    return View("AddToCart");
                }
            }
            //not logged in
            else
            {
                return RedirectToAction("Index", "Search");
            }
        }

        public SelectList GetAllBooks(int id)
        {
            List<Book> SelectedBooks = new List<Book>();

            SelectedBooks = _context.Books.Where(o => o.BookID == id).ToList();
            
            //add a record for all books
            Book SelectNone = new Book() { BookID = 0, Title = "All Books" };
            SelectedBooks.Add(SelectNone);

            //convert list to select list
            SelectList AllBooks = new SelectList(SelectedBooks.OrderBy(m => m.BookID), "BookID", "Name");

            //return the select list
            return AllBooks;
        }
        /*
        //BREAK POINT
        public IActionResult Checkout(int id, CustomerOrder order)
        {

            CustomerOrder customerOrder = _context.CustomerOrders.Find(order.CustomerOrderID);

            if (order.CustomerOrderStatus == false)
            {
                customerOrder.CustomerOrderStatus = true;
            }

            //Update the database
            _context.CustomerOrders.Update(customerOrder);

            //Save changes
            _context.SaveChanges();

            return RedirectToAction("OrderConfirmed");
        }

        //GET: Order Confirmed page
        public IActionResult OrderConfirmed()
        {
            return View();
        }*/

        [HttpPost]
        public IActionResult AddToCart(CustomerOrderDetail cod, int SelectedBook)
        {
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

            //returns a redirect view to the index showing the list of filtered books
            return View("ShoppingCart", cod);

        }
    }
}