using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCFifa2022.Data;
using MVCFifa2022.Models;

namespace MVCFifa2022.Controllers
{
    public class PlayerController : Controller
    {
        ApplicationDbContext _context;
        private IWebHostEnvironment _environment;

        public PlayerController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;          
            _environment = environment;
        }



        public IActionResult Index()
        {
            var players = _context.Players;
            return View(players);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var player = new NewPlayer();
            ViewBag.TeamId = new SelectList(_context.Teams, "TeamId", "TeamName");
            return View(player);
        }

        [HttpPost]
        public IActionResult Create(NewPlayer player)
        {
            if (ModelState.IsValid)
            {
                AddPlayer(player);
                
                return RedirectToAction("Index");
            }    

            return View(player); ;
        }

        public IActionResult Details(int id)
        {
            var player = _context.Players.Where(x => x.PLayerId == id).FirstOrDefault();

            var path = _environment.WebRootPath;
            var fileExist = false;

            if (player.ImageLink != null)
            {
                var file = Path.Combine($"{path}\\Images", player.ImageLink);
                fileExist = System.IO.File.Exists(file);
            }

            ViewBag.FileExist = fileExist;
            return View(player);


        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var player = _context.Players.Where(x => x.PLayerId == id).FirstOrDefault();
            return View(player);
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Player player)
        {
           if (ModelState.IsValid)
            {
                _context.Update(player);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(player);

            
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var player = _context.Players.Where(x => x.PLayerId == id).FirstOrDefault();
            return View(player);

        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var player = _context.Players.Where(x => x.PLayerId == id).FirstOrDefault();
            _context.Players.Remove(player);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        private void AddPlayer(NewPlayer player)
        {
            Player p = (Player)player;
            _context.Players.Add(p);
            _context.SaveChanges();

            var tp = new TeamPlayer();
            tp.PlayerId = p.PLayerId;
            tp.TeamId = player.TeamId;
            tp.StartDate = DateTime.Now;
            _context.TeamPlayers.Add(tp);
            _context.SaveChanges();



        }

        




    }
}
