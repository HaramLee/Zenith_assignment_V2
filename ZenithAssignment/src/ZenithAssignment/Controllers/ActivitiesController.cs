using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithAssignment.Data;
using ZenithAssignment.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenithAssignment.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ActivitiesController : Controller
    {
        private ApplicationDbContext _context;

        public ActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_context.Activities.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Activity activity)
        {
            if (ModelState.IsValid)
            {
                activity.DateCreated = DateTime.Today;
                _context.Activities.Add(activity);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activity);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Activity _activity = _context.Activities.Where(s => s.ActivityId == id).FirstOrDefault();
            if (_activity == null)
            {
                return NotFound();
            }
            ViewBag.activity = _activity;
            return View(_activity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind(include: "ActivityId,ActivityDec,DateCreated")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                activity.DateCreated = DateTime.Today;
                _context.Entry(activity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activity);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Activity _activity = _context.Activities.SingleOrDefault(s => s.ActivityId == id);
            if (_activity == null)
            {
                return NotFound();
            }
            _context.Activities.Remove(_activity);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
