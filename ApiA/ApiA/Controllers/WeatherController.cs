using Microsoft.AspNetCore.Mvc;

namespace ApiA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetWeather()
        {
            return Ok(new { 
                Temperature = "30°C", 
                Condition = "Sunny", 
                Message = "Weather API is working!" 
            });
        }
    }
}
