using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AzureDBApp.DB;
using AzureDBApp.Models;

namespace AzureDBApp.Controllers
{
    public class CustomerEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustomerEntities
        public async Task<IActionResult> Index()
        {
              return _context.Customers != null ? 
                          View(await _context.Customers.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Customers'  is null.");
        }

        // GET: CustomerEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customerEntity = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customerEntity == null)
            {
                return NotFound();
            }

            return View(customerEntity);
        }

        // GET: CustomerEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FirstName,LastName,Address,Phone,StartDate")] CustomerEntity customerEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerEntity);
        }

        // GET: CustomerEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customerEntity = await _context.Customers.FindAsync(id);
            if (customerEntity == null)
            {
                return NotFound();
            }
            return View(customerEntity);
        }

        // POST: CustomerEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstName,LastName,Address,Phone,StartDate")] CustomerEntity customerEntity)
        {
            if (id != customerEntity.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerEntityExists(customerEntity.CustomerId))
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
            return View(customerEntity);
        }

        // GET: CustomerEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customerEntity = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customerEntity == null)
            {
                return NotFound();
            }

            return View(customerEntity);
        }

        // POST: CustomerEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Customers'  is null.");
            }
            var customerEntity = await _context.Customers.FindAsync(id);
            if (customerEntity != null)
            {
                _context.Customers.Remove(customerEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerEntityExists(int id)
        {
          return (_context.Customers?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
    }
}
