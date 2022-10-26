using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCTagHelper.TagHelpers
{

    [HtmlTargetElement("div", Attributes ="header, footer")]
    public class HeaderFooterTagHelper : TagHelper
    {
        public string Header { get; set; }
        public string Footer { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.IsNullOrEmpty(Header) || !string.IsNullOrEmpty(Footer))
            {
                output.Attributes.SetAttribute("class", "m-1 p-1");
                if (!string.IsNullOrEmpty(Header))
                {
                    output.PreElement.SetHtmlContent(GetFormattedDiv(Header));
                }
                if (!string.IsNullOrEmpty(Footer))
                {
                    output.PostElement.SetHtmlContent(GetFormattedDiv(Footer));
                }
            }
        }

        private TagBuilder GetFormattedDiv(string content)
        {
            TagBuilder title = new TagBuilder("h1");
            title.InnerHtml.Append(content);

            TagBuilder container = new TagBuilder("div");
            container.Attributes["class"] = "bg-info m-1 p-1";
            container.InnerHtml.AppendHtml(title);

            return container;
            
        }

    }
}
