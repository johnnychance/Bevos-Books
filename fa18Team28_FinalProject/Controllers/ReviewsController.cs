﻿using System;
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

        // GET: 
        public async Task<IActionResult> Index()
        {
            return View(await _context.Books.Include(o => o.OrderDetails).ToListAsync());
        }

    }
}