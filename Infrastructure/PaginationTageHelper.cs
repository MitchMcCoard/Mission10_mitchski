using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission10_mitchski.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission10_mitchski.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-change")]
    public class PaginationTagHelper : TagHelper
    {
        //Dynamically create page links

        private IUrlHelperFactory uhf;

        //Constructor
        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            uhf = temp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }




        //Different than View Context
        public PageInfo PageChange { get; set; } // This name is determined by the title of of the attribute

        public string PageAction { get; set; }
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div");

            for (int iCount = 1; iCount <= PageChange.TotalPages; iCount++)
            {
                TagBuilder tb = new TagBuilder("a");

                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = iCount });
                tb.InnerHtml.Append(iCount.ToString());

                final.InnerHtml.AppendHtml(tb);

                //TagBuilder someSpace = new TagBuilder("br");
                //final.InnerHtml.AppendHtml(someSpace);
                if (PageClassesEnabled)
                {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(iCount == PageChange.CurrentPage
                        ? PageClassSelected : PageClassNormal);
                }
            }

            tho.Content.AppendHtml(final.InnerHtml);
        }

    }
}
