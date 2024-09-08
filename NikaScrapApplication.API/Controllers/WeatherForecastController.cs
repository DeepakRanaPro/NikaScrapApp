using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NikaScrapApplication.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the list of all WeatherForecast.
        /// </summary>
        /// <returns>The list of WeatherForecast.</returns>
        // GET: WeatherForecast/Get
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {

            throw new Exception("Exception while fetching all the students from the storage.");


            _logger.LogDebug("This is a debug message");
            _logger.LogInformation("This is an info message");
            _logger.LogWarning("This is a warning message ");
            _logger.LogError(new Exception(), "This is an error message");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        public WeatherForecast MyData(WeatherForecast weatherForecast)
        {
            return weatherForecast;
        }


        [HttpGet(Name = "GetUserInfo1"), Authorize(Roles ="User")]
        public string GetUserInfo1()
        {
            return "User";
        }

        [HttpGet(Name = "GetUserInfo2"), Authorize(Roles = "Admin")]
        public string GetUserInfo2()
        {
            return "Admin";
        }


        [HttpGet(Name = "GetUserInfo3"), Authorize(Roles = "Admin,User")]
        public string GetUserInfo3()
        {
            return "Admin,user";
        }

        [HttpGet(Name = "GetUserInfo4"), Authorize()]
        public string GetUserInfo4()
        {
            return "All User";
        }
    }
}
