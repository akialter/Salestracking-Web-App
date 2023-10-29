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
    public class DiscountEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiscountEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DiscountEntities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Discounts.Include(d => d.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DiscountEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Discounts == null)
            {
                return NotFound();
            }

            var Discounts = await _context.Discounts
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.DiscountId == id);
            if (Discounts == null)
            {
                return NotFound();
            }

            return View(Discounts);
        }

        // GET: DiscountEntities/Create
        public IActionResult Create()
        {
            var productsList = _context.Products
                .Select(p => new SelectListItem { Value = p.ProductId.ToString(), Text = p.Name + ", " + p.Manufacturer })
                .ToList();

            ViewData["ProductId"] = new SelectList(productsList, "Value", "Text");
            return View();
        }
        private bool IsDuplicateKeyError(DbUpdateException ex)
        {
            var sqlException = ex.InnerException as SqlException;
            return sqlException != null && sqlException.Number == 2601; // Error code for unique constraint violation
        }

        // POST: DiscountEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiscountId,ProductId,BeginDate,EndDate,DiscountPercentage")] DiscountEntity discountEntity)
        {
            // Add view scene should the operation is not successful
            var productsList = _context.Products
                .Select(p => new SelectListItem { Value = p.ProductId.ToString(), Text = p.Name + ", " + p.Manufacturer })
                .ToList();
            ViewData["ProductId"] = new SelectList(productsList, "Value", "Text");

            var product = _context.Products.FirstOrDefault(p => p.ProductId == discountEntity.ProductId);

            ModelState.Remove("Product"); // bad practice, remove the referneced entity, but do the trick
            if (ModelState.IsValid)
            {
                if (product != null)
                {
                    discountEntity.Product = product;
                    _context.Add(discountEntity);
                    // Also catch key constraints (duplicate entry)
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateException ex)
                    {
                        if (IsDuplicateKeyError(ex))
                        {
                            TempData["ErrorMessage"] = "A duplicated discount already exists.";
                        }

                        return View();
                    }
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "Could not find the associated Id(s). Please try again.";
                }
            }

            return View();
        }

        // GET: DiscountEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Discounts == null)
            {
                return NotFound();
            }

            var discountEntity = await _context.Discounts.FindAsync(id);
            if (discountEntity == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name", discountEntity.ProductId);
            return View(discountEntity);
        }

        // POST: DiscountEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiscountId,ProductId,BeginDate,EndDate,DiscountPercentage")] DiscountEntity discountEntity)
        {
            if (id != discountEntity.DiscountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(discountEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiscountEntityExists(discountEntity.DiscountId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name", discountEntity.ProductId);
            return View(discountEntity);
        }

        // GET: DiscountEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Discounts == null)
            {
                return NotFound();
            }

            var discountEntity = await _context.Discounts
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.DiscountId == id);
            if (discountEntity == null)
            {
                return NotFound();
            }

            return View(discountEntity);
        }

        // POST: DiscountEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Discounts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DiscountEntity'  is null.");
            }
            var discountEntity = await _context.Discounts.FindAsync(id);
            if (discountEntity != null)
            {
                _context.Discounts.Remove(discountEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiscountEntityExists(int id)
        {
          return (_context.Discounts?.Any(e => e.DiscountId == id)).GetValueOrDefault();
        }
    }
}
