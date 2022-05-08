using Microsoft.AspNetCore.Mvc;
using MovieApi.Model;

namespace MovieApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private static readonly Movie[] Movies = new[]
    {
        new ("Freezing"), new("Bracing"), new("Chilly"), new Movie("Cool"), new("Mild"), 
        new ("Warm"), new("Balmy"), new("Hot"), new("Sweltering"), new("Scorching"),
    };

    private readonly ILogger<MovieController> _logger;

    public MovieController(ILogger<MovieController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();
	}
}
