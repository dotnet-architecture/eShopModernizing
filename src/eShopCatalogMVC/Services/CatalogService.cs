using eShopCatalogMVC.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace eShopCatalogMVC.Services
{
    public class CatalogService : ICatalogService
    {
        private CatalogDBContext db = new CatalogDBContext();

        public List<CatalogItem> GetCatalogItems()
        {
            return db.CatalogItems.Include(c => c.CatalogBrand).Include(c => c.CatalogType).ToList();
        }

        public CatalogItem FindCatalogItem(int? id)
        {
            return db.CatalogItems.Find(id);
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