using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eShopCatalogMVC.Models
{
    public class CatalogDBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CatalogDBContext() : base("name=CatalogDBContext")
        {
        }

        public System.Data.Entity.DbSet<eShopCatalogMVC.Models.CatalogItem> CatalogItems { get; set; }

        public System.Data.Entity.DbSet<eShopCatalogMVC.Models.CatalogBrand> CatalogBrands { get; set; }

        public System.Data.Entity.DbSet<eShopCatalogMVC.Models.CatalogType> CatalogTypes { get; set; }
    }
}
