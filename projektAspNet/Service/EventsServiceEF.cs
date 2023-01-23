using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projektAspNet.Models;


namespace projektAspNet.Service
{
    public class EventsServiceEF : IEventsService
    {
        private readonly AppDbContext _context;
        
    public EventsServiceEF(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Event>> ListEvents()
        {
            return await _context.Events.ToListAsync();
        }
        public Event FindBy(int? id)
        {
            if(id is null)
            {
                throw new ArgumentNullException("Wrong id");
            }    
            var events = _context.Events.Find(id);
            if(events is not null)
            {
                return events;
            }
            throw new ArgumentNullException("Wrong event");
        }
        public Event CreateEvent(Event events)
        {
            Event e = new Event()
            {
                EventName = events.EventName,
                DateOfEvent = events.DateOfEvent,
                Event_Location = events.Event_Location
            };
            return e;
        }
        public int Save(Event events)
        {
            var entityEntry = _context.Events.Add(events);
            _context.SaveChanges();
            return entityEntry.Entity.Id;
        }
        public bool Update(Event events)
        {
            var oneevent = _context.Events.Find(events.Id);
            if (oneevent is not null)
            {
                oneevent.EventName = events.EventName;
                oneevent.DateOfEvent = events.DateOfEvent;
                oneevent.Event_Location = events.Event_Location;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int? id)
        {
            if (id is null)
            {
                return false;
            }
            var oneevent = _context.Events.Find(id);
            if (oneevent is not null)
            {
                _context.Events.Remove(oneevent);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
