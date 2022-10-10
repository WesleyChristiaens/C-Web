using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using oef8_WebAppMVCClientLocationEFCore.Data;
using oef8_WebAppMVCClientLocationEFCore.Models;

namespace oef8_WebAppMVCClientLocationEFCore.Controllers
{
    public class ClientLocationController : Controller
    {
        private ClientLocationContext _context;
        private IWebHostEnvironment _environment;

        public ClientLocationController(ClientLocationContext context, IWebHostEnvironment environment)
        {
            this._context = context;
            _context.Database.EnsureCreated();
            this._environment = environment;
        }

        public IActionResult Index()
        {
            var ClientLocations = from c in _context.Clients
                                  join l in _context.Locations
                                  on c.LocationId equals l.LocationId
                                  select new ClientLocation { ClientName = c.ClientName, City = l.City };

            //LINQ lambda notatie voor een join
            /* var clientLoc = _context.Clients.Join(_context.Locations,
                                             client => client.LocationId,
                                             location => location.LocationId,
                                             (client, location) => new ClientLocation 

                                             { 
                                                 ClientName = client.ClientName, 
                                                 City = location.City 
                                             });*/



            return View(ClientLocations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var cl = new ClientLocation();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClientLocation cl)
        {
            if (ModelState.IsValid)
            {
                if (LocationExists(cl.City))
                {
                    _context.Clients.Add(new Client
                    {
                        ClientName = cl.ClientName,
                        LocationId = GetLocationId(cl.City)
                    });
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    _context.Locations.Add(new Location
                    {
                        City = cl.City,
                        PostCode = cl.PostCode
                    });
                    _context.SaveChanges();

                    _context.Clients.Add(new Client
                    {
                        ClientName = cl.ClientName,
                        LocationId = GetLocationId(cl.City)
                    });
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(cl);
            }

        }

        private bool LocationExists(string city)
        {
            bool exists = false;

            if (_context.Locations.Where(x => x.City == city)
                                  .Count() > 0)
            {
                exists = true;
            }

            return exists;
        }

        private int? GetLocationId(string city)
        {
            var locationid = _context.Locations.Where(x => x.City == city)
                                               .Select(x => x.LocationId)
                                               .FirstOrDefault();

            return locationid;
        }

    }
}
