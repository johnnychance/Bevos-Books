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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//*******make this a search controller instead of home controller bc search will not be on home page
//repositories --> Books (r refers to books)
//languages --> genres (l refers to genres)
//Star count is ratings in this case, which is a property under review

namespace fa18Team28_FinalProject.Controllers
{
    public enum Classification { Title, Author, MostPopular, NewestFirst, OldestFirst, HighestRated };

    public class SearchController : Controller
    {
        private AppDbContext _db;

        public SearchController(AppDbContext context)
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

            if (_db.Books.Count() == 0)//there are not any books yet
            {
                return RedirectToAction("Index", "Seed"); //redirects to index seed - tells you if no books 
            }

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
        public ActionResult DetailedSearch()
        {
            ViewBag.AllGenres = GetAllGenres();
            return View();
        }

        /*
        //Detailed Search method 1
        public ActionResult DetailedSearch(String SearchString)
        {
            ViewBag.AllGenres = GetAllGenres();
            //send the data back to view
            return View();
        }*/

        //Detailed Search method 2 
        public ActionResult DisplaySearchResults(String searchTitle, String searchAuthor, /*String searchString*/ Int32 searchUniqueID, int SelectedGenre)
        {
            //Create a list of books, this puts ALL books into a list and then we filter it with a query
            List<Book> SelectedBooks = _db.Books.ToList();

            //Start the query
            var query = from r in _db.Books
                        select r;

            //Filter query using:
            //Title only
            if (searchTitle == null || searchTitle == "") //no selection made
            {
                ViewBag.SearchString = "Name search string was null";
            }

            else //something was selected
            {
                query = query.Where(r => r.Title == searchTitle );
            }

            //Author only
            if (searchAuthor == null || searchAuthor == "") //no selection made
            {
                ViewBag.Description = "Name description string was null";
            }

            else //something was selected
            {
                query = query.Where(r => r.Author.Contains(searchAuthor));
            }

            /*
            //Author AND Title
            if ((searchAuthor == null || searchAuthor == "") && (searchTitle == null || searchTitle == "")) //no selection made
            {
                ViewBag.Description = "Title and Author string was null";
            }

            else //something was selected
            {
                query = query.Where(r => r.Author.Contains(searchString) || r.Title.Contains(searchString));
            }*/

            //UniqueID
            if (searchUniqueID == 0) //no selection made
            {

                ViewBag.Description = "Unique ID was null";

            }

            else //something was selected
            {
                query = query.Where(r => r.UniqueID == searchUniqueID);
            }

           
            if (SelectedGenre != 0)
            {
                query = query.Where(r => r.Genre.GenreID == SelectedGenre);
            }
           

            SelectedBooks = query.ToList(); //new
            SelectedBooks = query.Include(r => r.Genre).ToList();


            ViewBag.TotalBooks = _db.Books.Count();
            ViewBag.SelectedBooks = SelectedBooks.Count();

            //repopulate the view bag
            ViewBag.AllGenres = GetAllGenres();

            //returns a redirect view to the index showing the list of filtered books
            return View("Index", SelectedBooks);
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
