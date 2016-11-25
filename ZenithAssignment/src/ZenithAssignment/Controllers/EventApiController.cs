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
    [Authorize(Roles = "Admin")]
    [Route("api/event")]
    public class EventApiController : Controller
    {

        private ApplicationDbContext _context { get; set; }

        public EventApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Event
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _context.Events.ToList();
        }

        // GET api/event/5
        [HttpGet("{id}")]
        public Event Get(int id)
        {
            return _context.Events.FirstOrDefault(s => s.EventId == id);
        }

        // POST api/event
        [HttpPost]
        public void Post([FromBody]Event events)
        {
            _context.Events.Add(events);
            _context.SaveChanges();
        }

        // PUT api/event/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Event events)
        {
            _context.Events.Update(events);
            _context.SaveChanges();
        }

        // DELETE api/event/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var events = _context.Events.FirstOrDefault(t => t.EventId == id);
            if (events != null)
            {
                _context.Events.Remove(events);
                _context.SaveChanges();
            }
        }


    }
}