using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;

namespace fa18Team28_FinalProject.Controllers
{
    public class SearchController : Controller
    {
        //Create an instance of the db context
        private AppDbContext _db;
        public SearchController(AppDbContext context)
        {
            _db = context;
        }

        public ActionResult Index()
        {
            return View();
        }


    }
}
