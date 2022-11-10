using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCGroentenEnFruit.Data;
using MVCGroentenEnFruit.Models.Data;

namespace MVCGroentenEnFruit.Controllers
{
    [Authorize]
    public class ArtikelsController : Controller
    {
        private readonly AppDbContext _context;

        public ArtikelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Artikels
        public async Task<IActionResult> Index()
        {
                var lst = (_context.Artikels != null) ? await _context.Artikels.ToListAsync() : Enumerable.Empty<Artikel>();
                return View(lst);
        }

        // GET: Artikels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Artikels == null)
            {
                return NotFound();
            }

            var artikel = await _context.Artikels
                .FirstOrDefaultAsync(m => m.ArtikelId == id);
            if (artikel == null)
            {
                return NotFound();
            }

            return View(artikel);
        }

        // GET: Artikels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artikels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtikelId,Naam")] Artikel artikel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artikel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artikel);
        }

        // GET: Artikels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Artikels == null)
            {
                return NotFound();
            }

            var artikel = await _context.Artikels.FindAsync(id);
            if (artikel == null)
            {
                return NotFound();
            }
            return View(artikel);
        }

        // POST: Artikels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtikelId,Naam")] Artikel artikel)
        {
            if (id != artikel.ArtikelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artikel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtikelExists(artikel.ArtikelId))
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
            return View(artikel);
        }

        // GET: Artikels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Artikels == null)
            {
                return NotFound();
            }

            var artikel = await _context.Artikels
                .FirstOrDefaultAsync(m => m.ArtikelId == id);
            if (artikel == null)
            {
                return NotFound();
            }

            return View(artikel);
        }

        // POST: Artikels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Artikels == null)
            {
                return Problem("Entity set 'AppDbContext.Artikels'  is null.");
            }
            var artikel = await _context.Artikels.FindAsync(id);
            if (artikel != null)
            {
                _context.Artikels.Remove(artikel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtikelExists(int id)
        {
            bool artikelExists = false;
            if(_context.Artikels != null)
                artikelExists = _context.Artikels.Any(e => e.ArtikelId == id);
            return artikelExists;
        }
    }
}
