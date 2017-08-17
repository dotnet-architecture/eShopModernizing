using System.ComponentModel.DataAnnotations;

namespace eShopCatalogMVC.Models
{
    public class CatalogItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        // decimal(18,2)
        [RegularExpression(@"^\d+(\.\d{0,2})*$", ErrorMessage = "The field Price must be a positive number with maximum two decimals.")]
        [Range(0, 9999999999999999.99)] 
        public decimal Price { get; set; }

        public string PictureFileName { get; set; }

        public int CatalogTypeId { get; set; }

        public CatalogType CatalogType { get; set; }

        public int CatalogBrandId { get; set; }

        public CatalogBrand CatalogBrand { get; set; }

        // Quantity in stock
        [Range(0, int.MaxValue)]
        public int AvailableStock { get; set; }

        // Available stock at which we should reorder
        [Range(0, int.MaxValue)]
        public int RestockThreshold { get; set; }

        // Maximum number of units that can be in-stock at any time (due to physicial/logistical constraints in warehouses)
        [Range(0, int.MaxValue)]
        public int MaxStockThreshold { get; set; }

        /// <summary>
        /// True if item is on reorder
        /// </summary>
        public bool OnReorder { get; set; }
    }
}