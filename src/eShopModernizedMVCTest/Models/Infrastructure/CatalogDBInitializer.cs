using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace eShopLegacyMVC.Models.Infrastructure
{
    public class CatalogDBInitializer : CreateDatabaseIfNotExists<CatalogDBContext>
    {
        private const string DBCatalogSequenceName = "catalog_type_hilo";
        private const string DBBrandSequenceName = "catalog_brand_hilo";
        private const string CatalogItemHiLoSequenceScript = @"Models\Infrastructure\dbo.catalog_hilo.Sequence.sql";
        private const string CatalogBrandHiLoSequenceScript = @"Models\Infrastructure\dbo.catalog_brand_hilo.Sequence.sql";
        private const string CatalogTypeHiLoSequenceScript = @"Models\Infrastructure\dbo.catalog_type_hilo.Sequence.sql";

        private CatalogItemHiLoGenerator indexGenerator;

        public CatalogDBInitializer(CatalogItemHiLoGenerator indexGenerator)
        {
            this.indexGenerator = indexGenerator;
        }

        protected override void Seed(CatalogDBContext context)
        {
            ExecuteScript(context, CatalogItemHiLoSequenceScript);
            ExecuteScript(context, CatalogBrandHiLoSequenceScript);
            ExecuteScript(context, CatalogTypeHiLoSequenceScript);

            AddCatalogTypes(context);
            AddCatalogBrands(context);
            AddCatalogItems(context);
        }

        private void AddCatalogTypes(CatalogDBContext context)
        {
            var preconfiguredTypes = PreconfiguredData.GetPreconfiguredCatalogTypes();
            int sequenceId = GetSequenceIdFromSelectedDBSequence(context, DBCatalogSequenceName);
            foreach (var type in preconfiguredTypes)
            {
                type.Id = sequenceId;
                context.CatalogTypes.Add(type);
                sequenceId++;
            }

            context.SaveChanges();
        }

        private void AddCatalogBrands(CatalogDBContext context)
        {
            var preconfiguredBrands = PreconfiguredData.GetPreconfiguredCatalogBrands();
            int sequenceId = GetSequenceIdFromSelectedDBSequence(context, DBBrandSequenceName);
            foreach (var brand in preconfiguredBrands)
            {
                brand.Id = sequenceId;
                context.CatalogBrands.Add(brand);
                sequenceId++;
            }

            context.SaveChanges();
        }

        private void AddCatalogItems(CatalogDBContext context)
        {
            var preconfiguredItems = PreconfiguredData.GetPreconfiguredCatalogItems();
            foreach (var item in preconfiguredItems)
            {
                var sequenceId = indexGenerator.GetNextSequenceValue(context);
                item.Id = sequenceId;
                context.CatalogItems.Add(item);
            }

            context.SaveChanges();
        }

        private static int GetSequenceIdFromSelectedDBSequence(CatalogDBContext context, string dBSequenceName)
        {
            var rawQuery = context.Database.SqlQuery<Int64>($"SELECT NEXT VALUE FOR {dBSequenceName}");
            var sequenceId = (int)rawQuery.Single();
            return sequenceId;
        }

        private void ExecuteScript(CatalogDBContext context, string scriptFile)
        {
            var scriptFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, scriptFile);
            context.Database.ExecuteSqlCommand(File.ReadAllText(scriptFilePath));
        }
    }
}