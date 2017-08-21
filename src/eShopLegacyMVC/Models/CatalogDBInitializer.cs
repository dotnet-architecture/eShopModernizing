using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eShopCatalogMVC.Models
{
    public class CatalogDBInitializer : CreateDatabaseIfNotExists<CatalogDBContext>
    {
        protected override void Seed(CatalogDBContext context)
        {
            base.Seed(context);
        }
    }
}