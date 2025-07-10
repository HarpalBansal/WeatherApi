using System.Threading.Tasks;
using WeatherApi.Model;

namespace WeatherApi
{
    public interface IWeatherApiService
    {
        Task<WeatherData> GetWeatherAsync(string cityName);
    }
}