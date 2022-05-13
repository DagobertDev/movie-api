using MovieApi.Model;

namespace MovieApi.Services;

public interface IMovieService
{
	Task<IEnumerable<Movie>> GetTrendingMovies();
	Task<Movie?> GetMovie(int id);
}
