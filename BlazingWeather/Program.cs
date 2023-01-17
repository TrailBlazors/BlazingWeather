using BlazingWeather;
using BlazingWeather.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Solutaris.InfoWARE.ProtectedBrowserStorage.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// get config from wwwroot/appsettings.json
var apiConfig = builder.Configuration.GetSection("ApiSettings");
var openWeatherBaseUrl = apiConfig.GetValue<string>("OpenWeatherApiBaseUrl");
var geoCodingBaseUrl = apiConfig.GetValue<string>("GeoCodingApiBaseUrl");
var forecastUrl = apiConfig.GetValue<string>("OpenWeatherApiForecastUrl");
var apiKey = apiConfig.GetValue<string>("OpenWeatherApiKey");
openWeatherBaseUrl += $"?appid={apiKey}";
geoCodingBaseUrl += $"?appid={apiKey}";
forecastUrl += $"?appid={apiKey}";

// register custom services
builder.Services.AddHttpClient<GeoCodingService>(
    c => c.BaseAddress = new Uri(geoCodingBaseUrl));
    
builder.Services.AddHttpClient<WeatherService>(c =>
        c.BaseAddress = new Uri(openWeatherBaseUrl));

builder.Services.AddHttpClient<ForecastService>(c =>
        c.BaseAddress = new Uri(forecastUrl));


// required for protected storage locally and in session
builder.Services.AddIWProtectedBrowserStorageAsSingleton();

await builder.Build().RunAsync();
