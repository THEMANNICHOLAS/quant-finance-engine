using System.Text;
using Microsoft.AspNetCore.Mvc.TagHelpers;


namespace OptionVisualizer.Server.Services.Api.Requests{

    public class RequestUrlBuilder{

        public static string Build (
                            IEnumerable<KeyValuePair<string, string?>> queryParams,
                            string baseURL, 
                            string endpoint)
        {
            if (string.IsNullOrWhiteSpace(baseURL)){
                throw new ArgumentException("Base Url is needed");
            }
            if (string.IsNullOrWhiteSpace(endpoint)){
                throw new ArgumentException("Endpoint path is needed");
            }

            //Prep url paths 
            string basePath = baseURL.TrimEnd('/'); //i.e https://api.marketdata.app
            string endpointPath = endpoint.TrimEnd('/'); //i.e /v1/options/expiration/NYYSE%3ASPY

            var urlParts = new List<string>();

            foreach (var pair in queryParams){
                if(string.IsNullOrWhiteSpace(pair.Value)){
                    continue; //skip the empty pairs as a lot are optional
                }
                if(string.IsNullOrWhiteSpace(pair.Key)){
                    continue;
                }
                //Establish the new key-values that will be appended
                var key = Uri.EscapeDataString(pair.Key);
                var value = Uri.EscapeDataString(pair.Value);

                urlParts.Add($"{key}={value}");
            }
            //If nothing to append,  just return the URI by itself
            if (urlParts.Count == 0){
                return $"{basePath}{endpointPath}";
            }

            return $"{basePath}{endpointPath}?{string.Join("&", urlParts)}";

        }







    }


}