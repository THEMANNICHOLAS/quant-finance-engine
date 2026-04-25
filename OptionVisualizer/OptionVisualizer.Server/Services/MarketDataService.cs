using System.Net.Http;

namespace OptionVisualizer.Server.Services;

public class MarketDataService
{
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Constructor for HttpClient taken from Program.cs for marketdata.app
    /// </summary>
    /// <param name="httpClient"></param>
    /// <exception cref="ArgumentNullException"></exception>    
    public MarketDataService(IHttpClientFactory httpClientFactory)
    {
        ArgumentNullException.ThrowIfNull(httpClientFactory);
        _httpClient = httpClientFactory.CreateClient("MarketData");
    }

    /// <summary>
    /// Placeholder until Market Data responses are modeled (e.g. expirations/strikes DTOs).
    /// </summary>
    public Task<string> GetMarketDataAsync(string symbol, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(symbol);
        throw new NotImplementedException();
    }
}
