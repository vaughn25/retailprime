using System;


namespace Prime.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var provider = "Microsoft.Data.SqlClient";
            var connectionString = "Server=DESKTOP-CAK0VFF;Database=RetailPrime;Integrated Security=True;TrustServerCertificate=True";

            System.Console.WriteLine("Creating database factory...");

            try
            {

                var dbMigration = new Prime.Library.Repositories.Database.PrimeMigration();
                dbMigration.Initialize(provider,connectionString);

                System.Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Success!");
            }
            catch (Exception e)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine(e);
            }

            System.Console.ResetColor();
            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadKey();
        }
    }
}
