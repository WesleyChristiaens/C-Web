using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MVCTagHelper.ViewModels;

namespace MVCTagHelper.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement(Attributes ="afdeling-card-view-model")]
    public class AfdelingCardTagHelper : TagHelper
    {
        public AfdelingCard AfdelingCardViewModel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string content = $@"<div class='card'>";
            content += $@"<h4 class='card-title'>{AfdelingCardViewModel.AfdelingNaam}</h4>";
            content += $@"<p class='card-position'>{AfdelingCardViewModel.LandCode} - {AfdelingCardViewModel.Locatie}</p>";
            content += $@"<p class='card-description'> De Afdeling{AfdelingCardViewModel.AfdelingNaam} ligt in {AfdelingCardViewModel.Land}.</p>";
            output.TagName = "div";
            output.Content.SetHtmlContent(content);
        
        }
    }
}
