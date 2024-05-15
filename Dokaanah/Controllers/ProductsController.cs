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
using Dokaanah.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Dokaanah.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepo _productRepo;
        private readonly ICategoriesRepo _categoryRepo;

        public ProductController(IProductsRepo productRepo, ICategoriesRepo categoryRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;

        }
        [Authorize]
        public IActionResult list()
        {
            // Get the list of products from the repository
            var products = _productRepo.ListProducts();

            // Pass the list of products to the view
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _productRepo.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            var categoryNames = product.Product_Categories.Select(pc => pc.C.Name).ToList();
            ViewBag.CategoryNames = categoryNames;

            return View(product);
        }

        // GET: Product/Random
        public IActionResult RandomProducts()
        {
            var randomProducts = _productRepo.GetRandomProducts(4);
            return View(randomProducts);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int cartId)
        {
            _productRepo.AddProductToCart(productId, cartId);
            return View();
        }

        public IActionResult Shop(string category)
        {
            // Fetch products based on the selected category
            var products = _productRepo.ListProducts()
                .Where(p => category == "All" || p.Product_Categories.Any(pc => pc.C.Name == category));

            // Pass the filtered products to the view
            return View(products);
        }




        #region a.saeed Create product

        // GET: Products/Create
        public IActionResult Create()
        {
            //ViewData["Orderid"] = new SelectList(ordersRepo1.GetAll(), "Id", "Id");
            //ViewData["Sellerid"] = new SelectList(sellersRepo1.GetAll(), "Id", "Id");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,Description,ImgUrl,Quantity,Sellerid,Orderid")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepo.insert(product);
                return RedirectToAction(nameof(AdminDashboardController.Index) , "AdminDashboard");
            }
            //ViewData["Orderid"] = new SelectList(ordersRepo1.GetAll(), "Id", "Id", product.Orderid);
            //ViewData["Sellerid"] = new SelectList(sellersRepo1.GetAll(), "Id", "Id", product.Sellerid);
            return View(product);
        }






        #endregion
    }
}
