using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dokaanah.Models;
using Dokaanah.Repositories.RepoInterfaces;
using Dokaanah.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Dokaanah.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomersRepo customersRepo1;
        private readonly IOrdersRepo ordersRepo1;
        private readonly UserManager<Customer> userManager1;
        private readonly SignInManager<Customer> signInManager1;

        public CustomersController(ICustomersRepo customersRepo, IOrdersRepo ordersRepo,IPaymentRepo paymentRepo,
                                      UserManager<Customer> userManager, SignInManager<Customer> signInManager)
        {
            customersRepo1 = customersRepo;
            ordersRepo1 = ordersRepo;
            this.userManager1=userManager;
            this.signInManager1=signInManager;
        }

        // GET: Customers
        public IActionResult Index()
        {

            return View(customersRepo1.GetAll());
        }

        // GET: Customers/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = customersRepo1.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewBag.OrderidList = ordersRepo1.GetAll();
            return View();
        }



        #region ahmed saeed 1 for login and register and Sign Out

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(SignUpViewModels models)
        {
            if (ModelState.IsValid)
            {
                //var userEmail = await userManager1.FindByEmailAsync( models.Email);
                //var userName = await userManager1.FindByNameAsync(models.Email);

                //if (userEmail is null)
                //{
                var userEmail = new Customer()
                {
                    UserName = models.UserName,
                    Email = models.Email,
                    Password = models.Password,
                    confirmPassword = models.confirmPassword,
                    isAgree = models.IsAgree,
                };

                var result = await userManager1.CreateAsync(userEmail, models.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index), "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            ModelState.AddModelError(string.Empty, " email is already exist");
            //}
            return View(models);

        }

        
        public async Task<IActionResult> Login(signinviewmodel models)
        {
            
            if (ModelState.IsValid)
            {

                var checkUser = await userManager1.FindByEmailAsync(models.Email);
                if (checkUser is not null)
                {
                    var flag = await userManager1.CheckPasswordAsync(checkUser, models.Password);
                    if (flag)
                    {
                        var result = await signInManager1.
                            PasswordSignInAsync(checkUser, models.Password, models.RemmeberMe, false);

                        if (result.Succeeded)
                        {
                            if(User.Identity.IsAuthenticated && User.IsInRole("Admin"))
                            {
                                return RedirectToAction(nameof(AdminDashboardController.Index), "AdminDashboard");

                            }

                            return RedirectToAction(nameof(HomeController.Index), "Home");
                        }

                    }

                }
                ModelState.AddModelError(string.Empty, " Login is Not Valid");
            }

           return RedirectToAction(nameof(HomeController.Index), "Home");

        }


        public async Task<IActionResult> SignOut(SignUpViewModels models)
        {
            await signInManager1.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");

        }


        #endregion






        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Email,Password,PhoneNumber,Address,Orderid")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customersRepo1.insert(customer);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.OrderidList = ordersRepo1.GetAll();
            return View(customer);
        }

        // GET: Customers/Edit/5
        public  IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = customersRepo1.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewBag.OrderidList = ordersRepo1.GetAll();
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("Id,Name,Email,Password,PhoneNumber,Address,Orderid")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    customersRepo1.update(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            ViewData["Orderid"] = ordersRepo1.GetAll();
            return View(customer);
        }

        // GET: Customers/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = customersRepo1.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var customer = customersRepo1.GetById(id);
            if (customer != null)
            {
                customersRepo1.delete(customer);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(string id)
        {
            return customersRepo1.GetAll().Any(e => e.Id == id);
        }
    }
}
