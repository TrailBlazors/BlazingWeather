using BlazingWeather.Models;
using System.Net.Http.Json;
using System.Web;

namespace BlazingWeather.Services
{
    public class GeoCodingService
    {
        private readonly HttpClient _httpClient;

        public GeoCodingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
                
        public async Task<GeoCodingResponse?> GetCoordinatesByZipCode(string zipCode)
        {
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress!);
            var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
            queryString["zip"] = zipCode;
            uriBuilder.Query = queryString.ToString();

            return await _httpClient.GetFromJsonAsync<GeoCodingResponse>(uriBuilder.Uri);
        }
    }
}
