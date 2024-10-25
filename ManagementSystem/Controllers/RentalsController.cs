using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManagementSystem.Data;
using ManagementSystem.Models;

namespace ManagementSystem.Controllers
{
    public class RentalsController : Controller
    {
        private readonly AppDbContext _context;

        public RentalsController(AppDbContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Rental.Include(r => r.Costumer).Include(r => r.Vehicle);
            return View(await appDbContext.ToListAsync());
        }

       
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rental
                .Include(r => r.Costumer)
                .Include(r => r.Vehicle)
                .FirstOrDefaultAsync(m => m.RentalId == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

     
        public IActionResult Create()
        {
            ViewData["CostumerId"] = new SelectList(_context.Costumer, "CostumerId", "CostumerCPF");
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "VehicleLicensePlate");
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentalId,CostumerId,VehicleId,RentalStart,RentalEnd,RentalPrince,RentalDiscount,RentalStatus,RentalPaymentStatus")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                rental.RentalId = Guid.NewGuid();
                _context.Add(rental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CostumerId"] = new SelectList(_context.Costumer, "CostumerId", "CostumerCPF", rental.CostumerId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "VehicleLicensePlate", rental.VehicleId);
            return View(rental);
        }

        // GET: Rentals/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rental.FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }
            ViewData["CostumerId"] = new SelectList(_context.Costumer, "CostumerId", "CostumerCPF", rental.CostumerId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "VehicleLicensePlate", rental.VehicleId);
            return View(rental);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("RentalId,CostumerId,VehicleId,RentalStart,RentalEnd,RentalPrince,RentalDiscount,RentalStatus,RentalPaymentStatus")] Rental rental)
        {
            if (id != rental.RentalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rental);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalExists(rental.RentalId))
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
            ViewData["CostumerId"] = new SelectList(_context.Costumer, "CostumerId", "CostumerCPF", rental.CostumerId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "VehicleLicensePlate", rental.VehicleId);
            return View(rental);
        }

        // GET: Rentals/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rental
                .Include(r => r.Costumer)
                .Include(r => r.Vehicle)
                .FirstOrDefaultAsync(m => m.RentalId == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var rental = await _context.Rental.FindAsync(id);
            if (rental != null)
            {
                _context.Rental.Remove(rental);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalExists(Guid id)
        {
            return _context.Rental.Any(e => e.RentalId == id);
        }
        public class AluguelController : Controller
        {

                
                }
            }
        }
    

        

    

