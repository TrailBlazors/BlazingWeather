using System.Text.Json.Serialization;

namespace BlazingWeather.Models;

public class GeoCodingResponse
{
    [JsonPropertyName("zip")]
    public string Zip { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("lat")]
    public double Latitude { get; set; }

    [JsonPropertyName("lon")]
    public double Longitude { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }
}