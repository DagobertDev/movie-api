using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApi.Model;

namespace MovieApi.ModelConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.HasKey(user => user.Id);
		builder.Property(user => user.Name).IsRequired().HasMaxLength(32);
		builder.HasIndex(user => user.Name).IsUnique();
	}
}
