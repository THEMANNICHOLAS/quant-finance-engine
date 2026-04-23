
namespace OptionVisualizer.Server.Services.Api.Requests{

    //GET /v1/options/strikes/{underlying}/
public class StrikeRequest{
    //Required!!!
    //"Format" required to ensure JSON, defaults to JSON anyways
    public string Format { get; init; }= "json"; 
    public string Underlying { get; init; } = string.Empty;

    //Not Required
    public string? Date { get; init; } 
    public string? Expiration { get; init; }
    public string? DateFormat { get; init; }
    public int? Limit { get; init; }
    public int? Offset { get; init; }
    public bool? Headers { get; init; }
    public string? Columns { get; init; }
    public bool? Human { get; init; }

    public string GetPath (){
        if (string.IsNullOrWhiteSpace(Underlying)){
            throw new ArgumentException("Underlying is required", nameof(Underlying));
        }
        return $"/v1/options/strikes/{Uri.EscapeDataString(Underlying)}/";
    }

    public IEnumerable<KeyValuePair<string, string?>> ToQueryParams (){
        yield return new("format", Format);
        yield return new("date", Date);
        yield return new("expiration", Expiration);
        yield return new("dateformat", DateFormat);
        yield return new("limit", Limit?.ToString());
        yield return new("offset", Offset?.ToString());
        yield return new("headers", Headers?.ToString()?.ToLowerInvariant());
        yield return new("columns", Columns);
        yield return new("human", Human?.ToString()?.ToLowerInvariant());



    }










}
}