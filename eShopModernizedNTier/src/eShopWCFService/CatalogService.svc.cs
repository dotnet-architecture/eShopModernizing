using eShopWCFService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace eShopWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CatalogService" in both code and config file together.
    public class CatalogService : ICatalogService
    {
        private EntityModel ents;

        public CatalogService()
        {
            ents = new EntityModel();
        }

        public CatalogService(EntityModel ents)
        {
            this.ents = ents;
        }

        public DiscountItem GetDiscount(DateTime _day)
        {
            return ents.DiscountItems.ToList().Where(y => y.Start.Date.Date <= _day.Date.Date && y.End.Date.Date >= _day.Date.Date).FirstOrDefault();
        }

        public CatalogItem FindCatalogItem(int id)
        {
            CatalogItem item = ents.CatalogItems.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.CatalogBrand = ents.CatalogBrands.FirstOrDefault(x => x.Id == item.CatalogBrandId);
                item.CatalogType = ents.CatalogTypes.FirstOrDefault(x => x.Id == item.CatalogTypeId);

                return item;
            }
            else
                return null;
        }
        public List<CatalogType> GetCatalogTypes()
        {
            return ents.CatalogTypes.ToList();
        }

        public List<CatalogBrand> GetCatalogBrands()
        {
            return ents.CatalogBrands.ToList();
        }

        public List<CatalogItem> GetCatalogItems(int brandIdFilter, int typeIdFilter)
        {
            bool brandFilterIsNull = brandIdFilter == 0;
            bool typeFilterIsNull = typeIdFilter == 0;
            return ents.CatalogItems.ToList().Where(x =>
                (brandFilterIsNull ? true : x.CatalogBrandId == brandIdFilter) &&
                (typeFilterIsNull ? true : x.CatalogTypeId == typeIdFilter)).ToList();
        }

        public void CreateCatalogItem(CatalogItem catalogItem)
        {
            var maxId = ents.CatalogItems.Max(i => i.Id);
            catalogItem.Id = ++maxId;
            ents.CatalogItems.Add(catalogItem);
            ents.SaveChanges();
        }

        public void UpdateCatalogItem(CatalogItem catalogItem)
        {
            ents.Entry(catalogItem).State = EntityState.Modified;
            ents.SaveChanges();
        }

        public void RemoveCatalogItem(CatalogItem catalogItem)
        {
            ents.CatalogItems.Remove(catalogItem);
            ents.SaveChanges();
        }

        public void Dispose()
        {
            ents.Dispose();
        }

        public int GetAvailableStock(DateTime date, int catalogItemId)
        {
            CatalogItemsStock s = ents.CatalogItemsStocks.Where(x => x.CatalogItemId == catalogItemId).ToList().Where(y => y.Date.Date == date.Date).FirstOrDefault();
            if (s != null)
                return s.AvailableStock;
            else
                return 0;
        }

        public void CreateAvailableStock(CatalogItemsStock catalogItemsStock)
        {
            CatalogItemsStock s = ents.CatalogItemsStocks.Where(x => x.CatalogItemId == catalogItemsStock.CatalogItemId).ToList()
                    .Where(y => y.Date.Date == catalogItemsStock.Date.Date).FirstOrDefault();

            /* Overwrite the existing stock item for that date if we already have one for this item. Otherwise, make a new entry*/
            if (s != null)
            {
                s.AvailableStock = catalogItemsStock.AvailableStock;
                ents.Entry(s).State = EntityState.Modified;
                ents.SaveChanges();
            }
            else
            {
                var maxId = ents.CatalogItemsStocks.Max(i => i.StockId);
                catalogItemsStock.StockId = ++maxId;
                ents.CatalogItemsStocks.Add(catalogItemsStock);
                ents.SaveChanges();
            }
        }
    }
}
