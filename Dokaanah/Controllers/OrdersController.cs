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
    public class OrdersController : Controller
    {
        private readonly IOrdersRepo ordersRepo1;
        private readonly ICustomersRepo customersRepo;

        public OrdersController(IOrdersRepo ordersRepo , ICustomersRepo productsRepo)
        {
            ordersRepo1 = ordersRepo;
            customersRepo = productsRepo;
        }

        // GET: Orders
        public IActionResult Index()
        {
            var dokkanahContex10 = ordersRepo1.GetAll();
            return View( dokkanahContex10);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var order = ordersRepo1.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["Customerid"] = new SelectList(customersRepo.GetAll(), "Id", "Id");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Date,Amount,TotalPrice,PhoneNumber,Status,Customerid,Customer")] Order order)
        {
            if (ModelState.IsValid)
            {
                ordersRepo1.insert(order);
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["Customerid"] = new SelectList(customersRepo.GetAll(), "Id", "Id", order.Customerid);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = ordersRepo1.GetType();
            if (order == null)
            {
                return NotFound();
            }
            ViewData["Customerid"] = new SelectList(customersRepo.GetAll(), "Id", "Id", order);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Amount,TotalPrice,PhoneNumber,Status,Customerid")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ordersRepo1.update(order);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["Customerid"] = new SelectList(customersRepo.GetAll(), "Id", "Id", order.Customerid);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var order = ordersRepo1.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = ordersRepo1.GetById(id);
            if (order != null)
            {
                ordersRepo1.delete(order);
            }

            
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return ordersRepo1.GetAll().Any(e => e.Id == id);
        }
    }
}
