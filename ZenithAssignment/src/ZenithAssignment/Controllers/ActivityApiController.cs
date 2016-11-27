using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZenithAssignment.Data;
using ZenithAssignment.Models;
using Microsoft.AspNetCore.Authorization;

namespace ZenithAssignment.Controllers
{
    [Authorize]
    [Route("api/activity")]
    public class ActivityApiController : Controller
    {

        private ApplicationDbContext _context { get; set; }

        public ActivityApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Activity
        [HttpGet]
        public IEnumerable<Activity> Get()
        {
            return _context.Activities.ToList();
        }

        // GET api/Activity/5
        [HttpGet("{id}")]
        public Activity Get(int id)
        {
            return _context.Activities.FirstOrDefault(s => s.ActivityId == id);
        }

        // POST api/Activity
        [HttpPost]
        public void Post([FromBody]Activity activity)
        {
            _context.Activities.Add(activity);
            _context.SaveChanges();
        }

        // PUT api/Activity/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Activity activity)
        {
            _context.Activities.Update(activity);
            _context.SaveChanges();
        }

        // DELETE api/Activity/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var activity = _context.Activities.FirstOrDefault(t => t.ActivityId == id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                _context.SaveChanges();
            }
        }
    }


}