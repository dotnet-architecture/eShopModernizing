using System.Collections.Generic;
using System.Net;
using eShopWinForms.eShopServiceReference;
using System;

namespace eShopWinForms.Controllers
{
    public class CatalogController
    {
        /*Reference to the service (for fetching data) and the view (so we can tell the view how to update)*/
        private ICatalogService _service;
        private ICatalogView _view;

        public CatalogController(ICatalogService service, ICatalogView view)
        {
            this._service = service;
            this._view = view;
            this._view.filterChanged += new ViewHandler<ICatalogView>(this.filterChanged);
            this._view.availabilityButtonClicked += new AvailabilityHandler<ICatalogView>(this.addAvailability);
            this._view.searchStockButtonClicked += new SearchStockHandler<ICatalogView>(this.searchStockAvailable);
        }

        /*
         * When a filter is changed in the view, we need to request all catalog items
         * in the database which satisfy the new filter
         */
        private void filterChanged(ICatalogView view, FilterEventArgs e)
        {
            LoadCatalogItems(e.brandFilterValue, e.typeFilterValue);
        }

        /*
         * Adds a new "shipment" to the database for the given day, item id, and stock quantity
         */
        private void addAvailability(ICatalogView view, AvailabilityEventArgs e)
        {
            CatalogItemsStock shipment = new CatalogItemsStock();
            shipment.CatalogItemId = e.itemId;
            shipment.AvailableStock = e.itemStock;
            shipment.Date = e.shipDate;

            _service.CreateAvailableStock(shipment);
            _view.NotifyAvailabilityUpdated();
        }

        /*
         * Gets the number of stock available for a given item and date, then updates the 
         * view to reflect the result.
         */
        private void searchStockAvailable(ICatalogView view, SearchStockEventArgs e)
        {
            int res = _service.GetAvailableStock(e.date, e.itemId);

            _view.ShowStockAvailability(e, res);
        }

        /*
         * Queries the service to see if a discount is running for today. If so, it will update the view's discount banner
         */
        private void CheckForDiscounts()
        {
            double discountPercentage = 0;
            DiscountItem discount = _service.GetDiscount(DateTime.Now);
            if (discount != null)
            {
                discountPercentage = Math.Round(discount.Size * 100, 0);
                String bannerText = String.Format("{0}% sale endson {1}!", discountPercentage.ToString(), discount.End.ToShortDateString());
                _view.SetDiscountBanner(bannerText);
            }
        }

        /*
         * Queries the service for all catalog items which match the brand and type filter (if any)
         */
        public void LoadCatalogItems(int brandIdFilter, int typeIdFilter)
        {
            _view.ClearGrid();
            IEnumerable<CatalogItem> items = _service.GetCatalogItems(brandIdFilter, typeIdFilter);
            double discountVal = 0;
            DiscountItem discount = _service.GetDiscount(DateTime.Now);
            if (discount != null)
                discountVal = discount.Size;

            _view.SetCatalogItems(items, discountVal);
        }


        private void SetShipmentView()
        {
            IEnumerable<CatalogItem> items = _service.GetCatalogItems(0, 0);
            _view.SetShipmentView(items);
        }

        /*
         * Queries the service for all brand filters and then updates the view with
         * the result of the query
         */
        private void LoadBrandFilters()
        {
            //Fetch the list of catalog item brands
            IEnumerable<CatalogBrand> brands = _service.GetCatalogBrands();

            // Bind combobox to dictionary
            Dictionary<int, string> brandDictionary = new Dictionary<int, string>();

            //The service does not return an 'all' item by default, so we must add it.
            brandDictionary.Add(0, "All");

            // Add rest of type filters
            foreach (var catalogBrand in brands)
            {
                int idValue = catalogBrand.Id;
                string typeValue = catalogBrand.Brand;
                brandDictionary.Add(idValue, typeValue);
            }

            _view.SetBrandFilter(brandDictionary);
        }

        /*
         * Queries the service for all type filters and then updates the view with
         * the result of the query
         */
        private void LoadTypeFilters()
        {
            //Fetch the list of catalog item types
            IEnumerable<CatalogType> types = _service.GetCatalogTypes();

            // Bind combobox to dictionary
            Dictionary<int, string> typeDictionary = new Dictionary<int, string>();

            //The service does not return an 'all' item by default, so we must add it.
            typeDictionary.Add(0, "All");

            // Add rest of type filters
            foreach (var catalogtype in types)
            {
                int idValue = catalogtype.Id;
                string typeValue = catalogtype.Type;
                typeDictionary.Add(idValue, typeValue);
            }

            _view.SetTypeFilter(typeDictionary);
        }

        /*
         * Called at the beginning of the lifecycle of the controller
         * to set up our view and get all inital data
         */
        public void LoadView()
        {
            _view.SetController(this);
            CheckForDiscounts();
            LoadCatalogItems(0, 0);
            LoadBrandFilters();
            LoadTypeFilters();
            SetShipmentView();
        }
    }
}
