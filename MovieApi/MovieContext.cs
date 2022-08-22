using Microsoft.EntityFrameworkCore;
using MovieApi.Model;
using MovieApi.ModelConfigurations;

namespace MovieApi;

public class MovieContext : DbContext
{
	public MovieContext(DbContextOptions<MovieContext> context) : base(context) { }

	public DbSet<Movie> Movies => Set<Movie>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new MovieConfiguration());
	}
}
