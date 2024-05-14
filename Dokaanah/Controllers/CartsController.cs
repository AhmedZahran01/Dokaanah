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
    public class CartsController : Controller
    {
        private readonly ICartRepo _cartRepo;

        public CartsController(ICartRepo cartRepo)
        {
            _cartRepo = cartRepo;
        }

        // GET: CartController
        public ActionResult Index()
        
        {
            var carts = _cartRepo.GetAll();
            return View(carts);
        }

        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            var cart = _cartRepo.GetDetails(id);
            if (cart == null)
            {
                return NotFound();
            }
            return View(cart);
        }

        public ActionResult Create()
        {
            return View();
        }

        // GET: CartController/Create
        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cart cart)
        {
            if (ModelState.IsValid)
            {
                _cartRepo.Insert(cart);
                return RedirectToAction(nameof(Index));
            }
            return View(cart);
        }

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            var cart = _cartRepo.GetDetails(id);
            if (cart == null)
            {
                return NotFound();
            }
            return View(cart);
        }

        // POST: CartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cart cart)
        {
            if (id != cart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _cartRepo.Update(cart);
                }
                catch (InvalidOperationException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cart);
        }

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            var cart = _cartRepo.GetDetails(id);
            if (cart == null)
            {
                return NotFound();
            }
            return View(cart);
        }

        // POST: CartController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Cart cart)
        {
            try
            {
                _cartRepo.Delete(cart);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

    }
}