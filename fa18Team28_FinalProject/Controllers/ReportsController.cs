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
    public enum BookReportClassification { RecentFirst, HighestProfitMargin, LowestProfitMargin, AscendingPrice, DescendingPrice, MostPopular };

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

        // GET: Home
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



            //send the data back to view
            return View(SelectedBooks); //this needs to be changed - see line below
        }

        /*//GET: Detailed Search
        public ActionResult Report()
        {
            //ViewBag.AllGenres = GetAllGenres();
            return View();
        }*/

        //Report Display Method (Display Search Results)  
        public ActionResult DisplayBookReport(String reportRecentFirst, Int32 reportHighestProfitMargin, Int32 reportLowestProfitMargin, Int32 reportAscendingPrice, Int32 reportDescendingPrice, string reportMostPopular, BookReportClassification Filter, int intPurchaseCount, DateTime datPublishedDate)
        {
            //Create a list of books, this puts ALL books into a list and then we filter it with a query
            //List<Book> SelectedBooks = _db.Books.ToList();
            //ordered books list
            List<CustomerOrderDetail> OrderedBooks = _db.CustomerOrderDetails.Include(CustomerOrderDetailID).ThenInclude(BookID).ToList();

            //Find the related order detail in the database
            CustomerOrderDetail OrderedBooks = _context.CustomerOrderDetails.Include(o => o.Book).Include(o => o.CustomerOrder).
                FirstOrDefault(o => o.CustomerOrderDetailID == orderDetail.CustomerOrderDetailID);

            //Start the query
            var query = from r in _db.Books
                        select r;

            //start the query
            var queryTwo = from a in _db.Reviews
                           select a;

            var queryThree = from o in _db.CustomerOrderDetails
                             select o;


            //update
            //created filter for most recently bought books
            //created filter for title of books (decending order)
            /*if (Filter == BookReportClassification.RecentFirst)
            {
                return View("Index", OrderedBooks.OrderBy(o => o.Book));
            }

            if (Filter == BookReportClassification.RecentFirst)
            {
                query = queryThree.Where(o => o.Book );
            }*/

            //update
            //created filter for greatest profit margin (ascending order)
            if (Filter == BookReportClassification.HighestProfitMargin)
            {
                query = query.Where(r => r.ProfitMargin <= reportHighestProfitMargin);
            }

            //update
            //created filter for lowest profit margin (decending order)
            if (Filter == BookReportClassification.LowestProfitMargin)
            {
                query = query.Where(r => r.ProfitMargin >= reportLowestProfitMargin);
            }

            //update
            //created filter for price (ascending order)
            if (Filter == BookReportClassification.AscendingPrice)
            {
                query = query.Where(r => r.Price <= reportAscendingPrice);
            }

            //created filter for price (decending order)
            if (Filter == BookReportClassification.DescendingPrice)
            {
                query = query.Where(r => r.Price >= reportDescendingPrice);
            }

            //created filter for most popular books (decending order)
            if (Filter == BookReportClassification.MostPopular)
            {
                query = query.Where(r => r.PurchaseCount <= intPurchaseCount);
            }

            /*else
            {
                return View("Index", SelectedBooks);
            }*/

            OrderedBooks = query.ToList(); //new
            OrderedBooks = query.Include(r => r.Genre).ToList();


            //viewbags for selectedbooks list
            ViewBag.TotalBooks = _db.Books.Count();
            ViewBag.SelectedBooks = OrderedBooks.Count();

            //viewbags for orderedbooks list
            ViewBag.TotalBooks = _db.Books.Count();
            ViewBag.OrderedBooks = OrderedBooks.Count();

            return View("Index", OrderedBooks);

            /*//repopulate the view bag
            ViewBag.AllGenres = GetAllGenres();*/
        
            /*else
            {
                //returns a redirect view to the index showing the list of filtered books
               return View("Index", SelectedBooks);
            }//end comments here*/
        }


        //This method gets all genres
        public SelectList GetAllGenres()
        {
            List<Genre> Genres = _db.Genres.ToList();

            //add record for all months
            Genre SelectNone = new Genre() { GenreID = 0, GenreName = "All Genres" };
            Genres.Add(SelectNone);

            SelectList AllGenres = new SelectList(Genres.OrderBy(l => l.GenreID), "GenreID", "GenreName");
            return AllGenres;
        }
    }
}