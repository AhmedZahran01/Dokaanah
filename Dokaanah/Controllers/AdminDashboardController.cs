using Dokaanah.Repositories.RepoInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dokaanah.Controllers
{
    [Authorize(Roles="Admin")]
    //AdminDashboard
    public class AdminDashboardController : Controller
    {
        #region controllers 
        
        
        private readonly ICustomersRepo customersRepo;
        private readonly IProductsRepo productsRepo;

        public AdminDashboardController(ICustomersRepo customersRepo, IProductsRepo productsRepo)
        {
            this.customersRepo=customersRepo;
            this.productsRepo=productsRepo;
        } 
       
        #endregion
        public IActionResult Index()
        {
            ViewBag.customerCount = customersRepo.GetAll().Count();
            ViewBag.ProductCount = productsRepo.GetAll().Count();
         

            return View(productsRepo.GetAll());
        }
    }
}







      





