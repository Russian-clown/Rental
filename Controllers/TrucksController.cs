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
    public class TrucksController : Controller
    {
        private readonly AppDbContext _context;

        public TrucksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Trucks
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Trucks
                .Include(t => t.Brand)
                .Include(t => t.Color)
                .Include(t => t.CarBody)
                .Include(t => t.Engine);
            return View(await appDbContext.ToListAsync()); // возращаем представление сущности!!!!
        }

        // GET: Trucks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truck = await _context.Trucks
                .Include(t => t.Brand)
                .Include(t => t.Color)
                .Include(t => t.CarBody)
                .Include(t => t.Engine)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (truck == null)
            {
                return NotFound();
            }

            return View(truck);// возращаем представление сущности
        }

        // GET: Trucks/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name");
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Name");
            ViewData["EngineId"] = new SelectList(_context.EngineSpecifications, "Id", "Name");
            return View();
        }

        // POST: Trucks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BrandId,Mileage,FuelTankCapacity,ColorId,CarBodyNum,Lenght,Width,Height,Base,SeatsCount,VIN,EngineSpecificationsId")] TruckViewModel truck)
        {
            if (ModelState.IsValid)
            {
                Truck tr = new Truck()
                {
                    BrandId = truck.BrandId,
                    Mileage = truck.Mileage,
                    FuelTankCapacity = truck.FuelTankCapacity,
                    ColorId = truck.ColorId
                };
                _context.Trucks.Add(tr);
                await _context.SaveChangesAsync();

                CarBody cb = new CarBody()
                {
                    TruckId = tr.Id,
                    CarBodyNum = truck.CarBodyNum,
                    Lenght = truck.Lenght,
                    Width = truck.Width,
                    Height = truck.Height,
                    Base = truck.Base,
                    SeatsCount = truck.SeatsCount
                };
                _context.CarBodies.Add(cb);

                Engine en = new Engine()
                {
                    TruckId = tr.Id,
                    VIN = truck.VIN,
                    EngineSpecificationsId = truck.EngineSpecificationsId
                };
                _context.Engines.Add(en);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));//Перенаправляет заданное действие, используя имя действия.
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", truck.BrandId);
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Name", truck.ColorId);
            ViewData["EngineId"] = new SelectList(_context.EngineSpecifications, "Id", "Name");
            return View(truck);
        }

        // GET: Trucks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var truck = await _context.Trucks.FindAsync(id);//Обнаруживает сущность с указанным значением первичного ключа
            var body = await _context.CarBodies.FindAsync(id);
            var engine = await _context.Engines.FindAsync(id);

            if (truck == null)
            {
                return NotFound();
            }

            TruckViewModel model = new TruckViewModel()
            {
                Id = truck.Id,
                BrandId = truck.BrandId,
                Mileage = truck.Mileage,
                FuelTankCapacity = truck.FuelTankCapacity,
                ColorId = truck.ColorId,
                CarBodyNum = body.CarBodyNum,
                Lenght = body.Lenght,
                Width = body.Width,
                Height = body.Height,
                Base = body.Base,
                SeatsCount = body.SeatsCount,
                VIN = engine.VIN,
                EngineSpecificationsId = engine.EngineSpecificationsId
            };

            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", truck.BrandId);
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Name", truck.ColorId);
            ViewData["EngineId"] = new SelectList(_context.EngineSpecifications, "Id", "Name");
            return View(model);
        }

        // POST: Trucks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BrandId,Mileage,FuelTankCapacity,ColorId,CarBodyNum,Lenght,Width,Height,Base,SeatsCount,VIN,EngineSpecificationsId")] TruckViewModel truckVm)
        {
            if (id != truckVm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var truck = await _context.Trucks.FindAsync(id);
                    var body = await _context.CarBodies.FindAsync(id);
                    var engine = await _context.Engines.FindAsync(id);

                    truck.BrandId = truckVm.BrandId;
                    truck.Mileage = truckVm.Mileage;
                    truck.FuelTankCapacity = truckVm.FuelTankCapacity;
                    truck.ColorId = truckVm.ColorId;

                    body.CarBodyNum = truckVm.CarBodyNum;
                    body.Lenght = truckVm.Lenght;
                    body.Width = truckVm.Width;
                    body.Height = truckVm.Height;
                    body.Base = truckVm.Base;
                    body.SeatsCount = truckVm.SeatsCount;

                    engine.VIN = truckVm.VIN;
                    engine.EngineSpecificationsId = truckVm.EngineSpecificationsId;

                    _context.Update(truck);
                    _context.Update(body);
                    _context.Update(engine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TruckExists(truckVm.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", truckVm.BrandId);
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Name", truckVm.ColorId);
            ViewData["EngineId"] = new SelectList(_context.EngineSpecifications, "Id", "Name", truckVm.EngineSpecificationsId);
            return View(truckVm);
        }

        // GET: Trucks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truck = await _context.Trucks
                .Include(t => t.Brand)
                .Include(t => t.Color)
                .Include(t => t.CarBody)
                .Include(t => t.Engine)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (truck == null)
            {
                return NotFound();
            }

            return View(truck);
        }

        // POST: Trucks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var truck = await _context.Trucks.FindAsync(id);
            var body = await _context.CarBodies.FindAsync(id);
            var engine = await _context.Engines.FindAsync(id);
            _context.Trucks.Remove(truck);
            _context.CarBodies.Remove(body);
            _context.Engines.Remove(engine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TruckExists(int id)
        {
            return _context.Trucks.Any(e => e.Id == id);
        }
    }
}
