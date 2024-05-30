using Microsoft.AspNetCore.Mvc;

namespace DiscordKiller.Examples.AspNetCore.WebAPI.Controllers;

[ApiController]
[Route("weather")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ApplicationDBContext _applicationDbContext;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationDBContext applicationDbContext)
    {
        _logger = logger;
        _applicationDbContext = applicationDbContext;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return _applicationDbContext.WeatherForecasts.ToList();
    }

    [HttpGet("five")]
    public IEnumerable<WeatherForecast> Get5()
    {
        return _applicationDbContext.WeatherForecasts.Take(5).ToList();
    }
    
    [HttpGet("ten")]
    public IEnumerable<WeatherForecast> Get10()
    {
        return _applicationDbContext.WeatherForecasts.Take(10).ToList();
    }

    [HttpPost]
    public IActionResult AddMeasurement(WeatherForecast weatherForecast)
    {
        if (weatherForecast.TemperatureC < -273)
        {
            return BadRequest("Нельзя указывать температуру меньше 273");
        }

        _applicationDbContext.WeatherForecasts.Add(weatherForecast);
        _applicationDbContext.SaveChanges();
        return Ok();
    }
}