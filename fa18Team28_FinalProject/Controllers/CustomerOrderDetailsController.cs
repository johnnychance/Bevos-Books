using System;
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
    public class CustomerOrderDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerOrderDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: OrderDetails/Edit/5
        // Gets the info for the customer to edit their order details
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.CustomerOrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerOrderDetail orderDetail)
        {
            //Find the related order detail in the database
            CustomerOrderDetail DbOrdDet = _context.CustomerOrderDetails.Include(o => o.Book).Include(o => o.CustomerOrder).
                FirstOrDefault(o => o.CustomerOrderDetailID ==orderDetail.CustomerOrderDetailID);

            //update the related fields
            DbOrdDet.Quantity = orderDetail.Quantity;
            DbOrdDet.ProductPrice = DbOrdDet.Book.Price;
            DbOrdDet.ExtendedPrice = DbOrdDet.ProductPrice * DbOrdDet.Quantity;

            //update the database
            _context.CustomerOrderDetails.Update(DbOrdDet);
            _context.SaveChanges();

            //return to the order details
            return RedirectToAction("Details", "CustomerOrders", new { id = DbOrdDet.CustomerOrder.CustomerOrderID });
        }

        // GET: OrderDetails/Delete/5
        // Code that finds the information to delete books off of their order
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.CustomerOrderDetails
                .FirstOrDefaultAsync(m => m.CustomerOrderDetailID == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            CustomerOrder ord = _context.CustomerOrders.FirstOrDefault(o => o.CustomerOrderDetails.Any(od => od.CustomerOrderDetailID == id));
            var orderDetail = await _context.CustomerOrderDetails.FindAsync(id);
            _context.CustomerOrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Orders", new { id = ord.CustomerOrderID });
        }

        private bool OrderDetailExists(int id)
        {
            return _context.CustomerOrderDetails.Any(e => e.CustomerOrderDetailID == id);
        }
    }
}
