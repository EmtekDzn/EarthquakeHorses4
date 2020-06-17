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
    public class CoursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cours
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cour.ToListAsync());
        }

        // GET: Cours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cour = await _context.Cour
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cour == null)
            {
                return NotFound();
            }

            return View(cour);
        }

        // GET: Cours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Place,Type,Niveau")] Cour cour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cour);
        }

        // GET: Cours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cour = await _context.Cour.FindAsync(id);
            if (cour == null)
            {
                return NotFound();
            }
            return View(cour);
        }

        // POST: Cours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Place,Type,Niveau")] Cour cour)
        {
            if (id != cour.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourExists(cour.Id))
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
            return View(cour);
        }

        // GET: Cours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cour = await _context.Cour
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cour == null)
            {
                return NotFound();
            }

            return View(cour);
        }

        // POST: Cours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cour = await _context.Cour.FindAsync(id);
            _context.Cour.Remove(cour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourExists(int id)
        {
            return _context.Cour.Any(e => e.Id == id);
        }
    }
}
