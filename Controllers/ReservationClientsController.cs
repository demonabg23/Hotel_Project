using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel_Project_Marti_i_Stanko.Data;
using Hotel_Project_Marti_i_Stanko.Models;

namespace Hotel_Project_Marti_i_Stanko.Controllers
{
    public class ReservationClientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReservationClients
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ReservationClients.Include(r => r.Client).Include(r => r.Reservation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ReservationClients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationClient = await _context.ReservationClients
                .Include(r => r.Client)
                .Include(r => r.Reservation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservationClient == null)
            {
                return NotFound();
            }

            return View(reservationClient);
        }

        // GET: ReservationClients/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "firstName");
            ViewData["ReservationId"] = new SelectList(_context.Reservations, "Id", "Id");
            return View();
        }

        // POST: ReservationClients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReservationId,ClientId")] ReservationClient reservationClient)
        {
            var client = await _context.Clients.FindAsync(reservationClient.ClientId);
            var @reservation = await _context.Reservations.FindAsync(reservationClient.ReservationId);

            if (client == null || reservation == null)
            {
                return NotFound();
            }

            var contains = _context.ReservationClients
                .Any(ea => ea.ReservationId == reservation.Id && ea.ClientId == client.Id);

            if (!contains)
            {
                reservation.ReservationClients.Add(new ReservationClient()
                {
                    ClientId = client.Id,
                    ReservationId = @reservation.Id
                });
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


            /*
            if (ModelState.IsValid)
            {
                _context.Add(reservationClient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "firstName", reservationClient.ClientId);
            ViewData["ReservationId"] = new SelectList(_context.Reservations, "Id", "Id", reservationClient.ReservationId);
            return View(reservationClient);*/
        }

        // GET: ReservationClients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationClient = await _context.ReservationClients.FindAsync(id);
            if (reservationClient == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "firstName", reservationClient.ClientId);
            ViewData["ReservationId"] = new SelectList(_context.Reservations, "Id", "Id", reservationClient.ReservationId);
            return View(reservationClient);
        }

        // POST: ReservationClients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReservationId,ClientId")] ReservationClient reservationClient)
        {
            if (id != reservationClient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservationClient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationClientExists(reservationClient.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "firstName", reservationClient.ClientId);
            ViewData["ReservationId"] = new SelectList(_context.Reservations, "Id", "Id", reservationClient.ReservationId);
            return View(reservationClient);
        }

        // GET: ReservationClients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationClient = await _context.ReservationClients
                .Include(r => r.Client)
                .Include(r => r.Reservation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservationClient == null)
            {
                return NotFound();
            }

            return View(reservationClient);
        }

        // POST: ReservationClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservationClient = await _context.ReservationClients.FindAsync(id);
            _context.ReservationClients.Remove(reservationClient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationClientExists(int id)
        {
            return _context.ReservationClients.Any(e => e.Id == id);
        }
    }
}
