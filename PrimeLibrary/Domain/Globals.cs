

using System.Text.Json;

namespace Prime.Library.Domain
{
    public static class HttpGlobals
    {
        public const string BaseUrl = "https://localhost:7000/";

        public static HttpClient HttpClient = new HttpClient();

        public static JsonSerializerOptions SerializerOptions = new JsonSerializerOptions() 
        { 
            PropertyNameCaseInsensitive = true,
        };

        /// <summary>
        /// Initializes an HttpClient pointing to your desired endpoint. This must be called at least once at application start up. 
        /// You can specify a custom timeout (in seconds) if desired.
        /// </summary>
        /// <param name="clientTimeout"></param>
        public static void InitializeHttpClient(int clientTimeout = 30)
        {
            HttpClient.BaseAddress = new Uri(BaseUrl);
            HttpClient.Timeout = TimeSpan.FromSeconds(clientTimeout);
            HttpClient.DefaultRequestHeaders.Clear();
            HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }
    }
}
