﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EarthquakeHorses4.Data;
using EarthquakeHorses4.Models;
using Microsoft.AspNetCore.Authorization;

namespace EarthquakeHorses4.Controllers
{
    [Authorize(Roles = "Gerant,Secretaire")]
    public class LieuxController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LieuxController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lieux
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lieu.ToListAsync());
        }

        // GET: Lieux/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lieu = await _context.Lieu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lieu == null)
            {
                return NotFound();
            }

            return View(lieu);
        }

        // GET: Lieux/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Description")] Lieu lieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lieu);
        }

        // GET: Lieux/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lieu = await _context.Lieu.FindAsync(id);
            if (lieu == null)
            {
                return NotFound();
            }
            return View(lieu);
        }

        // POST: Lieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Description")] Lieu lieu)
        {
            if (id != lieu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LieuExists(lieu.Id))
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
            return View(lieu);
        }

        // GET: Lieux/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lieu = await _context.Lieu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lieu == null)
            {
                return NotFound();
            }

            return View(lieu);
        }

        // POST: Lieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lieu = await _context.Lieu.FindAsync(id);
            _context.Lieu.Remove(lieu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LieuExists(int id)
        {
            return _context.Lieu.Any(e => e.Id == id);
        }
    }
}
