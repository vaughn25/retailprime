using System.Data;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace Prime.Library.Repositories.Database
{
    public static class DbFactory 
    {
        /// <summary>
        /// Takes an incoming provider name and returns the corresponding DbProviderFactory.
        /// Throws a NotSupportedException if the provider is not supported.
        /// Currently only caters for "Microsoft.Data.SqlClient".
        /// </summary>
        /// <param name="providerName"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public static DbProviderFactory GetFactory(string providerName)
        {
            return providerName.ToLower() switch
            {
                "microsoft.data.sqlclient" => SqlClientFactory.Instance,
                _ => throw new NotSupportedException($"The provider '{providerName}' is not supported.")
            };
        }

        /// <summary>
        /// With a provided providername and connection string, creates and returns an IDbConnection.
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static IDbConnection CreateConnection(string providerName, string connectionString)
        {
            var factory = GetFactory(providerName);
            var connection = factory.CreateConnection();
            if (connection is null)
                throw new InvalidOperationException("Failed to create database connection.");

            connection.ConnectionString = connectionString;
            return connection;
        }
    }

}
