using System.Text.Json;
using WeatherApi.Model;

namespace WeatherApiService
{
    public static class StringExtensions
    {
        //TODO: Make this method private, as it is only used internally to deserialise the response body
        /// <summary>
        /// 
        /// </summary>
        /// <param name="responseBody"></param>
        /// <returns></returns>
        public static WeatherData DeserializeToWeatherData(this string responseBody)
        {
            return JsonSerializer.Deserialize<WeatherData>(responseBody);
        }

    }
}
