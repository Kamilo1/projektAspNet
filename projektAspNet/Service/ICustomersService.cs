using projektAspNet.Models;

namespace projektAspNet.Service
{
    public interface ICustomersService
    {
        public Task<ICollection<Customer>> ListCustomers();
        public Customer FindBy(int? id);
        public Customer CreateCustomer(Customer customer);
        public int Save(Customer customer);
        public bool Update(Customer customer);
        public bool Delete(int? id);
    }
}
