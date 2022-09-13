using System.Net;
using Microsoft.EntityFrameworkCore;
using MovieApi.Model;

namespace MovieApi.Services;

public class MovieService : IMovieService
{
	private const string BaseUri = "https://api.themoviedb.org/3/";

	private readonly HttpClient _httpClient;
	private readonly string _key;
	private readonly MovieContext _movieContext;

	public MovieService(HttpClient httpClient, IConfiguration configuration, MovieContext movieContext)
	{
		ArgumentNullException.ThrowIfNull(configuration);
		_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
		_movieContext = movieContext ?? throw new ArgumentNullException(nameof(movieContext));
		_key = configuration.GetValue<string>("MovieDBKey");
	}

	public async Task<IEnumerable<Movie>> GetTrendingMovies()
	{
		var uri = $"{BaseUri}/trending/movie/week?api_key={_key}";

		var movies = await _httpClient.GetFromJsonAsync<TrendingResponse>(uri);
		return movies?.Results.Select(movie => new Movie(movie.Id, movie.Title)) ?? Enumerable.Empty<Movie>();
	}

	public async Task<Movie?> GetMovie(int id)
	{
		var movie = await _movieContext.Movies.SingleOrDefaultAsync(movie => movie.Id == id);
		if (movie != null)
		{
			return movie;
		}

		var uri = $"{BaseUri}/movie/{id}?api_key={_key}";

		DBMovie? dbMovie;

		try
		{
			dbMovie = await _httpClient.GetFromJsonAsync<DBMovie>(uri);
		}
		catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.NotFound)
		{
			return null;
		}

		if (dbMovie == null)
		{
			return null;
		}

		movie = new Movie(dbMovie.Id, dbMovie.Title);
		await SaveMovie(movie);
		return movie;
	}

	private async Task SaveMovie(Movie movie)
	{
		_movieContext.Movies.Add(movie);
		await _movieContext.SaveChangesAsync();
	}

	private record TrendingResponse(IEnumerable<DBMovie> Results);
}
