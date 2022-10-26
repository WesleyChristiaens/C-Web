using Microsoft.AspNetCore.Mvc;
using MVCVoertuig.Data;

namespace MVCVoertuig.Components
{
    public class HeaderMenuViewComponent : ViewComponent
    {
        private VoertuigDbContext _context;

        public HeaderMenuViewComponent(VoertuigDbContext context)
        {
            this._context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View(
                _context.Voertuigen
                .Select(x => x.Merk)
                .Distinct()
                .OrderBy(x => x));
        }
        

    }
}
