using Microsoft.EntityFrameworkCore;
using MovieApi.Model;
using MovieApi.ModelConfigurations;

namespace MovieApi;

public class MovieContext : DbContext
{
	public MovieContext(DbContextOptions<MovieContext> context) : base(context) { }

	public DbSet<Movie> Movies => Set<Movie>();
	public DbSet<User> Users => Set<User>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new MovieConfiguration());
		modelBuilder.ApplyConfiguration(new UserConfiguration());
	}
}
