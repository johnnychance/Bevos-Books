using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bedford_Ashley_HW5.DAL;
using Bedford_Ashley_HW5.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bedford_Ashley_HW5.Controllers
{
    public enum SortOrder { MOSTPOPULAR, TITLE, AUTHOR, LOWPRICEFIRST, HIGHPRICEFIRST };

    public class HomeController : Controller
    {
        private AppDbContext _db;
        private decimal _decStars;

        public HomeController(AppDbContext context)
        {
            _db = context;
        }
        
        public IActionResult DetailedSearch()
        {
            ViewBag.AllGenres = GetAllGenres();
            return View();
        }

        public IActionResult DisplaySearchResults(string UniqueID, string Title,
            int Genre, string Author, SortOrder SortOrder)
        {
            //create list of required repos
            List<Repository> SelectedRepositories = new List<Repository>();

            //start the query
            var query = from r in _db.Repositories
                        select r;

            //if the user searched for something, limit the query
            if (UniqueID != null && UniqueID != "")
            {
                query = query.Where(r => r.UniqueID.Contains(UniqueID);
            }

            //if the user searched for something, limit the query
            if (Title != null && Title != "")
            {
                query = query.Where(r => r.Title.Contains(Title));
            }

            if (Genre == 0) // they chose "all languages from the drop-down
            {
                ViewBag.SearchGenre = "No language was selected";
            }
            else //language was chosen
            {
                Genre GenreToDisplay = _db.Genres.Find(Genre);
                ViewBag.SearchGenre = "The selected genre is " + GenreToDisplay.Name;
                query = query.Where(r => r.Genre.Name.Contains(GenreToDisplay.Name));
            }

            //TODO: Code for textbox with numeric input
            //see if they specified something for Stars
            if (Title != null && Title != "" && Author != null && Author!= "")
            //make sure string is a valid number
            {
                query = query.Where(r => r.Title.Contains(title) || r => r.Author.Contains(Author);

                //Re-populate dropdown
                ViewBag.AllGenres = GetAllGenres();

                //Send user back to home page
                return View("DetailedSearch");
            }

                //Add value to ViewBag
                ViewBag.UpdatedStars = "The desired number of Stars is " + _decStars.ToString("n2");
                
            }

            else  //they didn't specify Stars
            {
                ViewBag.UpdatedStars = "No Stars were specified";
            }

            //TODO: Code for date picker
            //Determine suggested date
            if (SearchModifiedAfter != null)
            {
                //convert date to non-nullable type.  ?? means if the datSelectedDate is null, set it equal to Jan 1, 1900
                DateTime datSelected = SearchModifiedAfter ?? new DateTime(1900, 1, 1);
                ViewBag.SelectedDate = "The selected date is " + datSelected.ToLongDateString();
                
                //new
                query = query.Where(r => r.LastUpdate == datSelected);
            }
            else //They didn't pick a date
            {
                ViewBag.SelectedDate = "No date was selected";
            }

            //TODO: More code for radio buttons (must pick one)
            //Figure out sort order
            if (SortOrder == SortOrder.GreaterThan)
            {
                ViewBag.SelectedSO = "The records should be greater than or equal to Stars";
                
                //new
                query = query.Where(r => r.StarCount >= _decStars);
            }
            if (SortOrder == SortOrder.LessThan)
            {
                ViewBag.SelectedSO = "The records should be less than or equal to Stars";

                //new
                query = query.Where(r => r.StarCount <= _decStars);
            }

            SelectedRepositories = query.ToList();
            SelectedRepositories = query.Include(r => r.Language).ToList();

            //get counts for ViewBag
            ViewBag.SelectedRecords = SelectedRepositories.Count;
            ViewBag.TotalRecords = _db.Repositories.Count();

            //send all this stuff to the view
            return View("Index", SelectedRepositories.OrderByDescending(r => r.StarCount));
        }

            public SelectList GetAllLanguages()
        {
            List<Language> Languages = _db.Languages.ToList();

            //add a record for all months
            Language SelectNone = new Language() { LanguageID = 0, Name = "All Languages" };
            Languages.Add(SelectNone);

            //convert list to select list
            SelectList AllLanguages = new SelectList(Languages.OrderBy(m => m.LanguageID), "LanguageID", "Name");

            //return the select list
            return AllLanguages;
        }

        public IActionResult Details(int? id)
        {
            if (id == null) //Repo id not specified
            {
                return View("Error", new String[] { "Repository ID not specified - which repo do you want to view?" });
            }

            Repository repo = _db.Repositories.Include(r => r.Language).FirstOrDefault(r => r.RepositoryID == id);

            if (repo == null) //Repo does not exist in database
            {
                return View("Error", new String[] { "Repository not found in database" });
            }

            //if code gets this far, all is well
            return View(repo);

        }


    }

}