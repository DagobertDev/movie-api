using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApi.Domain;

namespace MovieApi.ModelConfigurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
	public void Configure(EntityTypeBuilder<Movie> builder)
	{
		builder.HasKey(movie => movie.Id);
		builder.Property(movie => movie.Id).ValueGeneratedNever();
		builder.Property(movie => movie.Name).IsRequired();
	}
}
