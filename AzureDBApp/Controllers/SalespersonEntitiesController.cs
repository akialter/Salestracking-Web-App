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
    public class SalespersonEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalespersonEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SalespersonEntities
        public async Task<IActionResult> Index()
        {
            if (_context.Salespersons == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Salespersons' is null.");
            }

            var salespersons = await _context.Salespersons.ToListAsync();

            return View(salespersons);
        }

        // GET: SalespersonEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Salespersons == null)
            {
                return NotFound();
            }

            var salespersonEntity = await _context.Salespersons
                .FirstOrDefaultAsync(m => m.SalespersonId == id);
            if (salespersonEntity == null)
            {
                return NotFound();
            }

            return View(salespersonEntity);
        }

        // GET: SalespersonEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        private bool IsDuplicateKeyError(DbUpdateException ex)
        {
            var sqlException = ex.InnerException as SqlException;
            return sqlException != null && sqlException.Number == 2601; // Error code for unique constraint violation
        }

        // POST: SalespersonEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalespersonId,FirstName,LastName,Address,Phone,StartDate,TerminationDate,Manager")] SalespersonEntity salespersonEntity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(salespersonEntity);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException ex)
            {
                if (IsDuplicateKeyError(ex))
                {
                    TempData["ErrorMessage"] = "A salesperson with the same phone number already exists.";
                }
            }

            return View(salespersonEntity);
        }

        // GET: SalespersonEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Salespersons == null)
            {
                return NotFound();
            }

            var salespersonEntity = await _context.Salespersons.FindAsync(id);
            if (salespersonEntity == null)
            {
                return NotFound();
            }
            return View(salespersonEntity);
        }

        // POST: SalespersonEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalespersonId,FirstName,LastName,Address,Phone,StartDate,TerminationDate,Manager")] SalespersonEntity salespersonEntity)
        {
            if (id != salespersonEntity.SalespersonId)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(salespersonEntity);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SalespersonEntityExists(salespersonEntity.SalespersonId))
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
            }
            catch (DbUpdateException ex)
            {
                if (IsDuplicateKeyError(ex))
                {
                    TempData["ErrorMessage"] = "A salesperson with the same phone number already exists.";
                }
            }

            return View(salespersonEntity);
        }

        // GET: SalespersonEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Salespersons == null)
            {
                return NotFound();
            }

            var salespersonEntity = await _context.Salespersons
                .FirstOrDefaultAsync(m => m.SalespersonId == id);
            if (salespersonEntity == null)
            {
                return NotFound();
            }

            return View(salespersonEntity);
        }

        // POST: SalespersonEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Salespersons == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Salespersons'  is null.");
            }
            var salespersonEntity = await _context.Salespersons.FindAsync(id);
            if (salespersonEntity != null)
            {
                _context.Salespersons.Remove(salespersonEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalespersonEntityExists(int id)
        {
          return (_context.Salespersons?.Any(e => e.SalespersonId == id)).GetValueOrDefault();
        }
    }
}
