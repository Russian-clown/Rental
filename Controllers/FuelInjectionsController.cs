using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRental.Models;

namespace CarRental.Controllers
{
    public class FuelInjectionsController : Controller
    {
        private readonly AppDbContext _context;

        public FuelInjectionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: FuelInjections
        public async Task<IActionResult> Index()
        {
            return View(await _context.FuelInjections.ToListAsync());
        }

        // GET: FuelInjections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelInjection = await _context.FuelInjections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fuelInjection == null)
            {
                return NotFound();
            }

            return View(fuelInjection);
        }

        // GET: FuelInjections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FuelInjections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Value")] FuelInjection fuelInjection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fuelInjection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fuelInjection);
        }

        // GET: FuelInjections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelInjection = await _context.FuelInjections.FindAsync(id);
            if (fuelInjection == null)
            {
                return NotFound();
            }
            return View(fuelInjection);
        }

        // POST: FuelInjections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Value")] FuelInjection fuelInjection)
        {
            if (id != fuelInjection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fuelInjection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuelInjectionExists(fuelInjection.Id))
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
            return View(fuelInjection);
        }

        // GET: FuelInjections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelInjection = await _context.FuelInjections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fuelInjection == null)
            {
                return NotFound();
            }

            return View(fuelInjection);
        }

        // POST: FuelInjections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fuelInjection = await _context.FuelInjections.FindAsync(id);
            _context.FuelInjections.Remove(fuelInjection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuelInjectionExists(int id)
        {
            return _context.FuelInjections.Any(e => e.Id == id);
        }
    }
}
