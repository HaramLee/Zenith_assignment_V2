using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ZenithAssignment.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ZenithAssignment.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenithAssignment.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private ApplicationDbContext _context;
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;

        public RolesController(ApplicationDbContext context, RoleManager<IdentityRole> r, UserManager<ApplicationUser> u)
        {
            _context = context;
            roleManager = r;
            userManager = u;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var users = _context.Users;

            ViewBag.roleStuff = roleManager.Roles;
            return View(users.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RolesModel role)
        {
            if(role == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                if (!await roleManager.RoleExistsAsync(role.name))
                {
                    await roleManager.CreateAsync(new IdentityRole(role.name));
                    return RedirectToAction("Index");
                }
            }
            return View(role);
        }

        public ActionResult AddUser(string id)
        {
            ViewBag.name = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser([Bind(include: "Id,AccessFailedCount,ConcurrencyStamp,Email,EmailConfirmed,FirstName,LastName,LockoutEnabled,LockoutEnd,NormalizedEmail,NormalizedUserName,PasswordHash,PhoneNumber,PhoneNumberConfirmed,SecurityStamp,TwoFactorEnabled,UserName,newRoleId")] ApplicationUser appUser)
        {
            if(appUser == null)
            {
                return NotFound();
            }
            if(appUser.UserName == null)
            {
                return View();
            }
            var userToChange = await userManager.FindByNameAsync(appUser.UserName);
            await userManager.AddToRoleAsync(userToChange, appUser.newRoleId);
            return RedirectToAction("Index");
        }
        
        public ActionResult RemoveUser(string id)
        {
            if(id == null)
            {
                return NotFound();
            }
            ViewBag.name = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveUser([Bind(include: "Id,AccessFailedCount,ConcurrencyStamp,Email,EmailConfirmed,FirstName,LastName,LockoutEnabled,LockoutEnd,NormalizedEmail,NormalizedUserName,PasswordHash,PhoneNumber,PhoneNumberConfirmed,SecurityStamp,TwoFactorEnabled,UserName,newRoleId")] ApplicationUser appUser)
        {
            if(appUser == null)
            {
                return NotFound();
            }
            if (appUser.UserName == null)
            {
                return View();
            }
            var userToChange = await userManager.FindByNameAsync(appUser.UserName);
            if(userToChange == null)
            {
                return NotFound();
            }
            await userManager.RemoveFromRoleAsync(userToChange, appUser.newRoleId);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            if(id == null)
            {
                return NotFound();
            }
            ViewBag.name = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RolesModel role)
        {
            if(role == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                IdentityRole old = await roleManager.FindByNameAsync(role.priorRole);
                old.Name = role.name;
                await roleManager.UpdateAsync(old);
                return RedirectToAction("Index");
            }
            return View(role);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if(id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                IdentityRole old = await roleManager.FindByNameAsync(id);
                await roleManager.DeleteAsync(old);
            }
            return RedirectToAction("Index");
        }
    }
}
