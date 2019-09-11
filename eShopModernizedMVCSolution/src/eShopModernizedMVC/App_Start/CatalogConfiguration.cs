using System.Configuration;

namespace eShopModernizedMVC
{
    public class CatalogConfiguration
    {

        public static bool UseMockData
        {
            get
            {
                return IsEnabled("UseMockData");
            }
        }

        public static bool UseAzureStorage
        {
            get
            {
                return IsEnabled("UseAzureStorage");
            }
        }

        public static bool UseManagedIdentity
        {
            get
            {
                return IsEnabled("UseAzureManagedIdentity");
            }
        }

        public static bool UseCustomizationData
        {
            get
            {
                return IsEnabled("UseCustomizationData");
            }
        }

        public static string StorageConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["StorageConnectionString"];
            }
        }

        public static string AppInsightsInstrumentationKey
        {
            get
            {
                return ConfigurationManager.AppSettings["AppInsightsInstrumentationKey"];
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
                return ConfigurationManager.AppSettings["AzureActiveDirectoryClientId"];
            }
        }

        public static string AzureActiveDirectoryTenant
        {
            get
            {
                return ConfigurationManager.AppSettings["AzureActiveDirectoryTenant"];
            }
        }

        public static string PostLogoutRedirectUri
        {
            get
            {
                return ConfigurationManager.AppSettings["PostLogoutRedirectUri"];
            }
        }

        private static bool IsEnabled(string configurationKey)
        {
            return bool.Parse(ConfigurationManager.AppSettings[configurationKey]);
        }
    }
}