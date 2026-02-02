using DbUp;

namespace Prime.Library.Repositories.Database
{
    public class PrimeMigration
    {
        /// <summary>
        /// Initializes the database by ensuring its existence and applying any pending migrations using embedded
        /// scripts.
        /// </summary>
        /// <param name="providerName">The name of the database provider.</param>
        /// <param name="connectionString">The connection string used to connect to the database.</param>
        /// <exception cref="Exception">Thrown if the database migration fails.</exception>
        public void Initialize(string providerName, string connectionString)
        {
            using var connection = DbFactory.CreateConnection(providerName,connectionString);
            {
                EnsureDatabase.For.SqlDatabase(connection.ConnectionString);
            }

            var upgrader = DeployChanges.To.
                SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(typeof(PrimeMigration).Assembly)
                .LogToConsole()
                .Build();

            if (!upgrader.IsUpgradeRequired()) return;
            
            var result = upgrader.PerformUpgrade();
            if (!result.Successful)
                throw new Exception("Database migration failed", result.Error);
            
            Console.WriteLine("Database migration completed successfully.");
        }
    }
}
