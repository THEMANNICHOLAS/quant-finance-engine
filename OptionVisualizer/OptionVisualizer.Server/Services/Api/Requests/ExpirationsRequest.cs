
using Microsoft.AspNetCore.Mvc.Routing;

namespace OptionVisualizer.Server.Services.Api.Requests
{
    //URL reference: https://api.marketdata.app/#/
    public sealed class ExpirationsRequest
    {
        //Copying shape of GET/v1/options/expirations/{underlying}/

        //Required!!!
        public string Format { get; init; } = "json";
        public string Underlying { get; init; } = string.Empty;

        //Not Required
        public string? Strike { get; init; }
        public string? Date { get; init; }
        public string? DateFormat { get; init; }

        public ExpirationsRequest(string Underlying)
        {
            this.Underlying = Underlying;
        }




        /// <summary>
        /// Creates a safe URL string for API requests
        /// </summary>
        /// <returns>Endpoint with special char URL encoding</returns>
        /// <exception cref="ArgumentException"></exception>
        public string GetPath()
        {
            if (string.IsNullOrWhiteSpace(Underlying))
            {
                throw new ArgumentException("Underlying is required", nameof(Underlying));
            }
            return $"/v1/options/expirations/{Uri.EscapeDataString(Underlying)}/";
        }
        /// <summary>
        /// Yield Expiration request specific query values
        /// </summary>
        /// <returns>Key-Value pairs of query value</returns>
        public IEnumerable<KeyValuePair<string, string?>> ToQueryParams()
        {
            yield return new("format", Format);
            yield return new("date", Date);
            yield return new("strike", Strike);
            yield return new("dateformat", DateFormat);
        }

        //TODO: Create client/service convert to populate Null fields.
    }
}
