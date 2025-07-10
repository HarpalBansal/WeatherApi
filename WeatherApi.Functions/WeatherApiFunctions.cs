using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;

namespace WeatherApi.Functions
{
    public class WeatherApiFunctions
    {       
        private readonly IWeatherApiService _weatherApiService;
        public WeatherApiFunctions()
        {
            _weatherApiService = new WeatherApiService();
        }

        [Function("GetWeatherData")]
        public IActionResult GetWeatherData([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {
            return new OkObjectResult("Welcome to Azure Functions!");
        }

        [Function("GetWeatherDataByCity")]
        public async Task<IActionResult> GetWeatherDataByCity(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "weather/{cityName}")] HttpRequest req,
            string cityName)
        {
            // Here you would call your WeatherApiService to get the weather data
            // For example:
            var weatherData = await _weatherApiService.GetWeatherAsync(cityName);
            // Simulating a response for demonstration purposes
            return new OkObjectResult(weatherData);
        }
    }
}
