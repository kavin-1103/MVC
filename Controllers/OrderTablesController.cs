using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Reservation_Management.Data;
using Reservation_Management.Models;

namespace Reservation_Management.Controllers
{
    public class OrderTablesController : Controller
    {
        private readonly RestaurantMigrationDbContext _context;

        public OrderTablesController(RestaurantMigrationDbContext context)
        {
            _context = context;
        }

        // GET: OrderTables
        public async Task<IActionResult> Index()
        {
              return _context.OrderTables != null ? 
                          View(await _context.OrderTables.ToListAsync()) :
                          Problem("Entity set 'RestaurantMigrationDbContext.OrderTables'  is null.");
        }

        // GET: OrderTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderTables == null)
            {
                return NotFound();
            }

            var orderTable = await _context.OrderTables
                .FirstOrDefaultAsync(m => m.TableId == id);
            if (orderTable == null)
            {
                return NotFound();
            }

            return View(orderTable);
        }

        // GET: OrderTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TableId,IsBooked")] OrderTable orderTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderTable);
        }

        // GET: OrderTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderTables == null)
            {
                return NotFound();
            }

            var orderTable = await _context.OrderTables.FindAsync(id);
            if (orderTable == null)
            {
                return NotFound();
            }
            return View(orderTable);
        }

        // POST: OrderTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TableId,IsBooked")] OrderTable orderTable)
        {
            if (id != orderTable.TableId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    orderTable.IsBooked = true;

                    _context.Update(orderTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderTableExists(orderTable.TableId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction("Index", "OrderItems", new { tableId = id });
        }

        // GET: OrderTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderTables == null)
            {
                return NotFound();
            }

            var orderTable = await _context.OrderTables
                .FirstOrDefaultAsync(m => m.TableId == id);
            if (orderTable == null)
            {
                return NotFound();
            }

            return View(orderTable);
        }

        // POST: OrderTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderTables == null)
            {
                return Problem("Entity set 'RestaurantMigrationDbContext.OrderTables'  is null.");
            }
            var orderTable = await _context.OrderTables.FindAsync(id);
            if (orderTable != null)
            {
                _context.OrderTables.Remove(orderTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        

        private bool OrderTableExists(int id)
        {
          return (_context.OrderTables?.Any(e => e.TableId == id)).GetValueOrDefault();
        }
    }
}
