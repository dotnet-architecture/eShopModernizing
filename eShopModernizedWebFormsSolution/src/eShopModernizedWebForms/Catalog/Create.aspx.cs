using eShopModernizedWebForms.Models;
using eShopModernizedWebForms.Services;
using Microsoft.Diagnostics.EventFlow;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web.ModelBinding;

namespace eShopModernizedWebForms.Catalog
{
    public partial class Create : System.Web.UI.Page
    {
        protected string pictureUri;

        public ICatalogService CatalogService { get; set; }
        public IImageService ImageService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            using (var pipeline = DiagnosticPipelineFactory.CreatePipeline("eventFlowConfig.json"))
            {
                System.Diagnostics.Trace.TraceWarning("EventFlow is working WebForms!");
                Console.ReadLine();
            }

            if (!CatalogConfiguration.UseAzureStorage)
            {
                UploadButton.Visible = false;
            }

            pictureUri = ImageService.UrlDefaultImage();
            this.DataBind();
        }

        public IEnumerable<CatalogBrand> GetBrands()
        {
            return CatalogService.GetCatalogBrands();
        }

        public IEnumerable<CatalogType> GetTypes()
        {
            return CatalogService.GetCatalogTypes();
        }

        protected void Create_Click(object sender, EventArgs e)
        {
            if (this.ModelState.IsValid)
            {
                var catalogItem = new CatalogItem
                {
                    Name = Name.Text,
                    Description = Description.Text,
                    CatalogBrandId = int.Parse(Brand.SelectedValue),
                    CatalogTypeId = int.Parse(Type.SelectedValue),
                    Price = decimal.Parse(Price.Text),
                    AvailableStock = int.Parse(Stock.Text),
                    RestockThreshold = int.Parse(Restock.Text),
                    MaxStockThreshold = int.Parse(Maxstock.Text),
                    TempImageName = TempImageName.Value
                };

                if (!string.IsNullOrEmpty(catalogItem.TempImageName))
                {
                    var fileName = Path.GetFileName(catalogItem.TempImageName);
                    catalogItem.PictureFileName = fileName;
                }

                CatalogService.CreateCatalogItem(catalogItem);

                if (!string.IsNullOrEmpty(catalogItem.TempImageName))
                {
                    ImageService.UpdateImage(catalogItem);
                }

                Response.Redirect("~");
            }
        }
    }
}