using Microsoft.Azure.Services.AppAuthentication;
using System.Configuration;
using System.Data.SqlClient;

namespace eShopModernizedMVC
{
    public interface ISqlConnectionFactory
    {
        SqlConnection CreateConnection();
    }

    public class ManagedIdentitySqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly AzureServiceTokenProvider _provider;

        public ManagedIdentitySqlConnectionFactory()
        {
            _provider = new AzureServiceTokenProvider();
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection
            {
                AccessToken = AccessToken,
                ConnectionString = ConfigurationManager.ConnectionStrings["CatalogDBContext"].ConnectionString
            };
        }

        private string AccessToken
            => _provider.GetAccessTokenAsync("https://database.windows.net/").ConfigureAwait(false).GetAwaiter().GetResult();
    }

    public class AppSettingsSqlConnectionFactory : ISqlConnectionFactory
    {
        public SqlConnection CreateConnection()
        {
            return new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["CatalogDBContext"].ConnectionString
            };
        }
    }
}