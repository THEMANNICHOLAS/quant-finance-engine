using System.Net.Http.Json;

namespace OptionVisualizer.Server.Services
{
    public class MarketDataService
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor for the HTTP client from marketdata.app
        /// </summary>
        /// <param name="httpClient"></param>
        public MarketDataService(HttpClient httpClient){
            _httpClient = httpClient;
        }

        public async Task<MarketData> GetMarketDataAsync(string symbol){
            
            return 
        }
}
