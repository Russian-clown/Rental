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
    public class EngineSpecificationsController : Controller
    {
        private readonly AppDbContext _context;

        public EngineSpecificationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EngineSpecifications
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.EngineSpecifications.Include(e => e.FuelInjection);
            return View(await appDbContext.ToListAsync());
        }

        // GET: EngineSpecifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engineSpecification = await _context.EngineSpecifications
                .Include(e => e.FuelInjection)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (engineSpecification == null)
            {
                return NotFound();
            }

            return View(engineSpecification);
        }

        // GET: EngineSpecifications/Create
        public IActionResult Create()
        {
            ViewData["FuelInjectionId"] = new SelectList(_context.FuelInjections, "Id", "Value");
            return View();
        }

        // POST: EngineSpecifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Volume,CylindersCount,FuelType,Power,FuelInjectionId,CO2Blowout,Torque")] EngineSpecification engineSpecification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(engineSpecification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuelInjectionId"] = new SelectList(_context.FuelInjections, "Id", "Value", engineSpecification.FuelInjectionId);
            return View(engineSpecification);
        }

        // GET: EngineSpecifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engineSpecification = await _context.EngineSpecifications.FindAsync(id);
            if (engineSpecification == null)
            {
                return NotFound();
            }
            ViewData["FuelInjectionId"] = new SelectList(_context.FuelInjections, "Id", "Value", engineSpecification.FuelInjectionId);
            return View(engineSpecification);
        }

        // POST: EngineSpecifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Volume,CylindersCount,FuelType,Power,FuelInjectionId,CO2Blowout,Torque")] EngineSpecification engineSpecification)
        {
            if (id != engineSpecification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(engineSpecification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EngineSpecificationExists(engineSpecification.Id))
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
            ViewData["FuelInjectionId"] = new SelectList(_context.FuelInjections, "Id", "Value", engineSpecification.FuelInjectionId);
            return View(engineSpecification);
        }

        // GET: EngineSpecifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engineSpecification = await _context.EngineSpecifications
                .Include(e => e.FuelInjection)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (engineSpecification == null)
            {
                return NotFound();
            }

            return View(engineSpecification);
        }

        // POST: EngineSpecifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var engineSpecification = await _context.EngineSpecifications.FindAsync(id);
            _context.EngineSpecifications.Remove(engineSpecification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EngineSpecificationExists(int id)
        {
            return _context.EngineSpecifications.Any(e => e.Id == id);
        }
    }
}
