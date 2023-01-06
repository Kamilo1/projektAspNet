using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace projektAspNet.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Routes> Routes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customers>().HasData(
               new Customers() { Id = 1, FirstName = "Robert", LastName = "Kowalski", Pesel = "11111111111", CompanyName = "MSI", NIP = "1111111111" },
               new Customers() { Id = 2, FirstName = "Marcin", LastName = "Zając", Pesel = "22222222222", CompanyName = "Acer", NIP = "2222222222" },
               new Customers() { Id = 3, FirstName = "Fabian", LastName = "Nowak", Pesel = "33333333333" , CompanyName = "Intel", NIP = "3333333333" }
                );
            modelBuilder.Entity<Reservations>().HasData(
                new Reservations() { Id = 1, RouteID = 1, CustomerID = 1, KayakType = "pojedynczy", NumberOfKayaks = 3 },
                new Reservations() { Id = 2, RouteID = 2, CustomerID = 2, KayakType = "podwójny", NumberOfKayaks = 4 },
                new Reservations() { Id = 3, RouteID = 3, CustomerID = 3, KayakType = "pojedynczy", NumberOfKayaks = 2 }
                );
            modelBuilder.Entity<Routes>().HasData(
                new Routes() { Id = 1, RouteName = "wadowice-witanowice" },
                new Routes() { Id = 2, RouteName = "wadowice-woźniki" },
                new Routes() { Id = 3, RouteName = "wadowice-grodzisko" },
                new Routes() { Id = 4, RouteName = "witanowice-woźniki" },
                new Routes() { Id = 5, RouteName = "witanowice-grodzisko" },
                new Routes() { Id = 6, RouteName = "woźniki-grodzisko" }
                );
        }
    }
}
//Install-Package Microsoft.EntityFrameworkCore