
using System.Text.Json.Serialization;
namespace WeatherApi.Model
{
    public partial class WeatherData
    {
        [JsonPropertyName("location")]
        public LocationInfo Location { get; set; }

        [JsonPropertyName("current")]
        public CurrentReadings Current { get; set; }
    }
}