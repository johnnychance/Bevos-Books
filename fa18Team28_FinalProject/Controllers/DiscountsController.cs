using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;

namespace fa18Team28_FinalProject.Controllers
{
    [Authorize(Roles = "Manager")]
    public class DiscountsController : Controller
    {
        private readonly AppDbContext _context;

        public DiscountsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Discounts
        public IActionResult Index()
        {
            return View();
        }

        // GET: CustomerOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Discounts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiscountID,DiscountCode,Description,Type")] Discount discount)
        {

            if (ModelState.IsValid)
            {
                _context.Add(discount);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(discount);
        }
    }
}
