using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,RouteName,Difficulty,Route_Length")] Models.Route @route)
        {

            _routesService.Save(@route);
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Edit(int? id)
        {
            var route = _routesService.FindBy(id);
            return route is null ? NotFound() : View(route);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,RouteName,Difficulty,Route_Length")] Models.Route @route)
        {

            _routesService.Update(@route);
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var route = _routesService.FindBy(id);
            return route is null ? NotFound() : View(route);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_routesService.Delete(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return Problem("Trying delete no existing route");
        }
        /* private readonly AppDbContext _context;

         public RoutesController(AppDbContext context)
         {
             _context = context;
         }

         // GET: Routes
         public async Task<IActionResult> Index()
         {
               return View(await _context.Routes.ToListAsync());
         }

         // GET: Routes/Details/5
         public async Task<IActionResult> Details(int? id)
         {
             if (id == null || _context.Routes == null)
             {
                 return NotFound();
             }

             var route = await _context.Routes
                 .FirstOrDefaultAsync(m => m.Id == id);
             if (route == null)
             {
                 return NotFound();
             }

             return View(route);
         }

         // GET: Routes/Create
         public IActionResult Create()
         {
             return View();
         }

         // POST: Routes/Create
         // To protect from overposting attacks, enable the specific properties you want to bind to.
         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Create([Bind("Id,RouteName,Difficulty,Route_Length")] Models.Route route)
         {
             if (ModelState.IsValid)
             {
                 _context.Add(route);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
             return View(route);
         }

         // GET: Routes/Edit/5
         public async Task<IActionResult> Edit(int? id)
         {
             if (id == null || _context.Routes == null)
             {
                 return NotFound();
             }

             var route = await _context.Routes.FindAsync(id);
             if (route == null)
             {
                 return NotFound();
             }
             return View(route);
         }

         // POST: Routes/Edit/5
         // To protect from overposting attacks, enable the specific properties you want to bind to.
         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Edit(int id, [Bind("Id,RouteName,Difficulty,Route_Length")] Models.Route route)
         {
             if (id != route.Id)
             {
                 return NotFound();
             }

             if (ModelState.IsValid)
             {
                 try
                 {
                     _context.Update(route);
                     await _context.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!RouteExists(route.Id))
                     {
                         return NotFound();
                     }
                     else
                     {
                         throw;
                     }
                 }
                 return RedirectToAction(nameof(Index));
             }
             return View(route);
         }

         // GET: Routes/Delete/5
         public async Task<IActionResult> Delete(int? id)
         {
             if (id == null || _context.Routes == null)
             {
                 return NotFound();
             }

             var route = await _context.Routes
                 .FirstOrDefaultAsync(m => m.Id == id);
             if (route == null)
             {
                 return NotFound();
             }

             return View(route);
         }

         // POST: Routes/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> DeleteConfirmed(int id)
         {
             if (_context.Routes == null)
             {
                 return Problem("Entity set 'AppDbContext.Routes'  is null.");
             }
             var route = await _context.Routes.FindAsync(id);
             if (route != null)
             {
                 _context.Routes.Remove(route);
             }

             await _context.SaveChangesAsync();
             return RedirectToAction(nameof(Index));
         }

         private bool RouteExists(int id)
         {
           return _context.Routes.Any(e => e.Id == id);
         }*/
    }
}
