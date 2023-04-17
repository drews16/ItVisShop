using ItVisShop.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ItVisShop.TagHelpers
{
    public class PageLinkTagHelpers : TagHelper
    {
        private IUrlHelperFactory _urlHelperFactory;

        public PageLinkTagHelpers(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingViewModel PageModel {get;set;}
        public string CurrentCategory { get; set; } 
        public string PageAction { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);

            TagBuilder tag = new TagBuilder("ul");
            tag.AddCssClass("pagination");

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder item = CreateTag(i, urlHelper);
                tag.InnerHtml.AppendHtml(item);
            }

            output.Content.AppendHtml(tag);
        }

        private TagBuilder CreateTag(int pageNumber, IUrlHelper urlHelper)
        {
            TagBuilder item = new TagBuilder("li");
            TagBuilder link = new TagBuilder("a");

            if (pageNumber == PageModel.CurrentPage)
            {
                item.AddCssClass("page__active");
            }
            else
            {
                link.Attributes["href"] = urlHelper
                    .Action(PageAction, new { category = CurrentCategory, page = pageNumber });
            }

            link.InnerHtml.Append(pageNumber.ToString());
            item.InnerHtml.AppendHtml(link);

            return item;
        }
    }
}
