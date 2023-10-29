using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AzureDBApp.DB;
using AzureDBApp.Models;
using Microsoft.Data.SqlClient;

namespace AzureDBApp.Controllers
{
    public class SalesEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SalesEntities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sales.Include(s => s.Customer).Include(s => s.Product).Include(s => s.Salesperson);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SalesEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sales == null)
            {
                return NotFound();
            }

            var salesEntity = await _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Product)
                .Include(s => s.Salesperson)
                .FirstOrDefaultAsync(m => m.SalesId == id);
            if (salesEntity == null)
            {
                return NotFound();
            }

            return View(salesEntity);
        }

        // GET: SalesEntities/Create
        public IActionResult Create()
        {
            var customersList = _context.Customers
                .Select(c => new SelectListItem { Value = c.CustomerId.ToString(), Text = c.FirstName + " " + c.LastName })
                .ToList();
            var productsList = _context.Products
                .Select(p => new SelectListItem { Value = p.ProductId.ToString(), Text = p.Name + ", " + p.Manufacturer })
                .ToList();
            var salespersonsList = _context.Salespersons
                .Select(s => new SelectListItem { Value = s.SalespersonId.ToString(), Text = s.FirstName + " " + s.LastName + " " + s.Phone })
                .ToList();

            ViewData["CustomerId"] = new SelectList(customersList, "Value", "Text");
            ViewData["ProductId"] = new SelectList(productsList, "Value", "Text");
            ViewData["SalespersonId"] = new SelectList(salespersonsList, "Value", "Text");
            return View();
        }
        private bool IsDuplicateKeyError(DbUpdateException ex)
        {
            var sqlException = ex.InnerException as SqlException;
            return sqlException != null && sqlException.Number == 2601; // Error code for unique constraint violation
        }

        // POST: SalesEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesId,ProductId,SalespersonId,CustomerId, SalesDate")] SalesEntity salesEntity)
        {
            // Add view scene should the operation is not successful
            var customersList = _context.Customers
                .Select(c => new SelectListItem { Value = c.CustomerId.ToString(), Text = c.FirstName + " " + c.LastName })
                .ToList();
            var productsList = _context.Products
                .Select(p => new SelectListItem { Value = p.ProductId.ToString(), Text = p.Name + ", " + p.Manufacturer })
                .ToList();
            var salespersonsList = _context.Salespersons
                .Select(s => new SelectListItem { Value = s.SalespersonId.ToString(), Text = s.FirstName + " " + s.LastName + " " + s.Phone })
                .ToList();

            ViewData["CustomerId"] = new SelectList(customersList, "Value", "Text");
            ViewData["ProductId"] = new SelectList(productsList, "Value", "Text");
            ViewData["SalespersonId"] = new SelectList(salespersonsList, "Value", "Text");

            // Retrieve the selected Product, Customer, and Salesperson using their IDs
            var product = _context.Products.FirstOrDefault(p => p.ProductId == salesEntity.ProductId);
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == salesEntity.CustomerId);
            var salesperson = _context.Salespersons.FirstOrDefault(s => s.SalespersonId == salesEntity.SalespersonId);

            if (product != null && customer != null && salesperson != null)
            {
                // Assign the selected entities to the SalesEntity properties
                salesEntity.Product = product;
                salesEntity.Customer = customer;
                salesEntity.Salesperson = salesperson;

                // Add the salesEntity to the context and save changes
                _context.Add(salesEntity);

                // Also catch key constraints (duplicate entry)
                try
                {
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateException ex)
                {
                    if (IsDuplicateKeyError(ex))
                    {
                        TempData["ErrorMessage"] = "A duplicated sale already exists.";
                    }

                    return View();
                }

                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Could not find the associated Id(s). Please try again.";
            
            return View();
        }

        // GET: SalesEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sales == null)
            {
                return NotFound();
            }

            var salesEntity = await _context.Sales.FindAsync(id);
            if (salesEntity == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", salesEntity.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name", salesEntity.ProductId);
            ViewData["SalespersonId"] = new SelectList(_context.Salespersons, "SalespersonId", "SalespersonId", salesEntity.SalespersonId);
            return View(salesEntity);
        }

        // POST: SalesEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalesId,ProductId,SalespersonId,CustomerId,SalesDate")] SalesEntity salesEntity)
        {
            if (id != salesEntity.SalesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesEntityExists(salesEntity.SalesId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", salesEntity.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name", salesEntity.ProductId);
            ViewData["SalespersonId"] = new SelectList(_context.Salespersons, "SalespersonId", "SalespersonId", salesEntity.SalespersonId);
            return View(salesEntity);
        }

        // GET: SalesEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sales == null)
            {
                return NotFound();
            }

            var salesEntity = await _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Product)
                .Include(s => s.Salesperson)
                .FirstOrDefaultAsync(m => m.SalesId == id);
            if (salesEntity == null)
            {
                return NotFound();
            }

            return View(salesEntity);
        }

        // POST: SalesEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sales == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SalesEntity'  is null.");
            }
            var salesEntity = await _context.Sales.FindAsync(id);
            if (salesEntity != null)
            {
                _context.Sales.Remove(salesEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesEntityExists(int id)
        {
          return (_context.Sales?.Any(e => e.SalesId == id)).GetValueOrDefault();
        }
    }
}
