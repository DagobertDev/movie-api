using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Domain;
using MovieApi.Services;

namespace MovieApi.Controllers;

[ApiController]
[AllowAnonymous]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
	private readonly IMovieService _movieService;

	public MoviesController(IMovieService movieService)
	{
		_movieService = movieService;
	}

	[HttpGet]
	public Task<IEnumerable<Movie>> GetAll()
	{
		return _movieService.GetTrendingMovies();
	}

	[HttpGet("{id:int}")]
	public Task<Movie?> GetById(int id)
	{
		return _movieService.GetMovie(id);
	}
}
