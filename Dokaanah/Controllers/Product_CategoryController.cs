using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dokaanah.Models;
using Dokaanah.Repositories.RepoInterfaces;

namespace Dokaanah.Controllers
{
    
    public class Product_CategoryController : Controller
    {
        private readonly IProduct_CategoryRepo product_Category1;

        public Product_CategoryController(IProduct_CategoryRepo product_Category)
        {
            product_Category1 = product_Category;
        }

        // GET: Product_Category
        public IActionResult Index()
        {
            var dokkanah2Contex = product_Category1.GetAll();
            return View( dokkanah2Contex.ToList());
        }

        public async Task<IActionResult> GetallproductBycategory(int id)
        {
            var dokkanah2Contex = product_Category1.GetAll();
            var vv = dokkanah2Contex.Where(c => c.Cid == id);
            var allproduct = new List<Product>();
            foreach (var item in vv)
            {
                 allproduct.Add(item.P);
            }
            return View(allproduct);
        }


    }
}
