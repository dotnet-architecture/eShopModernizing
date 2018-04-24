using eShopWCFService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace eShopWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICatalogService : IDisposable
    {
        [OperationContract]
        CatalogItem FindCatalogItem(int id);
        [OperationContract]
        List<CatalogBrand> GetCatalogBrands();
        [OperationContract]
        List<CatalogItem> GetCatalogItems(int brandIdFilter, int typeIdFilter);
        [OperationContract]
        List<CatalogType> GetCatalogTypes();
        [OperationContract]
        int GetAvailableStock(System.DateTime date, int catalogItemId);
        [OperationContract]
        void CreateAvailableStock(CatalogItemsStock catalogItemsStock);
        [OperationContract]
        void CreateCatalogItem(CatalogItem catalogItem);
        [OperationContract]
        void UpdateCatalogItem(CatalogItem catalogItem);
        [OperationContract]
        void RemoveCatalogItem(CatalogItem catalogItem);
        [OperationContract]
        DiscountItem GetDiscount(DateTime day);
    }
}
