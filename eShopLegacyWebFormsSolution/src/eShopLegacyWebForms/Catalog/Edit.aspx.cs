using eShopLegacyWebForms.Models;
using eShopLegacyWebForms.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShopLegacyWebForms.Catalog
{
    public partial class Edit : System.Web.UI.Page
    {
        protected CatalogItem product;

        public ICatalogService CatalogService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                var productId = Convert.ToInt32(Page.RouteData.Values["id"]);
                product = CatalogService.FindCatalogItem(productId);

                BrandDropDownList.DataSource = CatalogService.GetCatalogBrands();
                BrandDropDownList.SelectedValue = product.CatalogBrandId.ToString();

                TypeDropDownList.DataSource = CatalogService.GetCatalogTypes();
                TypeDropDownList.SelectedValue = product.CatalogTypeId.ToString();

                this.DataBind();
            }
        }

        public IEnumerable<CatalogBrand> GetBrands()
        {
            return CatalogService.GetCatalogBrands();
        }

        public IEnumerable<CatalogType> GetTypes()
        {
            return CatalogService.GetCatalogTypes();
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (this.ModelState.IsValid)
            {
                var catalogItem = new CatalogItem
                {
                    Id = Convert.ToInt32(Page.RouteData.Values["id"]),
                    Name = Name.Text,
                    Description = Description.Text,
                    CatalogBrandId = int.Parse(BrandDropDownList.SelectedValue),
                    CatalogTypeId = int.Parse(TypeDropDownList.SelectedValue),
                    Price = decimal.Parse(Price.Text),
                    PictureFileName = PictureFileName.Text,
                    AvailableStock = int.Parse(Stock.Text),
                    RestockThreshold = int.Parse(Restock.Text),
                    MaxStockThreshold = int.Parse(Maxstock.Text)
                };
                CatalogService.UpdateCatalogItem(catalogItem);

                Response.Redirect("~");
            }
        }
    }
}