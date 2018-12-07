using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace fa18Team28_FinalProject.Controllers
{
    public enum BookReportClassification { RecentFirst, HighestProfitMargin, LowestProfitMargin, AscendingPrice, DescendingPrice, MostPopular };

    [Authorize(Roles = "Manager")]
    public class ReportsController : Controller
    {
        private AppDbContext _dab;

        public ReportsController(AppDbContext context)
        {
            _dab = context;
        }


        //home
        public async Task<IActionResult> Index()
        {
            return View(await _dab.Books.ToListAsync());
        }

        public IActionResult DisplayBookReport(String reportRecentFirst, Int32 reportHighestProfitMargin, Int32 reportLowestProfitMargin, Int32 reportAscendingPrice, Int32 reportDescendingPrice, string reportMostPopular, BookReportClassification Filter, int intPurchaseCount, DateTime datPublishedDate)
        {

            CustomerOrder order = new CustomerOrder();
            Book book = new Book();

            List<CustomerOrderDetail> orderDetails = new List<CustomerOrderDetail>();
            orderDetails = _dab.CustomerOrderDetails.Include(o => o.Book).Include(o => o.CustomerOrder).ThenInclude(o => o.AppUser)
                               .Where(o => o.CustomerOrder.CustomerOrderStatus == false).ToList();


            //created filter for recent first
            if (Filter == BookReportClassification.RecentFirst)
            {
                return View("BooksReport", orderDetails.OrderBy(r => r.Book.PublishedDate));
            }

            //created filter for greatest profit margin (descending order)
            if (Filter == BookReportClassification.HighestProfitMargin)
            {
                return View("BooksReport", orderDetails.OrderByDescending(r => r.Book.ProfitMargin));
            }

            //update
            //created filter for lowest profit margin (ascending order)
            if (Filter == BookReportClassification.LowestProfitMargin)
            {
                /*query = query.Where(r => r.ProfitMargin >= reportLowestProfitMargin);
                ViewBag.TotalBooks = _dab.Books.Count();
                ViewBag.SelectedBooks = SelectedBooks.Count;
                return View("BooksReport", SelectedBooks);*/

                return View("BooksReport", orderDetails.OrderBy(r => r.Book.ProfitMargin));

            }

            //created filter for greatest price  (ascending order)
            if (Filter == BookReportClassification.AscendingPrice)
            {
                return View("BooksReport", orderDetails.OrderBy(r => r.Book.Price));
            }

            //update
            //created filter for lowest price  (descending order)
            if (Filter == BookReportClassification.DescendingPrice)
            {
                return View("BooksReport", orderDetails.OrderBy(r => r.Book.ProfitMargin));

            }

            //created filter for recent first
            if (Filter == BookReportClassification.MostPopular)
            {
                return View("BooksReport", orderDetails.OrderBy(r => r.Book.PurchaseCount));
            }

            return View("BooksReport", orderDetails);

            //ViewBag.orderDetails = orderDetails.Count();
            //List<String> ReportClassifications = new List<String> { "RecentFirst", "HighestProfitMargin", "LowestProfitMargin", "AscendingPrice", "DescendingPrice", "MostPopular" };

            //SelectList filter = new SelectList(ReportClassifications);
            //ViewBag.filter = filter;

            /*//pull from books
            var query = from r in _dab.Books
                        select r;

            //pull from customerorderdetails
            var queryThree = from o in _dab.CustomerOrderDetails
                             select o;

            foreach (CustomerOrderDetail ord in orderDetails)
            {
                SelectedBooks.Add(ord.Book);
            }

            //og place ViewBag.TotalBooks = _dab.Books.Count();
            ViewBag.SelectedBooks = SelectedBooks.Count; 

            //return View("BooksReport", SelectedBooks.OrderBy(r => r.Title));
            return View("BooksReport", SelectedBooks);


            //radio button stuff starts
            //update
            //created filter for greatest profit margin (ascending order)
            if (Filter == BookReportClassification.HighestProfitMargin)
            {
                query = query.Where(r => r.ProfitMargin <= reportHighestProfitMargin);
                ViewBag.TotalBooks = _dab.Books.Count();
                ViewBag.SelectedBooks = SelectedBooks.Count;
                return View("BooksReport", SelectedBooks);
            }

            //update
            //created filter for lowest profit margin (decending order)
            if (Filter == BookReportClassification.LowestProfitMargin)
            {
                query = query.Where(r => r.ProfitMargin >= reportLowestProfitMargin);
                ViewBag.TotalBooks = _dab.Books.Count();
                ViewBag.SelectedBooks = SelectedBooks.Count;
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
                return View("BooksReport", SelectedBooks);
            }

            //created filter for most popular books (decending order)
            if (Filter == BookReportClassification.MostPopular)
            {
                query = query.Where(r => r.PurchaseCount <= intPurchaseCount);
                ViewBag.TotalBooks = _dab.Books.Count();
                ViewBag.SelectedBooks = SelectedBooks.Count;
                return View("BooksReport", SelectedBooks);
            }

            else
            {
                return View("BooksReport", SelectedBooks);
            }

        }
        */

        }

        //ORDER REPORT CODE BEGINS HERE
        public ActionResult DisplayOrderReport(String reportRecentFirst, Int32 reportHighestProfitMargin, Int32 reportLowestProfitMargin, Int32 reportAscendingPrice, Int32 reportDescendingPrice, string reportMostPopular, BookReportClassification Filter, int intPurchaseCount, DateTime datPublishedDate)
        {
            CustomerOrder order = new CustomerOrder();
            Book book = new Book();

            List<CustomerOrderDetail> orderReportDetails = new List<CustomerOrderDetail>();
            orderReportDetails = _dab.CustomerOrderDetails.Include(o => o.Book).Include(o => o.CustomerOrder).ThenInclude(o => o.AppUser)
                               .Where(o => o.CustomerOrder.CustomerOrderStatus == false).ToList();

            return View("OrdersReport", orderReportDetails);

            /*List<CustomerOrder> OrderList = _dab.CustomerOrders.Include(ord => ord.CustomerOrderDetails).ToList();

            //List <CustomerOrderDetail> orderDetails = _dab.CustomerOrderDetails.Include(ord => ord.CustomerOrder).ToList();

            var query = from r in _dab.Books
                        select r;

            //pull from customerorderdetails
            var queryThree = from o in _dab.CustomerOrderDetails
                             select o;

            //created filter for greatest profit margin (ascending order)
            if (Filter == BookReportClassification.HighestProfitMargin)
            {
                query = query.Where(r => r.ProfitMargin <= reportHighestProfitMargin);
                ViewBag.TotalBooks = _dab.Books.Count();
                ViewBag.OrderList = OrderList.Count;

                //return View("BooksReport", SelectedBooks.OrderBy(r => r.Title));
                return View("OrdersReport", OrderList);
            }

            //update
            //created filter for lowest profit margin (decending order)
            if (Filter == BookReportClassification.LowestProfitMargin)
            {
                query = query.Where(r => r.ProfitMargin >= reportLowestProfitMargin);
                ViewBag.TotalBooks = _dab.Books.Count();
                ViewBag.OrderList = OrderList.Count;

                //return View("BooksReport", SelectedBooks.OrderBy(r => r.Title));
                return View("OrdersReport", OrderList);
            }

            //update
            //created filter for price (ascending order)
            if (Filter == BookReportClassification.AscendingPrice)
            {
                query = query.Where(r => r.Price <= reportAscendingPrice);
                ViewBag.TotalBooks = _dab.Books.Count();
                ViewBag.OrderList = OrderList.Count;

                //return View("BooksReport", SelectedBooks.OrderBy(r => r.Title));
                return View("OrdersReport", OrderList);
            }

            //created filter for price (decending order)
            if (Filter == BookReportClassification.DescendingPrice)
            {
                query = query.Where(r => r.Price >= reportDescendingPrice);
                ViewBag.TotalBooks = _dab.Books.Count();
                ViewBag.OrderList = OrderList.Count;

                //return View("BooksReport", SelectedBooks.OrderBy(r => r.Title));
                return View("OrdersReport", OrderList);
            }

            //created filter for most popular books (decending order)
            if (Filter == BookReportClassification.MostPopular)
            {
                query = query.Where(r => r.PurchaseCount <= intPurchaseCount);
                ViewBag.TotalBooks = _dab.Books.Count();
                ViewBag.OrderList = OrderList.Count;

                //return View("BooksReport", SelectedBooks.OrderBy(r => r.Title));
                return View("OrdersReport", OrderList);
            }

            else
            {
                return View("OrdersReport", OrderList);
            }

        }*/
        }

        //CUSTOMER REPORT CODE BEGINS HERE
        public ActionResult DisplayCustomerReport(String reportRecentFirst, Int32 reportHighestProfitMargin, Int32 reportLowestProfitMargin, Int32 reportAscendingPrice, Int32 reportDescendingPrice, string reportMostPopular, BookReportClassification Filter, int intPurchaseCount, DateTime datPublishedDate)
        {
            CustomerOrder order = new CustomerOrder();
            Book book = new Book();

            List<CustomerOrderDetail> orderReportDetails = new List<CustomerOrderDetail>();
            orderReportDetails = _dab.CustomerOrderDetails.Include(o => o.Book).Include(o => o.CustomerOrder).ThenInclude(o => o.AppUser)
                               .Where(o => o.CustomerOrder.CustomerOrderStatus == false).ToList();

            return View("CustomersReport", orderReportDetails);

        }
        /*//creates a list of all customers to be displayed
        List<CustomerOrder> CustomerList = _dab.CustomerOrders.Include(ord => ord.CustomerOrderID).ToList();

        var query = from r in _dab.Books
                    select r;

        //pull from customerorderdetails
        var queryThree = from o in _dab.CustomerOrderDetails
                         select o;

        //created filter for greatest profit margin (ascending order)
        if (Filter == BookReportClassification.HighestProfitMargin)
        {
            query = query.Where(r => r.ProfitMargin <= reportHighestProfitMargin);
            ViewBag.TotalBooks = _dab.Books.Count();
            ViewBag.CustomerList = CustomerList.Count;

            //return View("BooksReport", SelectedBooks.OrderBy(r => r.Title));
            return View("CustomersReport", CustomerList);
        }

        //update
        //created filter for lowest profit margin (decending order)
        if (Filter == BookReportClassification.LowestProfitMargin)
        {
            query = query.Where(r => r.ProfitMargin >= reportLowestProfitMargin);
            ViewBag.TotalBooks = _dab.Books.Count();
            ViewBag.CustomerList = CustomerList.Count;

            //return View("BooksReport", SelectedBooks.OrderBy(r => r.Title));
            return View("CustomersReport", CustomerList);
        }

        //update
        //created filter for price (ascending order)
        if (Filter == BookReportClassification.AscendingPrice)
        {
            query = query.Where(r => r.Price <= reportAscendingPrice);
            ViewBag.TotalBooks = _dab.Books.Count();
            ViewBag.CustomerList = CustomerList.Count;

            //return View("BooksReport", SelectedBooks.OrderBy(r => r.Title));
            return View("CustomersReport", CustomerList);
        }

        //created filter for price (decending order)
        if (Filter == BookReportClassification.DescendingPrice)
        {
            query = query.Where(r => r.Price >= reportDescendingPrice);
            ViewBag.TotalBooks = _dab.Books.Count();
            ViewBag.CustomerList = CustomerList.Count;

            //return View("BooksReport", SelectedBooks.OrderBy(r => r.Title));
            return View("CustomersReport", CustomerList);
        }

        //created filter for most popular books (decending order)
        if (Filter == BookReportClassification.MostPopular)
        {
            query = query.Where(r => r.PurchaseCount <= intPurchaseCount);
            ViewBag.TotalBooks = _dab.Books.Count();
            ViewBag.CustomerList = CustomerList.Count;

            //return View("BooksReport", SelectedBooks.OrderBy(r => r.Title));
            return View("CustomersReport", CustomerList);
        }

        else
        {
            return View("CustomersReport", CustomerList);
        }*/



        //ORDER REPORT CODE BEGINS HERE
        public ActionResult DisplayTotalsReport(String reportRecentFirst, Int32 reportHighestProfitMargin, Int32 reportLowestProfitMargin, Int32 reportAscendingPrice, Int32 reportDescendingPrice, string reportMostPopular, BookReportClassification Filter, int intPurchaseCount, DateTime datPublishedDate)
        {
            CustomerOrder order = new CustomerOrder();
            Book book = new Book();
            decimal decTotalProfit; 

            List<CustomerOrderDetail> orderReportDetails = new List<CustomerOrderDetail>();
            orderReportDetails = _dab.CustomerOrderDetails.Include(o => o.Book).Include(o => o.CustomerOrder).ThenInclude(o => o.AppUser)
                               .Where(o => o.CustomerOrder.CustomerOrderStatus == false).ToList();
            List<Book> orderedBooks = new List<Book>();

            foreach (CustomerOrderDetail detail in orderReportDetails)
            {
                orderedBooks.Add(detail.Book);
            }

            decTotalProfit = orderedBooks.Sum(item => item.Price);

            ViewBag.TotalProfit = decTotalProfit;
            return View("TotalsReport", orderReportDetails);
        }


        public ActionResult DisplayInventoryReport(String reportRecentFirst, Int32 reportHighestProfitMargin, Int32 reportLowestProfitMargin, Int32 reportAscendingPrice, Int32 reportDescendingPrice, string reportMostPopular, BookReportClassification Filter, int intPurchaseCount, DateTime datPublishedDate)
        {
            CustomerOrder order = new CustomerOrder();
            Book book = new Book();

            List<CustomerOrderDetail> orderReportDetails = new List<CustomerOrderDetail>();
            orderReportDetails = _dab.CustomerOrderDetails.Include(o => o.Book).Include(o => o.CustomerOrder).ThenInclude(o => o.AppUser)
                               .Where(o => o.CustomerOrder.CustomerOrderStatus == false).ToList();

            return View("InventoryReport", orderReportDetails);

            /*if (Filter == BookReportClassification.HighestProfitMargin)
            {
                query = query.Where(r => r.ProfitMargin <= reportHighestProfitMargin);
                ViewBag.TotalBooks = _dab.Books.Count();
                ViewBag.SelectedBooks = SelectedBooks.Count;

            }

            //update
            //created filter for lowest profit margin (decending order)
            if (Filter == BookReportClassification.LowestProfitMargin)
            {
                query = query.Where(r => r.ProfitMargin >= reportLowestProfitMargin);
                ViewBag.TotalBooks = _dab.Books.Count();
                ViewBag.SelectedBooks = SelectedBooks.Count;

            }

            //update
            //created filter for price (ascending order)
            if (Filter == BookReportClassification.AscendingPrice)
            {
                query = query.Where(r => r.Price <= reportAscendingPrice);
                ViewBag.TotalBooks = _dab.Books.Count();
                ViewBag.SelectedBooks = SelectedBooks.Count;

            }

            //created filter for price (decending order)
            if (Filter == BookReportClassification.DescendingPrice)
            {
                query = query.Where(r => r.Price >= reportDescendingPrice);
                ViewBag.TotalBooks = _dab.Books.Count();
                ViewBag.SelectedBooks = SelectedBooks.Count;
            }

            //created filter for most popular books (decending order)
            if (Filter == BookReportClassification.MostPopular)
            {
                query = query.Where(r => r.PurchaseCount <= intPurchaseCount);
                ViewBag.TotalBooks = _dab.Books.Count();
                ViewBag.SelectedBooks = SelectedBooks.Count;
            }

            else
            {
                return View("InventoryReport", SelectedBooks);
            }

        }*/
        }
            public ActionResult DisplayReviewsReport(String reportRecentFirst, Int32 reportHighestProfitMargin, Int32 reportLowestProfitMargin, Int32 reportAscendingPrice, Int32 reportDescendingPrice, string reportMostPopular, BookReportClassification Filter, int intPurchaseCount, DateTime datPublishedDate)
            {
                CustomerOrder order = new CustomerOrder();
                Book book = new Book();

                List<CustomerOrderDetail> orderReportDetails = new List<CustomerOrderDetail>();
                orderReportDetails = _dab.CustomerOrderDetails.Include(o => o.Book).Include(o => o.CustomerOrder).ThenInclude(o => o.AppUser)
                                   .Where(o => o.CustomerOrder.CustomerOrderStatus == false).ToList();

                return View("ReviewsReport", orderReportDetails);
            }
    }
}
