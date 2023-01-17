using BlazingWeather.Forecast.Models;
using System.Net.Http.Json;
using System.Web;

namespace BlazingWeather.Services
{
    public class ForecastService
    {
        private readonly HttpClient _httpClient;

        public ForecastService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }      

       
        public async Task<ForecastResponse?> GetDailyForecast(double latitude, double longitude)
        {
            // build a proper querystring
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress);
            var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
            queryString["lat"] = latitude.ToString();
            queryString["lon"] = longitude.ToString();
            queryString["units"] = "imperial"; // for temperature
            queryString["cnt"] = "5"; // 5 daily forecasts to fetch
            uriBuilder.Query = queryString.ToString();

            return await _httpClient.GetFromJsonAsync<ForecastResponse>(uriBuilder.Uri);
           
        }

    }
}
