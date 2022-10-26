using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MVCVoertuig.Data;
using System.Text;

namespace MVCVoertuig.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("car-info")]
    public class CarInfoTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetHtmlContent(GetHtmlText());
        }

        public VoertuigDbContext _context;

        [HtmlAttributeName("merk")]
        public string Merk { get; set; }

        public CarInfoTagHelper(VoertuigDbContext context)
        {
            this._context = context;
        }

        private int GetCarCount()
        {
            int count = 0;

            if (string.IsNullOrEmpty(Merk))
            {
                count = _context.Voertuigen.Count();
            }
            else
            {
                count = _context.Voertuigen.Where(x => x.Merk == Merk ).Count();
            }

            return count;
        }

        private string GetHtmlText()
        {
            StringBuilder html = new StringBuilder();

            html.Append("<button type='button' class='btn border-primary m-2'>");
            html.Append("Aantal voertuigen: ");
            html.Append("<span class='badge bg-primary'>");
            html.Append($"{GetCarCount()}");
            html.Append("</span>");
            html.Append("</button");
            return html.ToString();
        }


    }
}
