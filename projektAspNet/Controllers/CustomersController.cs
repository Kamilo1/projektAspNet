using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projektAspNet.Models;
using projektAspNet.Service;
namespace projektAspNet.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomersService _customersService;
        public CustomersController(AppDbContext context, ICustomersService customersService)
        {
            _customersService = customersService;
        }
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            return View(await _customersService.ListCustomers());
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Details(Customer customer)
        {
            var onecustomer = _customersService.FindBy(customer.Id);
            return onecustomer is null ? NotFound() : View(onecustomer);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost,Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,FirstName,LastName,Pesel,Telephone,CompanyName,NIP")] Customer @customer)
        {
            
                _customersService.Save(@customer);
                return RedirectToAction(nameof(Index));
          
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int? id)
        {
            var customer = _customersService.FindBy(id);
            return customer is null ? NotFound() : View(customer);
        }
        [HttpPost,Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,FirstName,LastName,Pesel,Telephone,CompanyName,NIP")] Customer @customer)
        {
            
                _customersService.Update(@customer);
                return RedirectToAction(nameof(Index));
            
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = _customersService.FindBy(id);
            return customer is null ? NotFound() : View(customer);
        }
        [HttpPost, ActionName("Delete"),Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_customersService.Delete(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return Problem("Trying delete no existing customer");
        }
    }
}
