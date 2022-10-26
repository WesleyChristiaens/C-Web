using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCTagHelper.Data;
using MVCTagHelper.Models;

namespace MVCTagHelper.Controllers
{
    public class LandenController : Controller
    {
        private readonly TagHelperDbContext _context;

        public LandenController(TagHelperDbContext context)
        {
            _context = context;
        }

        // GET: Landen
        public async Task<IActionResult> Index()
        {
              return View(await _context.Landen.ToListAsync());
        }

        // GET: Landen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Landen == null)
            {
                return NotFound();
            }

            var land = await _context.Landen
                .FirstOrDefaultAsync(m => m.LandId == id);
            if (land == null)
            {
                return NotFound();
            }

            return View(land);
        }

        // GET: Landen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Landen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LandId,LandCode,LandNaam")] Land land)
        {
            if (ModelState.IsValid)
            {
                _context.Add(land);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(land);
        }

        // GET: Landen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Landen == null)
            {
                return NotFound();
            }

            var land = await _context.Landen.FindAsync(id);
            if (land == null)
            {
                return NotFound();
            }
            return View(land);
        }

        // POST: Landen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LandId,LandCode,LandNaam")] Land land)
        {
            if (id != land.LandId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(land);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LandExists(land.LandId))
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
            return View(land);
        }

        // GET: Landen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Landen == null)
            {
                return NotFound();
            }

            var land = await _context.Landen
                .FirstOrDefaultAsync(m => m.LandId == id);
            if (land == null)
            {
                return NotFound();
            }

            return View(land);
        }

        // POST: Landen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Landen == null)
            {
                return Problem("Entity set 'TagHelperDbContext.Landen'  is null.");
            }
            var land = await _context.Landen.FindAsync(id);
            if (land != null)
            {
                _context.Landen.Remove(land);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LandExists(int id)
        {
          return _context.Landen.Any(e => e.LandId == id);
        }
    }
}
