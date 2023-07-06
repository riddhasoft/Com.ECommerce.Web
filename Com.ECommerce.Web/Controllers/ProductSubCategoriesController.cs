using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Com.ECommerce.Web.Data;
using Com.ECommerce.Web.Models;
using Com.ECommerce.Web.Services;

namespace Com.ECommerce.Web.Controllers
{
    public class ProductSubCategoriesController : Controller
    {
        private readonly IProductSubCategoryService _service;
       

        public ProductSubCategoriesController(IProductSubCategoryService service)
        {
            
            _service = service;
           
        }

        // GET: ProductSubCategories
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
            
        }

        // GET: ProductSubCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSubCategory = await _service.GetById(id ?? 0);
               
            if (productSubCategory == null)
            {
                return NotFound();
            }

            return View(productSubCategory);
        }

        // GET: ProductSubCategories/Create
        public async Task<IActionResult> Create()
        {
            var productCategories = (await _service.ProductCategories()).ToList();
            ViewData["ProductCategories"] = new SelectList(productCategories,"Id","Name");
            return View();
        }

        // POST: ProductSubCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ProductCategoryId")] ProductSubCategory productSubCategory)
        {
            if (ModelState.IsValid)
            {
               await _service.Create(productSubCategory);
                
                return RedirectToAction(nameof(Index));
            }
            return View(productSubCategory);
        }

        // GET: ProductSubCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var productSubCategory = await _service.GetById(id ?? 0);
            if (productSubCategory == null)
            {
                return NotFound();
            }
            return View(productSubCategory);
        }

        // POST: ProductSubCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ProductCategoryId")] ProductSubCategory productSubCategory)
        {
            if (id != productSubCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                     await   _service.Update(productSubCategory);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductSubCategoryExists(productSubCategory.Id))
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
            return View(productSubCategory);
        }

        // GET: ProductSubCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var productSubCategory = await _service.GetById(id ?? 0);
               
            if (productSubCategory == null)
            {
                return NotFound();
            }

            return View(productSubCategory);
        }

        // POST: ProductSubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var productSubCategory = await _service.GetById(id);
            if (productSubCategory != null)
            {
               await _service.Delete(id);
            }
            
         
            return RedirectToAction(nameof(Index));
        }

        private bool ProductSubCategoryExists(int id)
        {
          return _service.GetById(id)!= null;
        }
    }
}
