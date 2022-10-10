using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFirstRazorWebApplication.Data;

namespace MyFirstRazorWebApplication.Pages
{
    public class NieuweKlantModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            string klantnaam = Request.Form["klantnaam"];
            string locatieid = Request.Form["locatieid"];
         

            Databank.AddClient(klantnaam, locatieid);
            return RedirectToPage("Klant");
        }

    }
}
