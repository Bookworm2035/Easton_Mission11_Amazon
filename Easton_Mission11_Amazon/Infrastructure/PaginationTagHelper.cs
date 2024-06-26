﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Runtime.CompilerServices;
using Easton_Mission11_Amazon.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace Easton_Mission11_Amazon.Infrastructure
{
    [HtmlTargetElement("div", Attributes="page-model")]
    public class PaginationTagHelper:TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public PaginationTagHelper (IUrlHelperFactory temp)
        {
            urlHelperFactory = temp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]

        //PAGINATION STUFF YAY
        public ViewContext? ViewContext { get; set; }
        public string? PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix ="page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object >();



        public PaginationInfo PageModel {  get; set; }

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; } = String.Empty;

        public string PageClassNormal {  get; set; } = String.Empty;

        public string PageClassSelected {  get; set; } = String.Empty;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext != null && PageModel != null)
            {
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

                TagBuilder result = new TagBuilder("div");

                for (int i = 1; i <= PageModel.TotalPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a");
                    PageUrlValues["pageNum"] = i;
                    //Add in CSS for the button

                    tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
                    if (PageClassesEnabled) { 
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i==PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }

                    tag.InnerHtml.Append(i.ToString());

                    // Append a space after each page number
                    //tag.InnerHtml.Append(" ");

                    result.InnerHtml.AppendHtml(tag);
                }
                
                output.Content.AppendHtml(result.InnerHtml);

            }
        }
    }
}
