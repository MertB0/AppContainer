using AppContainer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;

namespace AppContainer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
          
           
        }


        public IActionResult Index()
        {
         
            
                var model = new List<AppContainerModel>();
            model.Add(new AppContainerModel { Image = "/Image/ToDoList.png", AppsController = "ToDoList", AppAction = "Index", ShadowColor = "#2cd1a8" });
                model.Add(new AppContainerModel { Image = "/Image/BMI.png", AppsController = "BMI", AppAction = "Index", ShadowColor = "#243d82" });
                model.Add(new AppContainerModel { Image = "/Image/random.png", AppsController = "RandomQuotes", AppAction = "Index", ShadowColor = "#ff0022" });
                model.Add(new AppContainerModel { Image = "/Image/weather.png", AppsController = "Weather", AppAction = "Index", ShadowColor = "#e0d426" });
                return View(model);

            
        }
       


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}