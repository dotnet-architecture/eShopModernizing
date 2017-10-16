using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace eShopModernizedWebForms
{
    public class CatalogConfiguration
    {
        private static readonly string configConnectionName = "CatalogDBContext";

        public static string ConnectionString
        {
            get
            {
                var envConnectionString = Environment.GetEnvironmentVariable("ConnectionString");
                return envConnectionString ?? $"name={configConnectionName}";
            }
        }

        public static bool UseMockData
        {
            get
            {
                return IsEnabled("UseMockData");
            }
        }

        public static bool UseCustomizationData
        {
            get
            {
                return IsEnabled("UseCustomizationData");
            }
        }

        public static bool UseAzureStorage
        {
            get
            {
                return IsEnabled("UseAzureStorage");
            }
        }

        public static string StorageConnectionString
        {
            get
            {
                return GetConfigurationValue("StorageConnectionString");
            }
        }

        public static string AppInsightsInstrumentationKey
        {
            get
            {
                return Environment.GetEnvironmentVariable("AppInsightsInstrumentationKey");
            }
        }

        public static bool UseAzureActiveDirectory
        {
            get
            {
                return IsEnabled("UseAzureActiveDirectory");
            }
        }

        public static string AzureActiveDirectoryClientId
        {
            get
            {
                return Environment.GetEnvironmentVariable("AzureActiveDirectoryClientId") ??
                    ConfigurationManager.AppSettings["ida:ClientId"];
            }
        }

        public static string AzureActiveDirectoryTenant
        {
            get
            {
                return Environment.GetEnvironmentVariable("AzureActiveDirectoryTenant") ??
                    ConfigurationManager.AppSettings["ida:Tenant"];
            }
        }

        public static string PostLogoutRedirectUri
        {
            get
            {
                return GetConfigurationValue("PostLogoutRedirectUri");
            }
        }

        private static string GetConfigurationValue(string configurationKey)
        {
            var environmentValue = Environment.GetEnvironmentVariable(configurationKey);
            return environmentValue ?? ConfigurationManager.AppSettings[configurationKey];
        }

        private static bool IsEnabled(string configurationKey)
        {
            var environmentValue = Environment.GetEnvironmentVariable(configurationKey);
            return environmentValue != null ?
                bool.Parse(environmentValue) :
                bool.Parse(ConfigurationManager.AppSettings[configurationKey]);
        }
    }
}