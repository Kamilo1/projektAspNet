using Microsoft.AspNetCore.Mvc;
using projektAspNet.Models;

namespace projektAspNet.Service
{
    public interface IEventsService
    {
        public Task<ICollection<Event>> ListEvents();
        public Event FindBy(int? id);
        public Event CreateEvent(Event events);
        public int Save(Event events);
        public bool Update(Event events);
        public bool Delete(int? id);



    }
}
