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
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>().HasData(
               new Customer() { Id = 1, FirstName = "Robert", LastName = "Kowalski", Pesel = "11111111111", Telephone = "010101010", CompanyName = "MSI", NIP = "1111111111" },
               new Customer() { Id = 2, FirstName = "Marcin", LastName = "Zając", Pesel = "22222222222", Telephone = "020202020", CompanyName = "Acer", NIP = "2222222222" },
               new Customer() { Id = 3, FirstName = "Fabian", LastName = "Nowak", Pesel = "33333333333", Telephone = "030303030", CompanyName = "Intel", NIP = "3333333333" }
                );
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation() { Id = 1, RouteID = 1, CustomerID = 1, DateOfKayaking = DateTime.Parse("2001-10-25"), KayakType = "pojedynczy", NumberOfKayaks = 3 },
                new Reservation() { Id = 2, RouteID = 2, CustomerID = 2, DateOfKayaking = DateTime.Parse("2000-11-09"), KayakType = "podwójny", NumberOfKayaks = 4 },
                new Reservation() { Id = 3, RouteID = 3, CustomerID = 3, DateOfKayaking = DateTime.Parse("2002-12-17"), KayakType = "pojedynczy", NumberOfKayaks = 2 }
                );
            modelBuilder.Entity<Route>().HasData(
                new Route() { Id = 1, RouteName = "wadowice-witanowice", Difficulty = "Bardzo zaawansowana", Route_Length = "4km" },
                new Route() { Id = 2, RouteName = "wadowice-woźniki", Difficulty = "Zaawansowana", Route_Length = "5,5km" },
                new Route() { Id = 3, RouteName = "wadowice-grodzisko", Difficulty = "Zaawansowana", Route_Length = "8km" },
                new Route() { Id = 4, RouteName = "witanowice-woźniki", Difficulty = "Średnio zaawansowana", Route_Length = "6km" },
                new Route() { Id = 5, RouteName = "witanowice-grodzisko", Difficulty = "Łatwa", Route_Length = "4km" },
                new Route() { Id = 6, RouteName = "woźniki-grodzisko", Difficulty = "Bardzo łatwa", Route_Length = "2,5km" }
                );
            modelBuilder.Entity<Event>().HasData(
                new Event() { Id = 1, EventName = "Czyszczenie rzeki Skawy", DateOfEvent = DateTime.Parse("2001-10-25"), Event_Location = "Wadowice" },
                new Event() { Id = 2, EventName = "Dwudniowy spływ Wisłą", DateOfEvent = DateTime.Parse("2001-11-12"), Event_Location = "Spytkowice" },
                new Event() { Id = 3, EventName = "Nocny spływ Wisłą", DateOfEvent = DateTime.Parse("2001-05-17"), Event_Location = "Spytkowice" },
                new Event() { Id = 4, EventName = "Wielki spływ z jeziora żywieckiego", DateOfEvent = DateTime.Parse("2001-09-08"), Event_Location = "Żywiec" }
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