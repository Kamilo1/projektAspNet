using projektAspNet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using projektAspNet.Service;
using Microsoft.AspNetCore.Identity.UI.Services;
using projektAspNet.Data;
//using projektAspNet.Data;
using projektAspNet.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string 'Default' not found.");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<IdentityDbContext>(
    options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<IdentityDbContext>();


               
builder.Services.AddScoped<IEventsService, EventsServiceEF>();
builder.Services.AddScoped<ICustomersService, CustomersServiceEF>();
builder.Services.AddScoped<IRoutesService, RoutesServiceEF>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseAuthentication();;

app.Run();
public partial class Program { }