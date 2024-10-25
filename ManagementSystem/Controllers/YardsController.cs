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
    public class YardsController : Controller
    {
        private readonly AppDbContext _context;

        public YardsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Yards
        public async Task<IActionResult> Index()
        {
            return View(await _context.Yard.ToListAsync());
        }

        // GET: Yards/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yard = await _context.Yard
                .FirstOrDefaultAsync(m => m.YardId == id);
            if (yard == null)
            {
                return NotFound();
            }

            return View(yard);
        }

        // GET: Yards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YardId,YardName,YardAddress,YardTotalCapacity,YardCurrentQuantity,YardCurrentColor")] Yard yard)
        {
            if (ModelState.IsValid)
            {
                yard.YardId = Guid.NewGuid();
                _context.Add(yard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yard);
        }

        // GET: Yards/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yard = await _context.Yard.FindAsync(id);
            if (yard == null)
            {
                return NotFound();
            }
            return View(yard);
        }

        // POST: Yards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("YardId,YardName,YardAddress,YardTotalCapacity,YardCurrentQuantity,YardCurrentColor")] Yard yard)
        {
            if (id != yard.YardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YardExists(yard.YardId))
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
            return View(yard);
        }

        // GET: Yards/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yard = await _context.Yard
                .FirstOrDefaultAsync(m => m.YardId == id);
            if (yard == null)
            {
                return NotFound();
            }

            return View(yard);
        }

        // POST: Yards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var yard = await _context.Yard.FindAsync(id);
            if (yard != null)
            {
                _context.Yard.Remove(yard);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YardExists(Guid id)
        {
            return _context.Yard.Any(e => e.YardId == id);
        }
    }
}
