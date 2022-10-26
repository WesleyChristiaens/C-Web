using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MVC_sportstore.Models;

namespace MVC_sportstore.Taghelpers
{
    [HtmlTargetElement("page-link",Attributes ="paging-info")]
    public class PageLinkTagHelper : TagHelper
    {
        public PagingInfo PagingInfo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            output.TagName = "div";
            output.Content.AppendHtml(GetPaginationLinks(PagingInfo));
        }

        private TagBuilder GetPaginationLinks(PagingInfo paginginfo)
        {
            
            TagBuilder ul = new TagBuilder("ul");
            ul.Attributes["class"] = "pagination";
            for (int page = 1; page <= PagingInfo.TotalPages; page++)
            {
                ul.InnerHtml.AppendHtml(
                    GetPaginationLink(page, page == PagingInfo.CurrentPage));
            }

            return ul;
           
        }

        private TagBuilder GetPaginationLink(int page,bool active)
        {
            string pageLinkActive = "btn border border-primary";
            string pageLink = "btn border border-secondary";

            TagBuilder li = new TagBuilder("li");
            li.Attributes["class"] = "page-item";

            TagBuilder a = new TagBuilder("a");
            a.Attributes["class"] = (active) ? pageLinkActive : pageLink;
            a.Attributes["href"] = $"/Home/Index/{page}";
            a.Attributes["title"] = $"Click to go to page {page}";
            a.InnerHtml.Append($"{page}");

            li.InnerHtml.AppendHtml(a);            

            return li;
        }



        
    }
}
