using eShopLegacyWebForms.Models;
using eShopLegacyWebForms.Services;
using eShopLegacyWebForms.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShopLegacyWebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var service = new CatalogServiceMock();
            var paginatedProducts = service.GetCatalogItemsPaginated();            
            productList.DataSource = paginatedProducts.Data;
            productList.DataBind();
        }
    }
}