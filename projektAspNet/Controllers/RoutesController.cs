using System;
using System.Collections.Generic;
using System.Data;
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
    public class RoutesController : Controller
    {
        private readonly IRoutesService _routesService;
        public RoutesController(AppDbContext context, IRoutesService routesService)
        {
            _routesService = routesService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _routesService.ListRoutes());
        }
        public IActionResult Details(Models.Route route)
        {
            var oneroute = _routesService.FindBy(route.Id);
            return oneroute is null ? NotFound() : View(oneroute);
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost,Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,RouteName,Difficulty,Route_Length")] Models.Route @route)
        {

            _routesService.Save(@route);
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int? id)
        {
            var route = _routesService.FindBy(id);
            return route is null ? NotFound() : View(route);
        }
        [HttpPost,Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,RouteName,Difficulty,Route_Length")] Models.Route @route)
        {

            _routesService.Update(@route);
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var route = _routesService.FindBy(id);
            return route is null ? NotFound() : View(route);
        }
        [HttpPost, ActionName("Delete"),Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_routesService.Delete(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return Problem("Trying delete no existing route");
        }
    }
}
