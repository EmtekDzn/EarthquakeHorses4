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
    public class SceancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SceancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sceances
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sceance.Include(s => s.Contrat).Include(s => s.Cour).Include(s => s.Lieu);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sceances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sceance = await _context.Sceance
                .Include(s => s.Contrat)
                .Include(s => s.Cour)
                .Include(s => s.Lieu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sceance == null)
            {
                return NotFound();
            }

            return View(sceance);
        }

        // GET: Sceances/Create
        public IActionResult Create()
        {
            ViewData["ContratId"] = new SelectList(_context.Contrat, "Id", "Id");
            ViewData["CourId"] = new SelectList(_context.Cour, "Id", "Id");
            ViewData["LieuId"] = new SelectList(_context.Lieu, "Id", "Id");
            return View();
        }

        // POST: Sceances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,ContratId,CourId,LieuId")] Sceance sceance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sceance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContratId"] = new SelectList(_context.Contrat, "Id", "Id", sceance.ContratId);
            ViewData["CourId"] = new SelectList(_context.Cour, "Id", "Id", sceance.CourId);
            ViewData["LieuId"] = new SelectList(_context.Lieu, "Id", "Id", sceance.LieuId);
            return View(sceance);
        }

        // GET: Sceances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sceance = await _context.Sceance.FindAsync(id);
            if (sceance == null)
            {
                return NotFound();
            }
            ViewData["ContratId"] = new SelectList(_context.Contrat, "Id", "Id", sceance.ContratId);
            ViewData["CourId"] = new SelectList(_context.Cour, "Id", "Id", sceance.CourId);
            ViewData["LieuId"] = new SelectList(_context.Lieu, "Id", "Id", sceance.LieuId);
            return View(sceance);
        }

        // POST: Sceances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,ContratId,CourId,LieuId")] Sceance sceance)
        {
            if (id != sceance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sceance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SceanceExists(sceance.Id))
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
            ViewData["ContratId"] = new SelectList(_context.Contrat, "Id", "Id", sceance.ContratId);
            ViewData["CourId"] = new SelectList(_context.Cour, "Id", "Id", sceance.CourId);
            ViewData["LieuId"] = new SelectList(_context.Lieu, "Id", "Id", sceance.LieuId);
            return View(sceance);
        }

        // GET: Sceances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sceance = await _context.Sceance
                .Include(s => s.Contrat)
                .Include(s => s.Cour)
                .Include(s => s.Lieu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sceance == null)
            {
                return NotFound();
            }

            return View(sceance);
        }

        // POST: Sceances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sceance = await _context.Sceance.FindAsync(id);
            _context.Sceance.Remove(sceance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SceanceExists(int id)
        {
            return _context.Sceance.Any(e => e.Id == id);
        }
    }
}
