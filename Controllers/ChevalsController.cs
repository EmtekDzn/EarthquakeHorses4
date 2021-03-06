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
    [Authorize(Roles = "Gerant,Palefrenier,Secretaire")]
    public class ChevalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChevalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Chevals
        [Authorize(Roles = "Gerant,Palefrenier,Secretaire")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cheval.ToListAsync());
        }

        // GET: Chevals/Details/5
        [Authorize(Roles = "Gerant,Palefrenier,Secretaire")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cheval = await _context.Cheval
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cheval == null)
            {
                return NotFound();
            }

            return View(cheval);
        }

        // GET: Chevals/Create
        [Authorize(Roles = "Gerant,Palefrenier")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chevals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Gerant,Palefrenier")]
        public async Task<IActionResult> Create([Bind("Id,Nom,Taille,Robe,Photo,UserId")] Cheval cheval)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cheval);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cheval);
        }

        // GET: Chevals/Edit/5
        [Authorize(Roles = "Gerant,Palefrenier")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cheval = await _context.Cheval.FindAsync(id);
            if (cheval == null)
            {
                return NotFound();
            }
            return View(cheval);
        }

        // POST: Chevals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Gerant,Palefrenier")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Taille,Robe,Photo,UserId")] Cheval cheval)
        {
            if (id != cheval.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cheval);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChevalExists(cheval.Id))
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
            return View(cheval);
        }

        // GET: Chevals/Delete/5
        [Authorize(Roles = "Gerant,Palefrenier")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cheval = await _context.Cheval
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cheval == null)
            {
                return NotFound();
            }

            return View(cheval);
        }

        // POST: Chevals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Gerant,Palefrenier")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cheval = await _context.Cheval.FindAsync(id);
            _context.Cheval.Remove(cheval);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChevalExists(int id)
        {
            return _context.Cheval.Any(e => e.Id == id);
        }
    }
}
