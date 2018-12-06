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
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReviewID, ReviewText, Rating")] Review review)
        {
            string cd = User.Identity.Name;
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == cd);
            review.Author = user;

            if (ModelState.IsValid)
            {
                _context.Add(review);
                await _context.SaveChangesAsync();
            }
            return View("Index");
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

    }
}
