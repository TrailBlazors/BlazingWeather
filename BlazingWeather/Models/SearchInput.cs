using System.ComponentModel.DataAnnotations;

namespace BlazingWeather.Models
{
    public class SearchInput
    {
        [Required(ErrorMessage = "Zip code is required.")]
        public string Zip { get; set; } = default!;
    }
}
