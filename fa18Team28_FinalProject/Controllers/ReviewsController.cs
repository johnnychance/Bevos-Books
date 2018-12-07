using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;

//Test for github
namespace fa18Team28_FinalProject.Controllers

{
    public class ReviewsController : Controller
    {
        private readonly AppDbContext _context;

        public ReviewsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //Creates a list of reviews to view
            List<Review> Reviews = new List<Review>();

            Reviews = _context.Reviews.Where(r => r.Author.UserName == User.Identity.Name).ToList();

            return View(await _context.Reviews.Include(r => r.Author).ToListAsync());
        }

        //GET: Reveiws/Create
        public IActionResult Create()
        {

            ViewBag.PurchasedBooks = GetAllPurchasedBooks();
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int[] SelectedBook, [Bind("ReviewID, ReviewText, Rating")] Review review)
        {
            //Associates an author to the review
            string cd = User.Identity.Name;
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == cd);
            review.Author = user;

            //If the review created is legit...
            if (ModelState.IsValid)
            {
                foreach (int b in SelectedBook)
                {
                    //find the selected book
                    Book dbBook = _context.Books.Find(b);
                    //Set the found book to the book in the review 
                    review.Book = dbBook;
                }
                //Add the review to the database and save changes
                _context.Add(review);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            //Repopulate the view bag 
            ViewBag.bookList = GetAllPurchasedBooks();
            return View(review);
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.Include(o => o.Book).FirstOrDefaultAsync(m => m.ReviewID == id);

            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        //GET: List of reviews to approve
        public async Task<IActionResult> Approval()
        {
            //Creates a list of reviews to view
            List<Review> Reviews = new List<Review>();

            Reviews = _context.Reviews.Where(r => r.ApprovalStatus == false).ToList();

            return View(await _context.Reviews.Include(r => r.Author).ToListAsync());
        }

        //GET: Reviews/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReviewID,ReviewText,Rating,ApprovalStatus")] Review review)
        {
            if (id != review.ReviewID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.ReviewID))
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
            return View(review);
        }

        private SelectList GetAllPurchasedBooks()
        {

            /*List<CustomerOrder> customerOrders = _context.CustomerOrders.Include(co => co.CustomerOrderDetails).Where(o => o.AppUser.UserName == User.Identity.Name).ToList();

            List<CustomerOrderDetail> orderDetails = new List<CustomerOrderDetail>();

            foreach (CustomerOrder order in customerOrders)
            {
                foreach (CustomerOrderDetail detail in order.CustomerOrderDetails)
                {
                    orderDetails.Add(detail);
                }
            }*/

            List<CustomerOrderDetail> orderDetails = _context.CustomerOrderDetails.Include(ord => ord.Book).ToList();
            List<Book> boughtBooks = new List<Book>();

            foreach (CustomerOrderDetail detail in orderDetails)
            {
                boughtBooks.Add(detail.Book);
            }

            SelectList bookList = new SelectList(boughtBooks, "BookID", "Title");
            return bookList;
        }

        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.ReviewID == id);
        }

    }
}
