using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using projektAspNet.Models;
using projektAspNet.Service;

namespace projektAspNet.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventsService _eventsService;
        public EventsController(AppDbContext context, IEventsService eventsService)
        {
            _eventsService = eventsService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _eventsService.ListEvents());
        }
        public  IActionResult Details(Event events)
        {
            var oneevent = _eventsService.FindBy(events.Id);
            return oneevent is null ? NotFound() : View(oneevent);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,EventName,DateOfEvent,Event_Location")] Event @event)
        {
                if (ModelState.IsValid)
                {
                    _eventsService.Save(@event);
                    return RedirectToAction(nameof(Index));
                }
            return View(@event);
        }
        public IActionResult Edit(int? id)
        {
            var events = _eventsService.FindBy(id);
            return events is null ? NotFound() : View(events);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, [Bind("Id,EventName,DateOfEvent,Event_Location")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _eventsService.Update(@event);
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var events = _eventsService.FindBy(id);
            return events is null ? NotFound() : View(events);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_eventsService.Delete(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return Problem("Trying delete no existing event");
        }

        
    }
}
