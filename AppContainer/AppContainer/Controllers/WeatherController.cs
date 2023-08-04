using AppContainer.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppContainer.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var apiKey = "e61816fa1b82c8be23ee53b95f92deb3";
            var CityWeathers = new List<WeatherModel>();
            List<string> Cities = new List<string>();
            Cities.Add("Istanbul");
            Cities.Add("Norway");
            Cities.Add("Beijing");
            Cities.Add("Skopje");
            var _httpClient = new HttpClient();
            foreach (var cityname in Cities)
            {
                var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={cityname}&appid={apiKey}");
                var WeatherJson = await response.Content.ReadAsStringAsync();
                var CityObject = WeatherModel.FromJson(WeatherJson);
                CityWeathers.Add(CityObject);
            }
            return View(CityWeathers);
        }
    }
}

