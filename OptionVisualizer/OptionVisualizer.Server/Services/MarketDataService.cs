using System.Net.Http;
using System.Text.Json;
using OptionVisualizer.Server.Services.Api.Requests;

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
    public async Task<JsonDocument> GetExpirationsAsync(ExpirationsRequest request,
    CancellationToken cancellationToken = default
    )
    {
        //Verify that the request has an requested underlying.
        ArgumentNullException.ThrowIfNull(request);
        ArgumentNullException.ThrowIfNullOrWhiteSpace(request.Underlying);

        //Make prerequisites for  REquestURLBuilder
        var path = request.GetPath();
        var query = request.ToQueryParams();
        //Retrieves set base url: "Https://api.marketdata.app/
        var baseUrl = _httpClient.BaseAddress?.ToString()
        ?? throw new InvalidOperationException("MarketData HttpClient BaseAddress is not configured.");

        var url = RequestUrlBuilder.Build(query, baseUrl, path);

        //Await response from the endpoint in Async mode and make sure it returns positive
        using var response = await _httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        //Stream
        await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        return await JsonDocument.ParseAsync(stream, cancellationToken: cancellationToken);

    }



}

