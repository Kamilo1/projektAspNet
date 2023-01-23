using projektAspNet.Models;
using Microsoft.EntityFrameworkCore;
namespace projektAspNet.Service
{
    public class CustomersServiceEF : ICustomersService
    {
        private readonly AppDbContext _context;

        public CustomersServiceEF(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Customer>> ListCustomers()
        {
            return await _context.Customers.ToListAsync();
        }
        public Customer FindBy(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException("Wrong id");
            }
            var customer = _context.Customers.Find(id);
            if (customer is not null)
            {
                return customer;
            }
            throw new ArgumentNullException("Wrong customer");
        }
        public Customer CreateCustomer(Customer customer)
        {
            Customer c = new Customer()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Pesel = customer.Pesel,
                Telephone = customer.Telephone,
                CompanyName = customer.CompanyName
            };
            return c;
        }
        public int Save(Customer customer)
        {
            var entityEntry = _context.Customers.Add(customer);
            _context.SaveChanges();
            return entityEntry.Entity.Id;
        }
        public bool Update(Customer customer)
        {
            var onecustomer = _context.Customers.Find(customer.Id);
            if (onecustomer is not null)
            {
                onecustomer.Id = customer.Id;
                onecustomer.FirstName = customer.FirstName;
                onecustomer.LastName = customer.LastName;
                onecustomer.Pesel = customer.Pesel;
                onecustomer.Telephone = customer.Telephone;
                onecustomer.CompanyName = customer.CompanyName;
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
            var onecustomer = _context.Customers.Find(id);
            if (onecustomer is not null)
            {
                _context.Customers.Remove(onecustomer);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
