using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EarthquakeHorses4.Data;
using EarthquakeHorses4.Models;

namespace EarthquakeHorses4.Controllers
{
    public class LocationMaterielsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocationMaterielsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LocationMateriels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LocationMateriel.Include(l => l.Contrat).Include(l => l.Materiel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LocationMateriels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationMateriel = await _context.LocationMateriel
                .Include(l => l.Contrat)
                .Include(l => l.Materiel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locationMateriel == null)
            {
                return NotFound();
            }

            return View(locationMateriel);
        }

        // GET: LocationMateriels/Create
        public IActionResult Create()
        {
            ViewData["ContratId"] = new SelectList(_context.Contrat, "Id", "Id");
            ViewData["MaterielId"] = new SelectList(_context.Materiel, "Id", "Id");
            return View();
        }

        // POST: LocationMateriels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContratId,MaterielId,Lieu,UserId")] LocationMateriel locationMateriel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locationMateriel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContratId"] = new SelectList(_context.Contrat, "Id", "Id", locationMateriel.ContratId);
            ViewData["MaterielId"] = new SelectList(_context.Materiel, "Id", "Id", locationMateriel.MaterielId);
            return View(locationMateriel);
        }

        // GET: LocationMateriels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationMateriel = await _context.LocationMateriel.FindAsync(id);
            if (locationMateriel == null)
            {
                return NotFound();
            }
            ViewData["ContratId"] = new SelectList(_context.Contrat, "Id", "Id", locationMateriel.ContratId);
            ViewData["MaterielId"] = new SelectList(_context.Materiel, "Id", "Id", locationMateriel.MaterielId);
            return View(locationMateriel);
        }

        // POST: LocationMateriels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContratId,MaterielId,Lieu,UserId")] LocationMateriel locationMateriel)
        {
            if (id != locationMateriel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationMateriel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationMaterielExists(locationMateriel.Id))
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
            ViewData["ContratId"] = new SelectList(_context.Contrat, "Id", "Id", locationMateriel.ContratId);
            ViewData["MaterielId"] = new SelectList(_context.Materiel, "Id", "Id", locationMateriel.MaterielId);
            return View(locationMateriel);
        }

        // GET: LocationMateriels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationMateriel = await _context.LocationMateriel
                .Include(l => l.Contrat)
                .Include(l => l.Materiel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locationMateriel == null)
            {
                return NotFound();
            }

            return View(locationMateriel);
        }

        // POST: LocationMateriels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locationMateriel = await _context.LocationMateriel.FindAsync(id);
            _context.LocationMateriel.Remove(locationMateriel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationMaterielExists(int id)
        {
            return _context.LocationMateriel.Any(e => e.Id == id);
        }
    }
}
