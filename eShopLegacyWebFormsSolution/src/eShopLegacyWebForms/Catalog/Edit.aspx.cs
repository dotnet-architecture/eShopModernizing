using eShopLegacyWebForms.Models;
using eShopLegacyWebForms.Services;
using log4net;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace eShopLegacyWebForms.Catalog
{
    public partial class Edit : System.Web.UI.Page
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected CatalogItem product;

        public ICatalogService CatalogService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                var productId = Convert.ToInt32(Page.RouteData.Values["id"]);
                _log.Info($"Now loading... /Catalog/Edit.aspx?id={productId}");
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