using eShopCatalogMVC.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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
            var rawCommand = "INSERT dbo.Catalog(Id, CatalogBrandId, CatalogTypeId, Description, Name, PictureFileName, Price, AvailableStock, MaxStockThreshold, OnReorder, RestockThreshold) " +
                             "VALUES(NEXT VALUE FOR catalog_hilo, @CatalogBrandId, @CatalogTypeId, @Description, @Name, @PictureFileName, @Price, @AvailableStock, @MaxStockThreshold, @OnReorder, @RestockThreshold); ";
            db.Database.ExecuteSqlCommand(
                rawCommand,
                new SqlParameter("@CatalogBrandId", catalogItem.CatalogBrandId),
                new SqlParameter("@CatalogTypeId", catalogItem.CatalogTypeId),
                new SqlParameter("@Description", catalogItem.Description),
                new SqlParameter("@Name", catalogItem.Name),
                new SqlParameter("@PictureFileName", catalogItem.PictureFileName),
                new SqlParameter("@Price", catalogItem.Price),
                new SqlParameter("@AvailableStock", catalogItem.AvailableStock),
                new SqlParameter("@MaxStockThreshold", catalogItem.MaxStockThreshold),
                new SqlParameter("@OnReorder", catalogItem.OnReorder),
                new SqlParameter("@RestockThreshold", catalogItem.RestockThreshold));
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