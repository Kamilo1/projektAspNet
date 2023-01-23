using projektAspNet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;

namespace projektAspNet.Service
{
    public class RoutesServiceEF : IRoutesService
    {
        private readonly AppDbContext _context;

        public RoutesServiceEF(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Models.Route>> ListRoutes()
        {
            return await _context.Routes.ToListAsync();
        }
        public Models.Route FindBy(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException("Wrong id");
            }
            var route = _context.Routes.Find(id);
            if (route is not null)
            {
                return route;
            }
            throw new ArgumentNullException("Wrong event");
        }
        public Models.Route CreateRoute(Models.Route route)
        {
            Models.Route c = new Models.Route()
            {
                Id = route.Id,
                RouteName = route.RouteName,
                Difficulty = route.Difficulty,
                Route_Length = route.Route_Length   
            };
            return c;
        }
        public int Save(Models.Route route)
        {
            var entityEntry = _context.Routes.Add(route);
            _context.SaveChanges();
            return entityEntry.Entity.Id;
        }
        public bool Update(Models.Route route)
        {
            var oneroute = _context.Routes.Find(route.Id);
            if (oneroute is not null)
            {
                oneroute.Id = route.Id;
                oneroute.RouteName = route.RouteName;
                oneroute.Difficulty = route.Difficulty;
                oneroute.Route_Length = route.Route_Length;
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
            var oneroute = _context.Routes.Find(id);
            if (oneroute is not null)
            {
                _context.Routes.Remove(oneroute);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
