using Dokaanah.Models;
using Dokaanah.Repositories.RepoInterfaces;
using Dokaanah.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Dokaanah.Controllers
{
    public class CartProductController : Controller
    {
        private readonly ICartProductRepo _cartproductRepo;
        private readonly IProductsRepo _productRepo;

        public CartProductController(ICartProductRepo cartproductRepo, IProductsRepo productsRepo)
        {
            _cartproductRepo = cartproductRepo;
            _productRepo = productsRepo;
        }

        public IActionResult AddProductToCart(int Id)
        {
            var dbcontext = new Dokkanah2Contex();
            var prd = dbcontext.Products.FirstOrDefault(x => x.Id == Id);

            var cartitems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();

            var existingcartitem = cartitems.FirstOrDefault(item => item.Product.Id == Id);
            if (existingcartitem != null)
            {
                existingcartitem.Quantity++;
            }
            else
            {
                cartitems.Add(new ShoppingCartItem
                {
                    Product = prd,
                    Quantity = 1
                });
            }
            HttpContext.Session.Set("Cart", cartitems);
            return RedirectToAction("ViewCart");
        }

        [HttpGet]
        
        public IActionResult ViewCart()
        {
            var cartitems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();

            var cartitemviewmodel = new shoppingCartViewModel
            {
                CartItems = cartitems,
                TotalPrice = cartitems.Sum(item => item.Product.Price * item.Quantity),
                TotalQuantity = cartitems.Sum(item => item.Quantity)
            };

            return View(cartitemviewmodel);
        }

        public IActionResult Checkout()
        {
            var cartitems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();

            var cartitemviewmodel = new shoppingCartViewModel
            {
                CartItems = cartitems,
                TotalPrice = cartitems.Sum(item => item.Product.Price * item.Quantity)
            };
            ViewBag.totalprice = cartitemviewmodel.TotalPrice;
            return View(cartitemviewmodel);
        }

        [HttpPost]
        public IActionResult RemoveProductFromCart(int productId)
        {
            var cartitems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart");
            var itemToRemove = cartitems?.FirstOrDefault(item => item.Product.Id == productId);

            if (itemToRemove != null)
            {
                cartitems.Remove(itemToRemove);
                HttpContext.Session.Set("Cart", cartitems);
            }

            return RedirectToAction("ViewCart");
        }

        [HttpPost]
        public IActionResult UpdateCartProductQuantity(int productId, int quantity)
        {
            var cartitems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart");
            var cartItem = cartitems?.FirstOrDefault(item => item.Product.Id == productId);

            if (cartItem != null)
            {
                if (quantity <= 0)
                {
                    cartitems.Remove(cartItem);
                }
                else
                {
                    cartItem.Quantity = quantity;
                }
                HttpContext.Session.Set("Cart", cartitems);
            }

            return Ok();
        }

        public IActionResult paymientAction()
        {
            var cartitems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();

            var cartitemviewmodel = new shoppingCartViewModel
            {
                CartItems = cartitems,
                TotalPrice = cartitems.Sum(item => item.Product.Price * item.Quantity)
            };
            ViewBag.totalprice = cartitemviewmodel.TotalPrice;
            return View();  
        }

        
        public IActionResult paymientsucces()
        {
            return View();
        }

    }
}
