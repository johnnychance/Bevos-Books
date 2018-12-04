/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;

namespace fa18Team28_FinalProject.Controllers

{
    public class ReviewsController
    {
        private readonly AppDbContext _context;

        public ReviewsController(AppDbContext context)
        {
            _context = context;
        }

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        // GET: 
        public async Task<IActionResult> Index()
=======
=======
>>>>>>> parent of e554cca... Merge branch 'master' of https://github.com/mis333k-fall2018/fa18Team28
        // GET: List of Reviews
        public IActionResult Index()
>>>>>>> parent of e554cca... Merge branch 'master' of https://github.com/mis333k-fall2018/fa18Team28
        {
            return View(await _context.Books.Include(o => o.OrderDetails).ToListAsync());
        }
<<<<<<< HEAD
<<<<<<< HEAD
=======
        // GET: List of Reviews
        public IActionResult Index()
        {
            return View();
        }

>>>>>>> parent of e554cca... Merge branch 'master' of https://github.com/mis333k-fall2018/fa18Team28
=======

>>>>>>> parent of e554cca... Merge branch 'master' of https://github.com/mis333k-fall2018/fa18Team28
=======

>>>>>>> parent of e554cca... Merge branch 'master' of https://github.com/mis333k-fall2018/fa18Team28

    }
}
*/