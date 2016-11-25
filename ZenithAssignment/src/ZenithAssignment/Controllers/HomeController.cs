using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithAssignment.Data;
using ZenithAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace ZenithAssignment.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;

        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var today = DateTime.Now;
            var events = db.Events.Include(a => a.Activity).Include(b => b.ApplicationUser);
            var stuff = events.ToList();
            var send = new List<Event>();
            var datelist = new List<String>();
            var someDay = today;
            var week = new TimeSpan(6, 23, 59, 59);

            if (today.DayOfWeek != DayOfWeek.Monday)
            {
                while (true)
                {
                    someDay = someDay.AddDays(-1);            //go backwards 1 day
                    if (someDay.DayOfWeek == DayOfWeek.Monday)
                    {
                        break;
                    }
                }
            }

            var lastMonday = someDay.Date;
            foreach (var x in stuff)
            {

                if (x.FromDate >= lastMonday && x.FromDate <= lastMonday + week && x.IsActive == true)
                {

                    if (!datelist.Contains(x.FromDate.ToString("dddd MMMM dd,yyyy")))
                        datelist.Add(x.FromDate.ToString("dddd MMMM dd,yyyy"));

                    send.Add(x);

                }
            }

            List<Event> SortedList = send.OrderBy(o => o.FromDate).ToList();

            var orderedList = datelist.OrderBy(x => DateTime.Parse(x)).ToList();

            ViewData["MyData"] = orderedList;

            return View(SortedList);
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
