using Microsoft.AspNetCore.Mvc;
using MovieApi.Model;

namespace MovieApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
	private static readonly Movie[] Movies =
	{
		new(1, "Movie 1"), new(2, "Movie 2"), new(3, "Movie 3"),
	};

	[HttpGet]
	public IEnumerable<Movie> GetAll()
	{
		return Movies;
	}

	[HttpGet("{id:int}")]
	public Movie? GetById(int id)
	{
		return Movies.SingleOrDefault(movie => movie.Id == id);
	}
}
