using System.Data.SqlClient;

namespace eShopModernizedWebForms
{
    public interface ISqlConnectionFactory
    {
        SqlConnection CreateConnection();
    }

    public class ConnectionStringFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;

        public ConnectionStringFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection
            {
                ConnectionString = _connectionString,
            };
        }
    }
}