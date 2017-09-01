using eShopLegacyWebForms.Models;
using eShopLegacyWebForms.Services;
using eShopLegacyWebForms.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using System.Web.Routing;

namespace eShopLegacyWebForms
{
    public partial class _Default : Page
    {
        public const int DefaultPageIndex = 0;
        public const int DefaultPageSize = 10;

        public ICatalogService CatalogService { get; set; }

        protected PaginatedItemsViewModel<CatalogItem> Model { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (PaginationParamsAreSet())
            {
                var size = Convert.ToInt32(Page.RouteData.Values["size"]);
                var index = Convert.ToInt32(Page.RouteData.Values["index"]);
                Model = CatalogService.GetCatalogItemsPaginated(size, index);
            }
            else
            {
                Model = CatalogService.GetCatalogItemsPaginated(DefaultPageSize, DefaultPageIndex);
            }

            productList.DataSource = Model.Data;
            productList.DataBind();
            ConfigurePagination();

        }

        private bool PaginationParamsAreSet()
        {
            return Page.RouteData.Values.Keys.Contains("size") && Page.RouteData.Values.Keys.Contains("index");
        }

        private void ConfigurePagination()
        {
            PaginationNext.NavigateUrl = GetRouteUrl("ProductsByPageRoute", new { index = Model.ActualPage + 1, size = Model.ItemsPerPage });
            var pagerNextExtraStyles = Model.ActualPage < Model.TotalPages - 1 ? "" : " esh-pager-item--hidden";
            PaginationNext.CssClass = PaginationNext.CssClass + pagerNextExtraStyles;

            PaginationPrevious.NavigateUrl = GetRouteUrl("ProductsByPageRoute", new { index = Model.ActualPage - 1, size = Model.ItemsPerPage });
            var pagerPreviousExtraStyles = Model.ActualPage > 0 ? "" : " esh-pager-item--hidden";
            PaginationPrevious.CssClass = PaginationPrevious.CssClass + pagerPreviousExtraStyles;
        }
    }
}