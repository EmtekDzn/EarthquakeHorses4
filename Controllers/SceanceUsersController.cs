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
    public class SceanceUsersController : Controller
    {
        private readonly ApplicationContext _context;

        public SceanceUsersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: SceanceUsers
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.SceanceUser.Include(s => s.Sceance);
            return View(await applicationContext.ToListAsync());
        }

        // GET: SceanceUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sceanceUser = await _context.SceanceUser
                .Include(s => s.Sceance)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sceanceUser == null)
            {
                return NotFound();
            }

            return View(sceanceUser);
        }

        // GET: SceanceUsers/Create
        public IActionResult Create()
        {
            ViewData["SceanceId"] = new SelectList(_context.Sceance, "Id", "Id");
            return View();
        }

        // POST: SceanceUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SceanceId,UserId")] SceanceUser sceanceUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sceanceUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SceanceId"] = new SelectList(_context.Sceance, "Id", "Id", sceanceUser.SceanceId);
            return View(sceanceUser);
        }

        // GET: SceanceUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sceanceUser = await _context.SceanceUser.FindAsync(id);
            if (sceanceUser == null)
            {
                return NotFound();
            }
            ViewData["SceanceId"] = new SelectList(_context.Sceance, "Id", "Id", sceanceUser.SceanceId);
            return View(sceanceUser);
        }

        // POST: SceanceUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SceanceId,UserId")] SceanceUser sceanceUser)
        {
            if (id != sceanceUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sceanceUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SceanceUserExists(sceanceUser.Id))
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
            ViewData["SceanceId"] = new SelectList(_context.Sceance, "Id", "Id", sceanceUser.SceanceId);
            return View(sceanceUser);
        }

        // GET: SceanceUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sceanceUser = await _context.SceanceUser
                .Include(s => s.Sceance)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sceanceUser == null)
            {
                return NotFound();
            }

            return View(sceanceUser);
        }

        // POST: SceanceUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sceanceUser = await _context.SceanceUser.FindAsync(id);
            _context.SceanceUser.Remove(sceanceUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SceanceUserExists(int id)
        {
            return _context.SceanceUser.Any(e => e.Id == id);
        }
    }
}
