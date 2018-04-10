using eShopWinForms.eShopServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopWinForms.Controllers
{
    public delegate void ViewHandler<ICatalogView>(ICatalogView sender, FilterEventArgs e);
    public delegate void AvailabilityHandler<ICatalogView>(ICatalogView sender, AvailabilityEventArgs e);
    public delegate void SearchStockHandler<ICatalogView>(ICatalogView sender, SearchStockEventArgs e);

    /*
     * Whenever we need to filter catalog items, we invoke an event and pass
     * arguments which hold the brand filter id and type filter id
     */
    public class FilterEventArgs : EventArgs
    {
        public int typeFilterValue;
        public int brandFilterValue;
        public FilterEventArgs(int typeId, int brandId)
        {
            typeFilterValue = typeId;
            brandFilterValue = brandId;
        }
    }

    /*
     * When we want to add stock availability for an item, we invoke an event
     * and pass the item's id, the date where the stock will be "available"
     * and count of the stock that will be available.
     */
    public class AvailabilityEventArgs : EventArgs
    {
        public int itemId;
        public int itemStock;
        public DateTime shipDate;

        public AvailabilityEventArgs(int id, int stock, DateTime ship)
        {
            itemId = id;
            itemStock = stock;
            shipDate = ship;

        }
    }

    /*
     * Whenever we need to look up the stock availability for an item on a given date, 
     * we invoke an event and pass the item id and desired date.
     */
    public class SearchStockEventArgs : EventArgs
    {
        public int itemId;
        public DateTime date;

        public SearchStockEventArgs(int id, DateTime thisDate)
        {
            itemId = id;
            date = thisDate;

        }
    }
    public interface ICatalogView
    {
        event ViewHandler<ICatalogView> filterChanged;
        event AvailabilityHandler<ICatalogView> availabilityButtonClicked;
        event SearchStockHandler<ICatalogView> searchStockButtonClicked;

        /*All of the methods we want our view to be able to do are defined below*/
        void SetController(CatalogController controller);
        void SetCatalogItems(IEnumerable<CatalogItem> items, double discountVal);
        void SetDiscountBanner(String bannerText);
        void SetTypeFilter(Dictionary<int, string> typeFilters);
        void SetBrandFilter(Dictionary<int, string> brandFilter);
        void ClearGrid();
        void NotifyAvailabilityUpdated();
        void ShowStockAvailability(SearchStockEventArgs args, int stock);
        void SetShipmentView(IEnumerable<CatalogItem> items);
    }
}
