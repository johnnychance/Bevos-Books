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
    public enum oldBookReportClassification { RecentFirst, HighestProfitMargin, LowestProfitMargin, AscendingPrice, DescendingPrice, MostPopular };

    public class ReportsControllerOld : Controller
    {
        private readonly AppDbContext _db;

        public ReportsControllerOld(AppDbContext context)
        {
            _db = context;
        }

        public IActionResult Details(int? id)
        {
            if (id == null) //order id not specified
            {
                return View("Error", new String[] { "Order ID not specified - which order do you want to view?" });
            }

            CustomerOrderDetail cod = _db.CustomerOrderDetails.Include(r => r.Book).FirstOrDefault(r => r.CustomerOrderDetailID == id);

            if (cod == null) //bk does not exist in database
            {
                return View("Error", new String[] { "Order not found in database" });
            }

            //if code gets this far, all is well
            return View(cod);
        }

        // GET: Home
        public ActionResult Index() 
        {
            //Create list of required books
            List<CustomerOrderDetail> OrderedBooks;

            //start the query
            var query = from r in _db.Books
                        select r;

            var queryTwo = from a in _db.Reviews
                           select a;

            var queryThree = from o in _db.CustomerOrderDetails
                             select o;

            //execute the query 
            OrderedBooks = queryThree.Include(o => o.Book).ToList(); //includes genres

            //get counts for viewbag
            ViewBag.OrderedBooks = OrderedBooks.Count;
            ViewBag.TotalOrders = _db.CustomerOrderDetails.Count();

            //send the data back to view
            return View(OrderedBooks); 
        }

        /*//GET: Detailed Search
        public ActionResult Report()
        {
            ViewBag.AllGenres = GetAllGenres();
            return View();
        }*/

       /*public ActionResult DisplayBookReport(String reportRecentFirst, Int32 reportHighestProfitMargin, Int32 reportLowestProfitMargin, Int32 reportAscendingPrice, Int32 reportDescendingPrice, string reportMostPopular, BookReportClassification Filter, int intPurchaseCount, DateTime datPublishedDate)
        {
            foreach (ManagerOrderDetail ord in details)
            {
                OrderedBooks.Add(ord.Book);
            }

            Order
        }*/


        //Report Display Method (Display Search Results)  
        public ActionResult DisplayBookReport(String reportRecentFirst, Int32 reportHighestProfitMargin, Int32 reportLowestProfitMargin, Int32 reportAscendingPrice, Int32 reportDescendingPrice, string reportMostPopular, BookReportClassification Filter, int intPurchaseCount, DateTime datPublishedDate)
        {
            //Create a list of books, this puts ALL books into a list and then we filter it with a query
            //List<Book> SelectedBooks = _db.Books.ToList();
            //ordered books list

            //Start the query
            var query = from r in _db.Books
                        select r;

            //start the query
            var queryTwo = from a in _db.Reviews
                           select a;

            var queryThree = from o in _db.CustomerOrderDetails
                             select o;

            //List<CustomerOrderDetail> OrderedBooks = _db.CustomerOrderDetails.Include(o => o.CustomerOrderDetailID).ThenInclude(r => r.BookID).ToList();
            List<CustomerOrderDetail> OrderedBooks = _db.CustomerOrderDetails.Include(o => o.CustomerOrderDetailID).ToList();

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

            OrderedBooks = queryThree.ToList(); //new
            //OrderedBooks = queryThree.Include(r => r.Genre).ToList();


            //viewbags for selectedbooks list
            ViewBag.TotalOrders = _db.CustomerOrders.Count(); //customerorders or customer orderdetails
            ViewBag.OrderedBooks = OrderedBooks.Count();

            //viewbags for orderedbooks list
            ViewBag.TotalBooks = _db.Books.Count();
            ViewBag.OrderedBooks = OrderedBooks.Count();

            return View("Index", OrderedBooks);
        }
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
            List<Genre> Genres = _db.Genres.ToList();

            //add record for all months
            Genre SelectNone = new Genre() { GenreID = 0, GenreName = "All Genres" };
            Genres.Add(SelectNone);

            SelectList AllGenres = new SelectList(Genres.OrderBy(l => l.GenreID), "GenreID", "GenreName");
            return AllGenres;
        }*/
    }
}