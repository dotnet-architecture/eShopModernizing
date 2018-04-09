using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eShopWCFService.Models;

namespace eShopWCFService
{
    public class CatalogServiceClient : System.ServiceModel.ClientBase<ICatalogService>, ICatalogService
    {
        public void CreateAvailableStock(CatalogItemsStock catalogItemsStock)
        {
            throw new NotImplementedException();
        }

        public void CreateCatalogItem(CatalogItem catalogItem)
        {
            throw new NotImplementedException();
        }

        public CatalogItem FindCatalogItem(int id)
        {
            throw new NotImplementedException();
        }

        public int GetAvailableStock(DateTime date, int catalogItemId)
        {
            return base.Channel.GetAvailableStock(date, catalogItemId);
        }

        public List<CatalogBrand> GetCatalogBrands()
        {
            return base.Channel.GetCatalogBrands();
        }

        public List<CatalogItem> GetCatalogItems()
        {
            return base.Channel.GetCatalogItems();
        }

        public List<CatalogType> GetCatalogTypes()
        {
            return base.Channel.GetCatalogTypes();
        }

        public void RemoveCatalogItem(CatalogItem catalogItem)
        {
            base.Channel.RemoveCatalogItem(catalogItem);
        }

        public void UpdateCatalogItem(CatalogItem catalogItem)
        {
            base.Channel.UpdateCatalogItem(catalogItem);
        }
    }
}