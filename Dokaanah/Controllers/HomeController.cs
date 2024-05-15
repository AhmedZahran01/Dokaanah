using Dokaanah.Models;
using Dokaanah.Repositories.RepoClasses;
using Dokaanah.Repositories.RepoInterfaces;
using Dokaanah.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dokaanah.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProduct_CategoryRepo product_CategoryRepo;
        private readonly ICategoriesRepo categoriesRepo;
        private readonly IProductsRepo productsRepo;

        public HomeController(IProduct_CategoryRepo _product_CategoryRepo, ICategoriesRepo categoriesRepo, IProductsRepo productsRepo)
        {
            product_CategoryRepo = _product_CategoryRepo;
            this.categoriesRepo = categoriesRepo;
            this.productsRepo = productsRepo;
        }

        public IActionResult Index()
        {
            var randomProducts = productsRepo.GetRandomProducts(5);
            return View(randomProducts);
        }

        public IActionResult Shop(string catName)
        {
            var allproductsWithCats = product_CategoryRepo.GetAll();
            var allcategories = categoriesRepo.GetAll().ToList();
            ViewBag.cats = allcategories;
            catName  = string.IsNullOrEmpty(catName) ? "all" : catName;
            ViewData["catName"] = catName;
            return View(allproductsWithCats);
        }
        public IActionResult aboutUs()
        {
            return View(); 
        }

        public IActionResult contantUs()
        {
            return View();
        }
       
        public IActionResult UserAccount()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult FAQ()
        {
            return View();
        }
    }
}
