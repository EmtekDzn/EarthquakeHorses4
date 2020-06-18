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
    public class PensionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PensionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pensions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pension.Include(p => p.Cheval).Include(p => p.Contrat);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pensions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pension = await _context.Pension
                .Include(p => p.Cheval)
                .Include(p => p.Contrat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pension == null)
            {
                return NotFound();
            }

            return View(pension);
        }

        // GET: Pensions/Create
        public IActionResult Create()
        {
            ViewData["ChevalId"] = new SelectList(_context.Cheval, "Id", "Id");
            ViewData["ContratId"] = new SelectList(_context.Contrat, "Id", "Id");
            return View();
        }

        // POST: Pensions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tarif,Engagement,Type,Detail,ContratId,UserId,ChevalId")] Pension pension)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pension);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChevalId"] = new SelectList(_context.Cheval, "Id", "Id", pension.ChevalId);
            ViewData["ContratId"] = new SelectList(_context.Contrat, "Id", "Id", pension.ContratId);
            return View(pension);
        }

        // GET: Pensions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pension = await _context.Pension.FindAsync(id);
            if (pension == null)
            {
                return NotFound();
            }
            ViewData["ChevalId"] = new SelectList(_context.Cheval, "Id", "Id", pension.ChevalId);
            ViewData["ContratId"] = new SelectList(_context.Contrat, "Id", "Id", pension.ContratId);
            return View(pension);
        }

        // POST: Pensions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tarif,Engagement,Type,Detail,ContratId,UserId,ChevalId")] Pension pension)
        {
            if (id != pension.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pension);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PensionExists(pension.Id))
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
            ViewData["ChevalId"] = new SelectList(_context.Cheval, "Id", "Id", pension.ChevalId);
            ViewData["ContratId"] = new SelectList(_context.Contrat, "Id", "Id", pension.ContratId);
            return View(pension);
        }

        // GET: Pensions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pension = await _context.Pension
                .Include(p => p.Cheval)
                .Include(p => p.Contrat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pension == null)
            {
                return NotFound();
            }

            return View(pension);
        }

        // POST: Pensions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pension = await _context.Pension.FindAsync(id);
            _context.Pension.Remove(pension);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PensionExists(int id)
        {
            return _context.Pension.Any(e => e.Id == id);
        }
    }
}
