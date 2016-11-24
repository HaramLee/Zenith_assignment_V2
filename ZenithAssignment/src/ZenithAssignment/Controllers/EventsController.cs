using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithAssignment.Data;
using ZenithAssignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenithAssignment.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EventsController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> userManager;

        public EventsController(ApplicationDbContext context, UserManager<ApplicationUser> u)
        {
            _context = context;
            userManager = u;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var events = _context.Events.Include(a => a.Activity).Include(b => b.ApplicationUser);
            return View(events.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.ActivityStuff = (_context.Activities.ToList());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event e)
        {
            if (ModelState.IsValid)
            {
                e.ApplicationUser = await userManager.FindByNameAsync(User.Identity.Name);
                e.DateCreated = DateTime.Today;
                _context.Events.Add(e);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityStuff = (_context.Activities.ToList());
            return View(e);
        }        

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Event e = _context.Events.Where(s => s.EventId == id).FirstOrDefault();
            if (e == null)
            {
                return NotFound();
            }
            ViewBag.ActivityStuff = (_context.Activities.ToList());
            return View(e);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind(include: "EventId,ActivityId,DateCreated,FromDate,Id,IsActive,ToDate")] Event e)
        {
            if (ModelState.IsValid)
            {
                e.ApplicationUser = await userManager.FindByNameAsync(User.Identity.Name);
                _context.Entry(e).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            ViewBag.ActivityStuff = (_context.Activities.ToList());
            return View(e);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Event e = _context.Events.SingleOrDefault(s => s.EventId == id);
            if (e == null)
            {
                return NotFound();
            }
            _context.Events.Remove(e);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
