using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCFifa2022.Data;
using MVCFifa2022.Models;

namespace MVCFifa2022.Controllers
{
    public class TeamController : Controller
    {
        private ApplicationDbContext _context;

        public TeamController(ApplicationDbContext context)
        {
            _context = context;            
            _context.Database.EnsureCreated();

        }

        public IActionResult Index()
        {
            var teams = _context.Teams;
            return View(teams);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var team = new Team();
            return View(team);
        }

        [HttpPost]
        public IActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Teams.Add(team);
                _context.SaveChanges();
                return RedirectToAction("Index");
                
            }

            return View(team) ;

        }





    }
}
