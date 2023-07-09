using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Com.ECommerce.Web.Data;
using Com.ECommerce.Web.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.Design;
using Com.ECommerce.Web.Services;

namespace Com.ECommerce.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ECommerceDBContext _context;
        private readonly ISelectlistService _selectlistService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductsController(ECommerceDBContext context, IWebHostEnvironment webHostEnvironment, ISelectlistService selectlistService)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _selectlistService = selectlistService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return _context.Product != null ?
                        View(await _context.Product.Include(x => x.Brand)
                        .Include(x => x.ProductSubCategory)
                        .ThenInclude(x   => x.ProductCategory).ToListAsync()) :
                        Problem("Entity set 'ECommerceDBContext.Product'  is null.");
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create(int? id)
        {
            var productCategories = _selectlistService.ProductCategories().ToList();
            ViewBag.ProductCategories = new SelectList(productCategories, "Id", "Name", id);


            var productSubCategories = _selectlistService.ProductSubCategories().Where(x => x.ProductCategoryId == id).ToList();
            ViewBag.ProductSubCategories = new SelectList(productSubCategories, "Id", "Name");
            var brand = _selectlistService.Brand().ToList();
            ViewBag.Brand = new SelectList(brand, "Id", "Name");


            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Discount,ProductSubCategoryId,BrandId,Rating,ImagePhoto,Description")] Product product, List<IFormFile> files)
        {

            if (ModelState.IsValid)
            {

                //var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "/wwwroot/ProjectsPhotos");
                string uniqueFileName = "";
                if (files.Count > 0)
                {
                    var file = files[0];
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "/content/images");
                    Directory.CreateDirectory(uploadsFolder);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }

                var completedProject = new Product()
                {
                    Name = product.Name,
                    Price = product.Price,
                    Discount = product.Discount,
                    //ProductCategoryId = product.ProductCategoryId,
                    ProductSubCategoryId = product.ProductSubCategoryId,
                    BrandId = product.BrandId,
                    Rating = product.Rating,
                    ProductPhoto = uniqueFileName,


                };
                _context.Product.Add(completedProject);
                await _context.SaveChangesAsync();

                RedirectToAction("Index");

                // Save the uniqueFileName to your database or perform additional logic
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Discount,ProductCategoryId,ProductSubCategoryId,BrandId,Rating,ImageUrl,Description")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'ECommerceDBContext.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //


        private bool ProductExists(int id)
        {
            return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
