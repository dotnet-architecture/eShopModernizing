using System.Collections.Generic;
using eShopPorted.Models;
using System;
using eShopPorted.ViewModel;

namespace eShopPorted.Services
{
    public interface ICatalogService : IDisposable
    {
        CatalogItem FindCatalogItem(int id);
        IEnumerable<CatalogBrand> GetCatalogBrands();
        PaginatedItemsViewModel<CatalogItem> GetCatalogItemsPaginated(int pageSize, int pageIndex);
        IEnumerable<CatalogType> GetCatalogTypes();
        void CreateCatalogItem(CatalogItem catalogItem);
        void UpdateCatalogItem(CatalogItem catalogItem);
        void RemoveCatalogItem(CatalogItem catalogItem);
    }
}