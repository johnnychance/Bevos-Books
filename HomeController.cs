//Author: Ashley Bedford
//Date: November 1, 2018
//Assignment: Homework 5 
//Description: Search Code

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
    public enum SortOrder { GreaterThan, LessThan };

    public class HomeController : Controller
    {
        private AppDbContext _db;
        private decimal _decStars;

        public HomeController(AppDbContext context)
        {
            _db = context;
        }

        // GET: Home
        public IActionResult Index(string SearchString)
        {
            //create list of required repos
            List<Repository> SelectedRepositories = new List<Repository>();

            //start the query
            var query = from r in _db.Repositories
                        select r;

            if (_db.Repositories.Count() == 0) //there aren't any repos yet 
            {
                return RedirectToAction("Index", "Seed");
            }

            //if the user searched for something, limit the query
            if (SearchString != null && SearchString != "")
            {
                query = query.Where(r => r.RepositoryName.Contains(SearchString) || r.UserName.Contains(SearchString));
            }

            //execute the query
            SelectedRepositories = query.Include(r => r.Language).ToList();

            //get counts for ViewBag
            ViewBag.SelectedRecords = SelectedRepositories.Count;
            ViewBag.TotalRecords = _db.Repositories.Count();

            //send data back to the view
            return View(SelectedRepositories.OrderByDescending(r => r.StarCount));
        }

        public IActionResult DetailedSearch()
        {
            ViewBag.AllLanguages = GetAllLanguages();
            return View();
        }

        public IActionResult DisplaySearchResults(string SearchName, string SearchDescription,
            int SearchLanguage, string SearchStars, SortOrder SortOrder, DateTime? SearchModifiedAfter)
        {
            //create list of required repos
            List<Repository> SelectedRepositories = new List<Repository>();

            //start the query
            var query = from r in _db.Repositories
                        select r;

            //if the user searched for something, limit the query
            if (SearchName != null && SearchName != "")
            {
                query = query.Where(r => r.RepositoryName.Contains(SearchName) || r.UserName.Contains(SearchName));
            }

            //if the user searched for something, limit the query
            if (SearchDescription != null && SearchDescription != "")
            {
                query = query.Where(r => r.Description.Contains(SearchDescription));
            }

            if (SearchLanguage == 0) // they chose "all languages from the drop-down
            {
                ViewBag.SearchLanguage = "No language was selected";
            }
            else //language was chosen
            {
                Language LanguageToDisplay = _db.Languages.Find(SearchLanguage);
                ViewBag.SearchLanguage = "The selected language is " + LanguageToDisplay.Name;
                query = query.Where(r => r.Language.Name.Contains(LanguageToDisplay.Name));

            }

            //TODO: Code for textbox with numeric input
            //see if they specified something for Stars
            if (SearchStars != null && SearchStars != "")
            //make sure string is a valid number
            {                
                try
                {
                    _decStars = Convert.ToDecimal(SearchStars);                    
                }
                catch  //this code will display when something is wrong
                {
                    //Add a message for the viewbag
                    ViewBag.Message = SearchStars + " is not valid number. Please try again";

                    //Re-populate dropdown
                    ViewBag.AllLanguages = GetAllLanguages();

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