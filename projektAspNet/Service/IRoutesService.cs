using projektAspNet.Models;

namespace projektAspNet.Service
{
    public interface IRoutesService
    {
        public Task<ICollection<Models.Route>> ListRoutes();
        public Models.Route FindBy(int? id);
        public Models.Route CreateRoute(Models.Route route);
        public int Save(Models.Route route);
        public bool Update(Models.Route route);
        public bool Delete(int? id);
    }
}
