using System.Collections.Generic;
using eShopCatalogMVC.Models;
using System;

namespace eShopCatalogMVC.Services
{
    public interface ICatalogService : IDisposable
    {
        CatalogItem FindCatalogItem(int? id);
        IEnumerable<CatalogBrand> GetCatalogBrands();
        List<CatalogItem> GetCatalogItems();
        IEnumerable<CatalogType> GetCatalogTypes();
        void CreateCatalogItem(CatalogItem catalogItem);
        void UpdateCatalogItem(CatalogItem catalogItem);
        void RemoveCatalogItem(CatalogItem catalogItem);
    }
}