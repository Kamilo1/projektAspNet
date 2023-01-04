using Microsoft.EntityFrameworkCore;
namespace projektAspNet.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customers> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>().HasData(
               new Customers() { Id = 1, FirstName = "Robert", LastName = "Kowalski", Pesel = "11111111111", CompanyName = "MSI", NIP = "1111111111" },
               new Customers() { Id = 2, FirstName = "Marcin", LastName = "Zając", Pesel = "22222222222", CompanyName = "Acer", NIP = "2222222222" },
               new Customers() { Id = 3, FirstName = "Fabian", LastName = "Nowak", Pesel = "33333333333"}
                );
        }
    }
}
