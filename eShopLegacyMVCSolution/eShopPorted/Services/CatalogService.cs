using eShopPorted.Models;
using System.Collections.Generic;
using System.Linq;
using eShopPorted.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace eShopPorted.Services
{
    public class CatalogService : ICatalogService
    {
        private CatalogDBContext db;

        public CatalogService(CatalogDBContext db)            
        {
            this.db = db;
        }

        public PaginatedItemsViewModel<CatalogItem> GetCatalogItemsPaginated(int pageSize, int pageIndex)
        {
            var totalItems = db.CatalogItems.LongCount();

            var itemsOnPage = db.CatalogItems
                .Include(c => c.CatalogBrand)
                .Include(c => c.CatalogType)
                .OrderBy(c => c.Id)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToList();

            return new PaginatedItemsViewModel<CatalogItem>(
                pageIndex, pageSize, totalItems, itemsOnPage);
        }

        public CatalogItem FindCatalogItem(int id)
        {
            return db.CatalogItems
                .Include(c => c.CatalogBrand)
                .Include(c => c.CatalogType)
                .FirstOrDefault(ci => ci.Id == id);
        }
        public IEnumerable<CatalogType> GetCatalogTypes()
        {
            return db.CatalogTypes;
        }

        public IEnumerable<CatalogBrand> GetCatalogBrands()
        {
            return db.CatalogBrands;
        }

        public void CreateCatalogItem(CatalogItem catalogItem)
        {
            db.CatalogItems.Add(catalogItem);
            db.SaveChanges();
        }

        public void UpdateCatalogItem(CatalogItem catalogItem)
        {
            db.Entry(catalogItem).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveCatalogItem(CatalogItem catalogItem)
        {
            db.CatalogItems.Remove(catalogItem);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}