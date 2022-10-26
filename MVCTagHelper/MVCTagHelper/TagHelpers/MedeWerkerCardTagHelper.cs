using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MVCTagHelper.ViewModels;

namespace MVCTagHelper.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement(Attributes ="medewerker-card-view-model")]
    public class MedeWerkerCardTagHelper : TagHelper
    {
        public MedeWerkerCard medewerkerCardViewModel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string content = $@"<div class='card'>";
            content += $@"<h4 class='card-title'>{medewerkerCardViewModel.MedeWerkerNaam}</h4>";
            content += $@"<p class='card-position'>{medewerkerCardViewModel.AfdelingNaam} - {medewerkerCardViewModel.Locatie}</p>";
            content += $@"<p class='card-description'> De Afdeling{medewerkerCardViewModel.AfdelingNaam} ligt in {medewerkerCardViewModel.Land}.</p>";
            output.TagName = "div";
            output.Content.SetHtmlContent(content);
        }
    }
}
