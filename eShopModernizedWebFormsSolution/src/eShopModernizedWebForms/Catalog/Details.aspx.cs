using eShopModernizedWebForms.Models;
using eShopModernizedWebForms.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShopModernizedWebForms.Catalog
{
    public partial class Details : System.Web.UI.Page
    {
        protected CatalogItem product;

        public ICatalogService CatalogService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var productId = Convert.ToInt32(Page.RouteData.Values["id"]);
            product = CatalogService.FindCatalogItem(productId);

            this.DataBind();
        }
    }
}