using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyFirstRazorWebApplication.Pages
{
    public class LocatieDetailsModel : PageModel
    {
        public int LocationId { get; set; }
        public void OnGet(int id)
        {
            LocationId = id;
        }
    }
}
