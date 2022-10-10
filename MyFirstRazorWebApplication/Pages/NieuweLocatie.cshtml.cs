using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFirstRazorWebApplication.Data;

namespace MyFirstRazorWebApplication.Pages
{
    public class NieuweLocatieModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            string postcode = Request.Form["PostCode"];
            int tempPostCode = int.Parse(postcode);
            string city = Request.Form["City"];
            Databank.AddLocation(tempPostCode, city);
            return RedirectToPage("Locaties");
        }


    }
}
