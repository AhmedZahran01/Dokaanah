using Dokaanah.Models;
using Dokaanah.Repositories.RepoClasses;
using Dokaanah.Repositories.RepoInterfaces;
using Dokaanah.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace Dokaanah.Controllers
{

    public class CartProductController : Controller
    {
        private readonly ICartProductRepo _cartproductRepo;
        private readonly IProductsRepo _productRepo;
        private List<ShoppingCartitem> _cartitems;
        public CartProductController(ICartProductRepo cartproductRepo, IProductsRepo productsRepo)
        {
            _cartproductRepo = cartproductRepo;
            _productRepo = productsRepo;
            _cartitems = new List<ShoppingCartitem>();
        }


        public IActionResult AddProductToCart(int Id)
        {
            var dbcontext = new Dokkanah2Contex();


            var prd = dbcontext.Products.FirstOrDefault(x => x.Id == Id);

            var cartitems = HttpContext.Session.Get<List<ShoppingCartitem>>("Cart") ?? new List<ShoppingCartitem>();

            var existingcartitem = _cartitems.FirstOrDefault(item => item.product.Id == Id);
            if (existingcartitem != null)
            {
                existingcartitem.Quantity++;
            }
            else
            {
                cartitems.Add(new ShoppingCartitem
                {
                    product = prd,
                    Quantity = 1
                });
            }
            HttpContext.Session.Set("Cart", cartitems);
            return RedirectToAction("ViewCart");
        }

        [HttpGet]

        public IActionResult ViewCart(int Quantity)
        {
            var cartitems = HttpContext.Session.Get<List<ShoppingCartitem>>("Cart").ToList(); // ?? new List<ShoppingCartitem>();

            var cartitemviewmodel = new shoppingCartViewModel
            {
                CartItems = cartitems.Select(e => e.product).ToList(),
                TotalPrice = cartitems.Sum(item => item.product.Price * item.Quantity)
            };

            return View(cartitemviewmodel);
        }

        public IActionResult Checkout()
        {
            var cartitems = HttpContext.Session.Get<List<ShoppingCartitem>>("Cart").ToList(); // ?? new List<ShoppingCartitem>();

            var cartitemviewmodel = new shoppingCartViewModel
            {
                CartItems = cartitems.Select(e => e.product).ToList(),
                TotalPrice = cartitems.Sum(item => item.product.Price * item.Quantity)
            };
            ViewBag.totalprice = cartitemviewmodel.TotalPrice;
            return View(cartitemviewmodel);

        }

        //List<Product> products = _productRepo.GetRandomProducts(5);
        //try
        //{
        //    // Check if the product already exists in the cart
        //    var existingCartItem = _cartproductRepo.GetCartItem(productId, cartId);
        //    if (existingCartItem != null)
        //    {
        //        // If the product already exists, increment its quantity
        //        existingCartItem.ProductItemsNumbers++;
        //        _cartproductRepo.UpdateCartItem(existingCartItem);
        //    }
        //    else
        //    {
        //        // If the product does not exist, create a new cart item
        //        var newCartItem = new Cart_Product
        //        {
        //            Prid = productId,
        //            Caid = cartId,
        //            ProductItemsNumbers = 1 // Set initial quantity to 1
        //        };
        //        _cartproductRepo.AddCartItem(newCartItem);
        //    }

        //    return RedirectToAction("Index", "Cart"); // Redirect to cart page or any other page
        //}
        //catch (Exception ex)
        //{
        //    // Handle exception
        //    return StatusCode(500, "An error occurred while adding the product to the cart.");
        //}

        public IActionResult YourCart()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RemoveProductFromCart(int productId, int cartId)
        {
            try
            {
                var cartItem = _cartproductRepo.GetCartItem(productId, cartId);
                if (cartItem != null)
                {
                    _cartproductRepo.RemoveCartItem(cartItem);
                }

                return RedirectToAction("Index", "Cart"); // Redirect to cart page or any other page
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "An error occurred while removing the product from the cart.");
            }
        }

        [HttpPost]
        public IActionResult UpdateCartProductQuantity(int productId, int cartId, int quantity)
        {
            try
            {
                var cartItem = _cartproductRepo.GetCartItem(productId, cartId);
                if (cartItem != null)
                {
                    cartItem.ProductItemsNumbers = quantity;
                    _cartproductRepo.UpdateCartItem(cartItem);
                }

                return RedirectToAction("Index", "Cart"); // Redirect to cart page or any other page
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "An error occurred while updating the cart product quantity.");
            }
        }

    }
}
