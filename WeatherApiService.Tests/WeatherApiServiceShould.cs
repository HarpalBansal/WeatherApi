using System.Diagnostics;
using WeatherApi.Model;

namespace WeatherApi.Tests
{
    [TestClass]
    public sealed class WeatherApiServiceTests
    {
        private WeatherApiService service;

        [TestInitialize]
        public void TestInit()
        {
            // This method is called before each test method.
            service = new WeatherApiService(); // Ensure WeatherApiService is a class in the correct namespace
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // This method is called after each test method.
        }

        [TestMethod]
        public async Task GetWeatherAsync_ValidCity_ReturnsWeatherData()
        {
            // Arrange
            var cityName = "London"; // Example valid city name

            // Act
            WeatherData weatherData = await service.GetWeatherAsync(cityName);

            // Assert
            Assert.IsNotNull(weatherData, "Result should not be empty for a valid city name."); //Checks if the weatherData object is null
            Assert.AreEqual(cityName, weatherData.Location.name, "Result should contain the correct city name."); //Checks if the cityName matches location in the WeatherData object

            // Checks that all properties of Location and Current are not null
            Assert.IsNotNull(weatherData.Location.name, "Result should not be empty");
            Assert.IsNotNull(weatherData.Location.region, "Result should not be empty");
            Assert.IsNotNull(weatherData.Location.country, "Result should not be empty");
            Assert.IsNotNull(weatherData.Location.lat, "Result should not be empty");
            Assert.IsNotNull(weatherData.Location.lon, "Result should not be empty");
            Assert.IsNotNull(weatherData.Location.tz_id, "Result should not be empty");
            Assert.IsNotNull(weatherData.Location.localtime_epoch, "Result should not be empty");
            Assert.IsNotNull(weatherData.Location.localtime, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.Condition.text, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.Condition.icon, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.Condition.code, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.last_updated_epoch, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.last_updated, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.temp_c, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.temp_f, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.is_day, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.wind_mph, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.wind_kph, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.wind_degree, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.wind_dir, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.pressure_mb, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.pressure_in, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.precip_mm, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.precip_in, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.humidity, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.cloud, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.feelslike_c, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.feelslike_f, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.windchill_c, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.windchill_f, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.heatindex_c, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.heatindex_f, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.dewpoint_c, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.dewpoint_f, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.vis_km, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.vis_miles, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.uv, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.gust_mph, "Result should not be empty");
            Assert.IsNotNull(weatherData.Current.gust_kph, "Result should not be empty");
        }

        [TestMethod]
        public async Task GetWeatherAsync_InvalidCity_ReturnsEmptyString()
        {
            // Arrange
            var cityName = "Smallville"; // Example invalid city name

            // Act & Assert
            var result = await service.GetWeatherAsync(cityName);
            Assert.IsNull(result, "Result should not be empty for a valid city name.");
        }
    }
}