using System;
using Microsoft.AspNetCore.Mvc;
namespace fa18Team28_FinalProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
