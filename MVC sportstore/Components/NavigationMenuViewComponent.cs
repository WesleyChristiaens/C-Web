using Microsoft.AspNetCore.Mvc;
using MVC_sportstore.Data;

namespace MVC_sportstore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private StoreDbContext _context { get; set; }

        public NavigationMenuViewComponent(StoreDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(_context.Products.Select(x => x.Category)
                                          .Distinct()
                                          .OrderBy(x => x));
        }
    }
}
