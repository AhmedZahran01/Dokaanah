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
    public class PaymentsController : Controller
    {
        private readonly IPaymentRepo paymentRepo;
        private readonly ICustomersRepo customersRepo1;

        public PaymentsController(IPaymentRepo context , ICustomersRepo customersRepo)
        {
            paymentRepo = context;
            customersRepo1 = customersRepo;
        }

        // GET: Payments
        public  IActionResult Index()
        {
            var dokkanahContex10 = paymentRepo.GetAll();
            return View( dokkanahContex10);
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var payment = paymentRepo.GetById(id);  
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public IActionResult Create()
        {
            ViewData["Customerid"] = new SelectList(customersRepo1.GetAll(), "Id", "Id");
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,Method,Customerid")] Payment payment)
        {
            if (ModelState.IsValid)
            {
              paymentRepo.insert( payment );
                return RedirectToAction(nameof(Index));
            }
            ViewData["Customerid"] = new SelectList(customersRepo1.GetAll(), "Id", "Id", payment.Customerid);
            return View(payment);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var payment = paymentRepo.GetById(id);
            if (payment == null)
            {
                return NotFound();
            }
            ViewData["Customerid"] = new SelectList(customersRepo1.GetAll(), "Id", "Id", payment.Customerid);
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,Method,Customerid")] Payment payment)
        {
            if (id != payment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   paymentRepo.update( payment );
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.Id))
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
            ViewData["Customerid"] = new SelectList(customersRepo1.GetAll(), "Id", "Id", payment.Customerid);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var payment = paymentRepo.GetById(id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payment = paymentRepo.GetById(id);
            if (payment != null)
            {
               paymentRepo.delete( payment );
            }

           
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(int id)
        {
            return paymentRepo.GetAll().Any(e => e.Id == id);
        }
    }
}
