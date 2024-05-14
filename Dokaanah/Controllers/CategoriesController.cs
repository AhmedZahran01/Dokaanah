using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dokaanah.Models;
using Dokaanah.Repositories.RepoInterfaces;
using Dokaanah.Repositories.RepoClasses;

namespace Dokaanah.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesRepo _categoryRepo;

        public CategoriesController(ICategoriesRepo categoriesRepo)
        {
            _categoryRepo = categoriesRepo;
        }

        public IActionResult Get_all()
        {
           // Get all products from all categories
            var allProducts = _categoryRepo.GetAllProductsForAllCategories();
            return View(allProducts);
        }

        // GET Categories/Products/{categoryId}
        public IActionResult GetProductsForCategory(int categoryId)
        {
            var products = _categoryRepo.GetProductsForCategory(categoryId);
            return View(products); 
        }



        //public IActionResult Get_all()
        //{
        //    // Example: Get all products from all categories
        //    var allProducts = categoriesRepo1.GetAllProductsFromAllCategories();
        //    return View(allProducts);
        //}

        //// GET: Categories/GetProductsByCategory/5
        //public async Task<IActionResult> GetProductsByCategory(int id)
        //{
        //    if (id == 0)
        //    {
        //        return NotFound();
        //    }

        //    var category = categoriesRepo1.GetprodByCatId(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(category);
        //}



        //// GET: Categories
        //public async Task<IActionResult> Index()
        //{
        //    var ca = categoriesRepo1.GetprodByCatId(1);
        //    return View(ca);
        //}

        //// GET: Categories/Details/5
        //public async Task<IActionResult> Details(int id)
        //{
        //    if (id == 0)
        //    {
        //        return NotFound();
        //    }

        //    var category = categoriesRepo1.GetById(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(category);
        //}

        //// GET: Categories/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Categories/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,Description,Icon")] Category category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        categoriesRepo1.insert(category);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(category);
        //}

        //// GET: Categories/Edit/5
        //public async Task<IActionResult> Edit(int id)
        //{
        //    if (id == 0)
        //    {
        //        return NotFound();
        //    }

        //    var category = categoriesRepo1.GetById(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(category);
        //}

        //// POST: Categories/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Icon")] Category category)
        //{
        //    if (id != category.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            categoriesRepo1.update(category);
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CategoryExists(category.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(category);
        //}

        //// GET: Categories/Delete/5
        //public async Task<IActionResult> Delete(int id)
        //{
        //    if (id == 0)
        //    {
        //        return NotFound();
        //    }

        //    var category =  categoriesRepo1.GetById(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(category);
        //}

        //// POST: Categories/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var category = categoriesRepo1.GetById(id);
        //    if (category != null)
        //    {
        //       categoriesRepo1.delete(category);
        //    }

        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CategoryExists(int id)
        //{
        //    return categoriesRepo1.GetAll().Any(e => e.Id == id);
        //}
    }
}
