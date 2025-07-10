using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApi.Model;
using WeatherApiService;

namespace WeatherApi
{
    public class WeatherApiService : IWeatherApiService
    {
        const string apiUrl = "https://api.weatherapi.com/v1/current.json?key=";
        private readonly string apiKey;
        private WeatherData weatherData;
        public WeatherApiService()
        {
            apiKey = "eb3d0ee23a114429b29144908250807";
            weatherData = new WeatherData();
        }



        public async Task<WeatherData> GetWeatherAsync(string cityName) //Method to get weather data from API and return it as a WeatherData object
        {
            string url = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={cityName}";
            Console.WriteLine(url);
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode(); // Throws exception if status code is not success

                    // contains weather data (json)
                    var responseBody = await response.Content.ReadAsStringAsync();
                    
                    WeatherData weatherData = responseBody.DeserializeToWeatherData();

                    return weatherData;
                }
                catch (HttpRequestException e)
                {
                    Debug.WriteLine($"Exception Caught! Message: {e.Message}");
                    return null; // Return an empty string or handle the error as needed
                }
            }
        }
    }
}

