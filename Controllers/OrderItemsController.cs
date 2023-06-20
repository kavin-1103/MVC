using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using Reservation_Management.Data;
using Reservation_Management.Models;

namespace Reservation_Management.Controllers
{
    public class OrderItemsController : Controller
    {
        private readonly RestaurantMigrationDbContext _context;

        public OrderItemsController(RestaurantMigrationDbContext context)
        {
            _context = context;
        }

        // GET: OrderItems
        public async Task<IActionResult> Index()
        {
            int tableId = int.Parse(Request.Query["tableId"]);

            ViewData["TableId"] = tableId;
;
            var menuListData = _context.MenuItems;
   


            return View(menuListData);

        }


        // GET: OrderItems/Details/5
        

        // GET: OrderItems/Create
        public IActionResult Create()
        {
            ViewData["MenuItemID"] = new SelectList(_context.MenuItems, "MenuID", "MenuID");
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "OrderID");
            return View();
        }
       

        // POST: OrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderItems == null)
            {
                return Problem("Entity set 'RestaurantMigrationDbContext.OrderItems'  is null.");
            }
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem != null)
            {
                _context.OrderItems.Remove(orderItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Dictionary<int, int> quantities,int tableId)
        {
            foreach (var entry in quantities)
            {
                int menuId = entry.Key;
                int quantity = entry.Value;

                // Retrieve the corresponding MenuItem based on the menuId
                var menuItem = _context.MenuItems.FirstOrDefault(item => item.MenuID == menuId);

                if (menuItem != null && quantity>0)
                {
                    // Create a new OrderItem and set the properties
                    var orderItem = new OrderItem
                    {

                        ItemName = menuItem.Name, // Set the ItemName from the MenuItem
                        Price = menuItem.Price,
                        TableId = tableId,
                        Quantity = quantity
                    };

                    // Add the new OrderItem to the database
                    _context.OrderItems.Add(orderItem);
                }
            }

            // Save the changes to the database
            _context.SaveChanges();

            // Redirect to the Index action of the Reservation controller
            return RedirectToAction("Create", "Reservations", new {tableId = tableId});
        }


        [HttpPost]
        public ActionResult CalculateTotal(IEnumerable<MenuWithQuantity> menuItemsWithQuantity)
        {


            decimal total = 0;

            foreach (var menuItemWithQuantity in menuItemsWithQuantity)
            {
                total += menuItemWithQuantity.MenuItem.Price * menuItemWithQuantity.Quantity;
            }

            ViewBag.Total = total;

            //RedirectToAction("Index");
            Console.WriteLine($"Total: {total}");

            //return $"Total: {total}";
            return View("Index", menuItemsWithQuantity);
        }

       


        private bool OrderItemExists(int id)
        {
          return (_context.OrderItems?.Any(e => e.OrderItemId == id)).GetValueOrDefault();
        }
    }
}
