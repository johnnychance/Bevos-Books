using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;
using fa18Team28_FinalProject.Utilities;

namespace fa18Team28_FinalProject.Controllers
{
    public class ManagerOrdersController : Controller
    {
        private readonly AppDbContext _context;

        public ManagerOrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ManagerOrders
        public async Task<IActionResult> Index()
        {
            return View(await _context.ManagerOrders.ToListAsync());
        }

        // GET: ManagerOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var managerOrder = await _context.ManagerOrders
                .FirstOrDefaultAsync(m => m.ManagerOrderID == id);
            if (managerOrder == null)
            {
                return NotFound();
            }

            return View(managerOrder);
        }

        // GET: ManagerOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManagerOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ManagerOrderID,ManagerOrderDate,ManagerOrderDetailNotes")] ManagerOrder managerOrder)
        {
            managerOrder.ManagerOrderNumber = GenerateNextOrderNumber.GetNextOrderNumber(_context);
            managerOrder.ManagerOrderDate = System.DateTime.Today;

            if (ModelState.IsValid)
            {
                _context.Add(managerOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(managerOrder);
        }

        // GET: ManagerOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var managerOrder = await _context.ManagerOrders.FindAsync(id);
            if (managerOrder == null)
            {
                return NotFound();
            }
            return View(managerOrder);
        }

        // POST: ManagerOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ManagerOrderID,ManagerOrderDate,ManagerOrderDetailNotes")] ManagerOrder managerOrder)
        {
            if (id != managerOrder.ManagerOrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(managerOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManagerOrderExists(managerOrder.ManagerOrderID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(managerOrder);
        }

        // GET: ManagerOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var managerOrder = await _context.ManagerOrders
                .FirstOrDefaultAsync(m => m.ManagerOrderID == id);
            if (managerOrder == null)
            {
                return NotFound();
            }

            return View(managerOrder);
        }

        // POST: ManagerOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var managerOrder = await _context.ManagerOrders.FindAsync(id);
            _context.ManagerOrders.Remove(managerOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManagerOrderExists(int id)
        {
            return _context.ManagerOrders.Any(e => e.ManagerOrderID == id);
        }
        //GET
        public IActionResult AutomaticReorder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerOrder = _context.ManagerOrders.Include(r => r.ManagerOrderDetails).ThenInclude(r => r.Book).
                FirstOrDefault(r => r.ManagerOrderID == id);

            if (customerOrder == null)
            {
                return NotFound();
            }

            return View(customerOrder);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AutomaticReorder([Bind("ManagerOrderID,ManagerOrderDate,ManagerOrderDetailNotes")] ManagerOrder managerOrder)
        {
            managerOrder.ManagerOrderNumber = GenerateNextOrderNumber.GetNextOrderNumber(_context);
            managerOrder.ManagerOrderDate = System.DateTime.Today;

            if (ModelState.IsValid)
            {
                _context.Add(managerOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(managerOrder);
        }
    }
}
