using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using projektAspNet.Areas.Identity.Data;
using System.Reflection.Emit;

namespace projektAspNet.Data;

public class IdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.Entity<IdentityRole>().HasData
           (
           new IdentityRole()
           {
               Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
               Name = "Administrator",
               ConcurrencyStamp = "1",
               NormalizedName = "ADMINISTRATOR"
           }
           );
        var hashing = new PasswordHasher<ApplicationUser>();
        builder.Entity<ApplicationUser>().HasData
            (
            new ApplicationUser()
            {
                Id = "d57a3861-3c43-4ed0-86c1-c6f604a3afe7",
                EmailConfirmed = true,
                Email = "wojtek.nowak@wp.pl",
                NormalizedEmail = "WOJTEK.NOWAK@WP.PL",
                LockoutEnabled = true,
                UserName = "wojtek.nowak@wp.pl",
                NormalizedUserName = "wojtek.nowak@wp.pl",
                PasswordHash = hashing.HashPassword(null, "zaq1@WSX")
            }
            );
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                UserId = "d57a3861-3c43-4ed0-86c1-c6f604a3afe7"
            }
            );
    }
}
