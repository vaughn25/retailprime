using Prime.Library.Domain;

namespace RetailPrime
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Initialize the HttpClient for API communication
            HttpGlobals.InitializeHttpClient();

            Application.Run(new Login());
        }
    }
}