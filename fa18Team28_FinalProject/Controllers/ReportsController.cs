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
    public enum BookReportClassification { RecentFirst, HighestProfitMargin, LowestProfitMargin, AscendingPrice, DescendingPrice, MostPopular };

    public class ReportsController : Controller
    {
        private AppDbContext _dab;

        public ReportsController(AppDbContext context)
        {
            _dab = context;
        }

        public IActionResult Details(int? id)
        {
            if (id == null) //order id not specified
            {
                return View("Error", new String[] { "Book ID not specified - which order do you want to view?" });
            }

            Book bk = _dab.Books.Include(r => r.Genre).FirstOrDefault(r => r.BookID == id);

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
            var query = from r in _dab.Books
                        select r;

            var queryTwo = from a in _dab.Reviews
                           select a;

            var queryThree = from o in _dab.CustomerOrderDetails
                             select o;

            //execute the query 
            SelectedBooks = query.Include(r => r.Genre).ToList(); //includes genres

            //get counts for viewbag
            ViewBag.SelectedBooks = SelectedBooks.Count;
            ViewBag.TotalBooks = _dab.Books.Count();

            //populating drop down list
            //ViewBag.AllGenres = GetAllGenres();

            //send the data back to view
            return View(SelectedBooks); 
        }

        /*//GET: Detailed Search
        public ActionResult Report()
        {
            ViewBag.AllGenres = GetAllGenres();
            return View();
        }*/

        public ActionResult DisplayBookReport(String reportRecentFirst, Int32 reportHighestProfitMargin, Int32 reportLowestProfitMargin, Int32 reportAscendingPrice, Int32 reportDescendingPrice, string reportMostPopular, BookReportClassification Filter, int intPurchaseCount, DateTime datPublishedDate)
        {
            List<Book> SelectedBooks = new List<Book>();
            List<CustomerOrderDetail> orderDetails = _dab.CustomerOrderDetails.Include(ord => ord.Book).ToList();


            var query = from r in _dab.Books
                        select r;

            //pull frmo customerorderdetails
            var queryThree = from o in _dab.CustomerOrderDetails
                             select o;

            //SelectedBooks = query.Include(r => r.Title).ToList();
            //SelectedBooks = queryThree.Include(o => o.BookID).ToList();

            //SelectedBooks = query.ToList();
            //SelectedBooks = query.Include(r => r.Title).ToList();

            foreach (CustomerOrderDetail ord in orderDetails)
            {
                SelectedBooks.Add(ord.Book);
            }

            /*//og place ViewBag.TotalBooks = _dab.Books.Count();
            ViewBag.SelectedBooks = SelectedBooks.Count; 

            //return View("BooksReport", SelectedBooks.OrderBy(r => r.Title));
            return View("BooksReport", SelectedBooks);*/


            //radio button stuff starts
            //update
            //created filter for greatest profit margin (ascending order)
            if (Filter == BookReportClassification.HighestProfitMargin)
            {
                query = query.Where(r => r.ProfitMargin <= reportHighestProfitMargin);
                ViewBag.TotalBooks = _dab.Books.Count();
                ViewBag.SelectedBooks = SelectedBooks.Count;

                //return View("BooksReport", SelectedBooks.OrderBy(r => r.Title));
                return View("BooksReport", SelectedBooks);

            }

            //update
            //created filter for lowest profit margin (decending order)
            if (Filter == BookReportClassification.LowestProfitMargin)
            {
                query = query.Where(r => r.ProfitMargin >= reportLowestProfitMargin);
                ViewBag.TotalBooks = _dab.Books.Count();
                ViewBag.SelectedBooks = SelectedBooks.Count;

                //return View("BooksReport", SelectedBooks.OrderBy(r => r.Title));
                return View("BooksReport", SelectedBooks);
            }

            //update
            //created filter for price (ascending order)
            if (Filter == BookReportClassification.AscendingPrice)
            {
                query = query.Where(r => r.Price <= reportAscendingPrice);
                ViewBag.TotalBooks = _dab.Books.Count();
                ViewBag.SelectedBooks = SelectedBooks.Count;

                //return View("BooksReport", SelectedBooks.OrderBy(r => r.Title));
                return View("BooksReport", SelectedBooks);
            }

            //created filter for price (decending order)
            if (Filter == BookReportClassification.DescendingPrice)
            {
                query = query.Where(r => r.Price >= reportDescendingPrice);
                ViewBag.TotalBooks = _dab.Books.Count();
                ViewBag.SelectedBooks = SelectedBooks.Count;

                //return View("BooksReport", SelectedBooks.OrderBy(r => r.Title));
                return View("BooksReport", SelectedBooks);
            }

            //created filter for most popular books (decending order)
            if (Filter == BookReportClassification.MostPopular)
            {
                query = query.Where(r => r.PurchaseCount <= intPurchaseCount);
                ViewBag.TotalBooks = _dab.Books.Count();
                ViewBag.SelectedBooks = SelectedBooks.Count;

                //return View("BooksReport", SelectedBooks.OrderBy(r => r.Title));
                return View("BooksReport", SelectedBooks);
            }

            else
            {
                return View("BooksReport", SelectedBooks);
            }

        }


        /*//Report Display Method (Display Search Results)  
        public ActionResult DisplayBookReport2(String reportRecentFirst, Int32 reportHighestProfitMargin, Int32 reportLowestProfitMargin, Int32 reportAscendingPrice, Int32 reportDescendingPrice, string reportMostPopular, BookReportClassification Filter, int intPurchaseCount, DateTime datPublishedDate)
        {
            //Create a list of books, this puts ALL books into a list and then we filter it with a query
            //List<Book> SelectedBooks = _dab.Books.ToList();
            //ordered books list

            //Start the query
            var query = from r in _dab.Books
                        select r;

            //start the query
            var queryTwo = from a in _dab.Reviews
                           select a;

            var queryThree = from o in _dab.CustomerOrderDetails
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

            /*else
            {
                return View("Index", SelectedBooks);
            }*/


            /*//repopulate the view bag
            ViewBag.AllGenres = GetAllGenres();*/
        
           /*else
            {
                //returns a redirect view to the index showing the list of filtered books
               return View("Index", SelectedBooks);
            }//end comments here
        }


        /*\//This method gets all genres
        public SelectList GetAllGenres()
        {
            List<Genre> Genres = _dab.Genres.ToList();

            //add record for all months
            Genre SelectNone = new Genre() { GenreID = 0, GenreName = "All Genres" };
            Genres.Add(SelectNone);

            SelectList AllGenres = new SelectList(Genres.OrderBy(l => l.GenreID), "GenreID", "GenreName");
            return AllGenres;
        }*/
    }
}