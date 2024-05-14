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
    public class product_customerController : Controller
    {
        private readonly Iproduct_customerRepo product_Customer1;

        public product_customerController(Iproduct_customerRepo product_Customer)
        {
            product_Customer1 = product_Customer;
        }

        // GET: product_customer
        public  IActionResult Index()
        {
            var dokkanah2Contex = product_Customer1.GetAll();
            return View( dokkanah2Contex.ToList() ) ;
        }


        public IActionResult TopProductsRandmly()
        {
            var x = product_Customer1.GetTopProducts ();
            return View(x);
        }


        //// GET: product_customer/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product_customer = await _context.Prod_Custs
        //        .Include(p => p.Cust)
        //        .Include(p => p.Prud)
        //        .FirstOrDefaultAsync(m => m.PrudId == id);
        //    if (product_customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product_customer);
        //}

        // GET: product_customer/Create
        //public IActionResult Create()
        //{
        //    ViewData["CustId"] = new SelectList(_context.Customer1s, "Id", "Id");
        //    ViewData["PrudId"] = new SelectList(_context.Products, "Id", "Id");
        //    return View();
        //}

        //// POST: product_customer/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("CustId,PrudId,Comment,Rating")] product_customer product_customer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(product_customer);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CustId"] = new SelectList(_context.Customer1s, "Id", "Id", product_customer.CustId);
        //    ViewData["PrudId"] = new SelectList(_context.Products, "Id", "Id", product_customer.PrudId);
        //    return View(product_customer);
        //}

        //// GET: product_customer/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product_customer = await _context.Prod_Custs.FindAsync(id);
        //    if (product_customer == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["CustId"] = new SelectList(_context.Customer1s, "Id", "Id", product_customer.CustId);
        //    ViewData["PrudId"] = new SelectList(_context.Products, "Id", "Id", product_customer.PrudId);
        //    return View(product_customer);
        //}

        //// POST: product_customer/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("CustId,PrudId,Comment,Rating")] product_customer product_customer)
        //{
        //    if (id != product_customer.PrudId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(product_customer);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!product_customerExists(product_customer.PrudId))
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
        //    ViewData["CustId"] = new SelectList(_context.Customer1s, "Id", "Id", product_customer.CustId);
        //    ViewData["PrudId"] = new SelectList(_context.Products, "Id", "Id", product_customer.PrudId);
        //    return View(product_customer);
        //}

        //// GET: product_customer/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product_customer = await _context.Prod_Custs
        //        .Include(p => p.Cust)
        //        .Include(p => p.Prud)
        //        .FirstOrDefaultAsync(m => m.PrudId == id);
        //    if (product_customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product_customer);
        //}

        //// POST: product_customer/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var product_customer = await _context.Prod_Custs.FindAsync(id);
        //    if (product_customer != null)
        //    {
        //        _context.Prod_Custs.Remove(product_customer);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool product_customerExists(int id)
        //{
        //    return _context.Prod_Custs.Any(e => e.PrudId == id);
        //}
    }
}
