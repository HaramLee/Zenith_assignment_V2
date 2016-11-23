using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithAssignment.Data;
using ZenithAssignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenithAssignment.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EventsController : Controller
    {
        private ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var events = _context.Events.Include(a => a.Activity).Include(b => b.ApplicationUser);
            return View(events.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event e)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(e);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

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

            //ViewBag.ActivityId = new SelectList(db.Activities, "ActivityId", "ActivityDec", @event.ActivityId);
            //ViewBag.Id = new SelectList(db.Users, "Id", "UserName", @event.Id);
            ViewBag.e = e;
            return View(e);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind(include: "EventId,ActivityId,DateCreated,FromDate,Id,IsActive,ToDate")] Event e)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(e).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
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
