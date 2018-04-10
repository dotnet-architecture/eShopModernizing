using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShopWCFService.Models.Infrastructure
{
    public class CatalogConfiguration
    {
        private static readonly string configConnectionName = "EntityModel";

        public static string ConnectionString
        {
            get
            {
                var envConnectionString = Environment.GetEnvironmentVariable("ConnectionString");
                return envConnectionString ?? $"name={configConnectionName}";
            }
        }
    }
}