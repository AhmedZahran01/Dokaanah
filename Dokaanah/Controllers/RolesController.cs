using Dokaanah.Models;
using Dokaanah.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace Dokaanah.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager=roleManager;
        }



        // GET: Customers
        public async Task<IActionResult> Index(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                var Roles = await roleManager.Roles.Select(R => new RoleViewModel()
                {
                    Id = R.Id,
                    RoleName = R.Name
                }).ToListAsync();

                return View(Roles);
            }
            else
            {
                var Role = await roleManager.FindByNameAsync(name);
                var mappedRole = new RoleViewModel()
                {
                    Id = Role.Id,
                    RoleName = Role.Name
                };
                return View(new List<RoleViewModel>() { mappedRole });
            }
        }

        //GET: Customers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolesm = await roleManager.FindByIdAsync(id);
            if (rolesm == null)
            {
                return NotFound();
            }
            var MappedRoles = await roleManager.Roles.Select(R => new RoleViewModel()
            {
                Id = R.Id,
                RoleName = R.Name
            }).ToListAsync();


            return View(MappedRoles);
        }


        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            return View();
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,RoleName")] RoleViewModel UpdateeRole)
        {
            if (id != UpdateeRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var Role = await roleManager.FindByIdAsync(id);
                    Role.Name = UpdateeRole.RoleName;
                    await roleManager.UpdateAsync(Role);
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(UpdateeRole);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleName")] RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create a single IdentityRole instance from the RoleViewModel
                var identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                // Use the RoleManager to create the role
                var result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                // If the creation failed, add the errors to the ModelState
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }


    }
}
