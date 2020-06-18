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
    public class LicencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LicencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Licences
        public async Task<IActionResult> Index()
        {
            return View(await _context.Licence.ToListAsync());
        }

        // GET: Licences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licence = await _context.Licence
                .FirstOrDefaultAsync(m => m.Id == id);
            if (licence == null)
            {
                return NotFound();
            }

            return View(licence);
        }

        // GET: Licences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Licences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Validite,Tarif,Niveau,Categorie,UserId")] Licence licence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(licence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(licence);
        }

        // GET: Licences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licence = await _context.Licence.FindAsync(id);
            if (licence == null)
            {
                return NotFound();
            }
            return View(licence);
        }

        // POST: Licences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Validite,Tarif,Niveau,Categorie,UserId")] Licence licence)
        {
            if (id != licence.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(licence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LicenceExists(licence.Id))
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
            return View(licence);
        }

        // GET: Licences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licence = await _context.Licence
                .FirstOrDefaultAsync(m => m.Id == id);
            if (licence == null)
            {
                return NotFound();
            }

            return View(licence);
        }

        // POST: Licences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var licence = await _context.Licence.FindAsync(id);
            _context.Licence.Remove(licence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LicenceExists(int id)
        {
            return _context.Licence.Any(e => e.Id == id);
        }
    }
}
