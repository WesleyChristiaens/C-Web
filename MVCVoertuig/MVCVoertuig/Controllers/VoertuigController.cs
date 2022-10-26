using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCVoertuig.Data;
using MVCVoertuig.Models.Data;

namespace MVCVoertuig.Controllers
{
    public class VoertuigController : Controller
    {
        private readonly VoertuigDbContext _context;

        public VoertuigController(VoertuigDbContext context)
        {
            _context = context;
        }
        // GET: Voertuig
        public async Task<IActionResult> Index()
        {
              return View(await _context.Voertuigen.ToListAsync());
        }  
        // GET: Voertuig/Create
        public IActionResult Create()
        {
            return View();
        }       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Voertuig voertuig)
        {
            if (ModelState.IsValid)
            {
                _context.Voertuigen.Add(voertuig);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voertuig);
        }       

       public IActionResult Merk (string merk)
        {
            ViewBag.Merk = merk;
            return View(_context.Voertuigen.Where(x => x.Merk == merk));
        }
    }
}

