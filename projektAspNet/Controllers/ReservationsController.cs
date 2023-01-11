using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projektAspNet.Models;

namespace projektAspNet.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly AppDbContext _context;
        public ReservationsController(AppDbContext context)
        {
            _context = context;
        }
        // GET: ReservationsController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reservations.ToListAsync());
        }

        // GET: ReservationsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReservationsController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReservationsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RouteID,CustomerID,KayakType,NumberOfKayaks")] Reservation reservation)
        {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: ReservationsController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        // POST: ReservationsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[Bind("Id,RouteID,CustomerID,KayakType,NumberOfKayaks")] Reservation reservation)
        {
           
                
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        

        // GET: ReservationsController/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: ReservationsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
