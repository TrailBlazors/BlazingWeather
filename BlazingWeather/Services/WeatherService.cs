using BlazingWeather.CurrentWeather.Models;
using System.Net.Http.Json;
using System.Web;

namespace BlazingWeather.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService (HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }
        
        public async Task<CurrentWeatherResponse?> GetCurrentWeather(double lat, double lon)
        {                                   
            // build a proper querystring
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress);
            var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
            queryString["lat"] = lat.ToString();
            queryString["lon"] = lon.ToString();
            queryString["units"] = "imperial"; // for temperature
            uriBuilder.Query = queryString.ToString();

            return await _httpClient.GetFromJsonAsync<CurrentWeatherResponse>(uriBuilder.Uri);                                          
        }
       
    }
}
