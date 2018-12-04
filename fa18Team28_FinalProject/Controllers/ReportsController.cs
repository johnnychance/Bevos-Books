using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace fa18Team28_FinalProject.Controllers
{
    //search: { Title, Author, MostPopular, NewestFirst, OldestFirst, HighestRated };
    public enum BookReportClassification { RecentFirst, HighestProfitMargin, LowestProfitMargin, MostPopular };

    public class ReportsController : Controller
    {
        private AppDbContext _db;

        public ReportsController(AppDbContext context)
        {
            _db = context;
        }

        public IActionResult Details(int? id)
        {
            if (id == null) //bk id not specified
            {
                return View("Error", new String[] { "Book ID not specified - which bk do you want to view?" });
            }

            Book bk = _db.Books.Include(r => r.Genre).FirstOrDefault(r => r.BookID == id);

            if (bk == null) //bk does not exist in database
            {
                return View("Error", new String[] { "Book not found in database" });
            }

            //if code gets this far, all is well
            return View(bk);
        }

        /*// GET: Home
        public ActionResult Index() 
        {
            //Create list of required books
            List<Book> SelectedBooks;

            //start the query
            var query = from r in _db.Books
                        select r;

            //execute the query 
            SelectedBooks = query.Include(r => r.Genre).ToList(); //includes genres

            //get counts for viewbag
            ViewBag.SelectedBooks = SelectedBooks.Count;
            ViewBag.TotalBooks = _db.Books.Count();

            //populating drop down list
            ViewBag.AllGenres = GetAllGenres();

            //send the data back to view
            return View(SelectedBooks); //this needs to be changed - see line below
        }

        //GET: Detailed Search
        public ActionResult Report()
        {
            ViewBag.AllGenres = GetAllGenres();
            return View();
        }

        //Report Display Method (Display Search Results) 
        public ActionResult DisplayReports(String searchTitle, String searchAuthor, Int32 searchUniqueID, int intRatingOrder, int SelectedGenre, BookReportClassification Filter, int intPurchaseCount, DateTime datPublishedDate)
        {
            //Create a list of books, this puts ALL books into a list and then we filter it with a query
            List<Book> SelectedBooks = _db.Books.ToList();

            //Start the query
            var query = from r in _db.Books
                        select r;


            //start the query
            var queryTwo = from a in _db.Reviews
                           select a;


            //update
            //created filter for highest rated books (decending order)
            if (Filter == BookReportClassification.RecentFirst)
            {
                queryTwo = queryTwo.Where(a => a.Rating <= intRatingOrder);
            }

            //update
            //created filter for newest books (decending order)
            if (Filter == BookReportClassification.HighestProfitMargin)
            {
                query = query.Where(r => r.PublishedDate <= datPublishedDate);
            }

            //update
            //created filter for newest books (decending order)
            if (Filter == BookReportClassification.LowestProfitMargin)
            {
                query = query.Where(r => r.PublishedDate <= datPublishedDate);
            }

            //created filter for most popular books (decending order)
            if (Filter == BookReportClassification.MostPopular)
            {
                query = query.Where(r => r.PurchaseCount <= intPurchaseCount);
            }


            SelectedBooks = query.ToList(); //new
            SelectedBooks = query.Include(r => r.Genre).ToList();


            ViewBag.TotalBooks = _db.Books.Count();
            ViewBag.SelectedBooks = SelectedBooks.Count();

            //repopulate the view bag
            ViewBag.AllGenres = GetAllGenres();
        }
        
            /*else
            {
                //returns a redirect view to the index showing the list of filtered books
                return View("Index", SelectedBooks);
            }//end comments here


        //This method gets all genres
        public SelectList GetAllGenres()
        {
            List<Genre> Genres = _db.Genres.ToList();

            //add record for all months
            Genre SelectNone = new Genre() { GenreID = 0, GenreName = "All Genres" };
            Genres.Add(SelectNone);

            SelectList AllGenres = new SelectList(Genres.OrderBy(l => l.GenreID), "GenreID", "GenreName");
            return AllGenres;
        }*/
    }
}