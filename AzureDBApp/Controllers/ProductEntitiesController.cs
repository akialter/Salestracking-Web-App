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
using OfficeOpenXml;
using System.IO;
using System.Text;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using X.PagedList;

namespace AzureDBApp.Controllers
{
    public class ProductEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IValidator<ProductEntity> validator = new ProductEntityValidator();

        public ProductEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductEntities
        public async Task<IActionResult> Index(int? page)
        {
            return _context.Products != null ?
                          View(await _context.Products.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Products'  is null.");
        }

        // GET: ProductEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var productEntity = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productEntity == null)
            {
                return NotFound();
            }

            return View(productEntity);
        }

        // GET: ProductEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Name,Manufacturer,Style,PurchasePrice,SalePrice,QtyOnHand,CommissionPercentage")] ProductEntity productEntity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(productEntity);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException ex)
            {
                if (IsDuplicateKeyError(ex))
                {
                    TempData["ErrorMessage"] = "A product with the same name and manufacturer already exists.";
                }
            }

            return View(productEntity);
        }

        private bool IsDuplicateKeyError(DbUpdateException ex)
        {
            var sqlException = ex.InnerException as SqlException;
            return sqlException != null && sqlException.Number == 2601; // Error code for unique constraint violation
        }

        // GET: ProductEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var productEntity = await _context.Products.FindAsync(id);
            if (productEntity == null)
            {
                return NotFound();
            }
            return View(productEntity);
        }

        // POST: ProductEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,Manufacturer,Style,PurchasePrice,SalePrice,QtyOnHand,CommissionPercentage")] ProductEntity productEntity)
        {
            if (id != productEntity.ProductId)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(productEntity);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProductEntityExists(productEntity.ProductId))
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
                    TempData["ErrorMessage"] = "A product with the same name and manufacturer already exists.";
                }
            }
            return View(productEntity);
        }

        // GET: ProductEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var productEntity = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productEntity == null)
            {
                return NotFound();
            }

            return View(productEntity);
        }

        // POST: ProductEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
            }
            var productEntity = await _context.Products.FindAsync(id);
            if (productEntity != null)
            {
                _context.Products.Remove(productEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductEntityExists(int id)
        {
          return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                try
                {
                    using (var stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream);
                        stream.Position = 0;

                        using (var package = new ExcelPackage(stream))
                        {
                            var worksheet = package.Workbook.Worksheets[0]; // Assuming the data is on the first worksheet

                            var products = new List<ProductEntity>();

                            for (int row = 2; row <= worksheet.Dimension.End.Row; row++) // Start from row 2 to skip headers
                            {

                                var product = new ProductEntity
                                {
                                    Name = worksheet.Cells[row, 1].Value?.ToString(),
                                    Manufacturer = worksheet.Cells[row, 2].Value?.ToString(),
                                    Style = worksheet.Cells[row, 3].Value?.ToString(),
                                    PurchasePrice = decimal.TryParse(worksheet.Cells[row, 4].Value?.ToString(), out var purchasePrice) ? purchasePrice : 0,
                                    SalePrice = decimal.TryParse(worksheet.Cells[row, 5].Value?.ToString(), out var salePrice) ? salePrice : 0,
                                    QtyOnHand = int.TryParse(worksheet.Cells[row, 6].Value?.ToString(), out var qtyOnHand) ? qtyOnHand : 0,
                                    CommissionPercentage = double.TryParse(worksheet.Cells[row, 7].Value?.ToString(), out var commissionPercentage) ? commissionPercentage : 0
                                };

                                // Validate the input
                                var validationResult = validator.Validate(product);

                                foreach (var error in validationResult.Errors)
                                {
                                    Console.WriteLine($"Property: {error.PropertyName}, Error: {error.ErrorMessage}");
                                }

                                if (validationResult.IsValid)
                                {
                                    products.Add(product);
                                }
                            }

                            foreach (var product in products)
                            {
                                _context.Products.Add(product);
                                // We need to check for possible SQL constraints error
                                try
                                {
                                    await _context.SaveChangesAsync();
                                }
                                catch (DbUpdateException)
                                {
                                    Console.WriteLine($"{product.Name} caused an error");
                                    _context.Products.Remove(product);
                                }
                            }

                            TempData["SuccessMessage"] = "File uploaded and data inserted into the database.";                            
                            return RedirectToAction("Index");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Build an error message that includes the outer exception message and inner exception details
                    string errorMessage = "Error processing the file: " + ex.Message;
                    TempData["ErrorMessage"] = errorMessage;
                    return RedirectToAction("Create");
                }
            }
            TempData["ErrorMessage"] = "Please select a file to upload.";
            return RedirectToAction("Create");
        }
    }
}
