using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace projektAspNet.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Route> Routes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>().HasData(
               new Customer() { Id = 1, FirstName = "Robert", LastName = "Kowalski", Pesel = "11111111111", CompanyName = "MSI", NIP = "1111111111" },
               new Customer() { Id = 2, FirstName = "Marcin", LastName = "Zając", Pesel = "22222222222", CompanyName = "Acer", NIP = "2222222222" },
               new Customer() { Id = 3, FirstName = "Fabian", LastName = "Nowak", Pesel = "33333333333" , CompanyName = "Intel", NIP = "3333333333" }
                );
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation() { Id = 1, RouteID = 1, CustomerID = 1, KayakType = "pojedynczy", NumberOfKayaks = 3 },
                new Reservation() { Id = 2, RouteID = 2, CustomerID = 2, KayakType = "podwójny", NumberOfKayaks = 4 },
                new Reservation() { Id = 3, RouteID = 3, CustomerID = 3, KayakType = "pojedynczy", NumberOfKayaks = 2 }
                );
            modelBuilder.Entity<Route>().HasData(
                new Route() { Id = 1, RouteName = "wadowice-witanowice" },
                new Route() { Id = 2, RouteName = "wadowice-woźniki" },
                new Route() { Id = 3, RouteName = "wadowice-grodzisko" },
                new Route() { Id = 4, RouteName = "witanowice-woźniki" },
                new Route() { Id = 5, RouteName = "witanowice-grodzisko" },
                new Route() { Id = 6, RouteName = "woźniki-grodzisko" }
                );
            modelBuilder.Entity<Reservation>()
                .HasOne<Customer>(c => c.Customer)
                .WithMany(r => r.Reservation)
                .HasForeignKey(r => r.CustomerID);
            modelBuilder.Entity<Reservation>()
               .HasOne<Route>(c => c.Route)
               .WithMany(r => r.Reservation)
               .HasForeignKey(r => r.RouteID);
        }
    }
}
//Install-Package Microsoft.EntityFrameworkCore