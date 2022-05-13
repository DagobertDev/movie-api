using MovieApi.Model;

namespace MovieApi.Services;

public class MovieService : IMovieService
{
	private const string BaseUri = "https://api.themoviedb.org/3/";

	private readonly HttpClient _httpClient;
	private readonly string _key;

	public MovieService(HttpClient httpClient, IConfiguration configuration)
	{
		_httpClient = httpClient;
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
		var uri = $"{BaseUri}/movie/{id}?api_key={_key}";

		var movie = await _httpClient.GetFromJsonAsync<DBMovie>(uri);
		return movie == null ? null : new Movie(movie.Id, movie.Title);
	}

	private record TrendingResponse(IEnumerable<DBMovie> Results);
}
