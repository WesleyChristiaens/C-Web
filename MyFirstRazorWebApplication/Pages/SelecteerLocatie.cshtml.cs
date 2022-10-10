using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyFirstRazorWebApplication.Pages
{
    public class SelecteerLocatieModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            /* vraag id op uit form */
            var id = Request.Form["SelectLocatie"];            

            /* id wordt meegegeven als nieuw object */
            return RedirectToPage("LocatieDetails", new { id=int.Parse(id)});
        }
    }
}
