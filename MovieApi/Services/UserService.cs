using Microsoft.EntityFrameworkCore;
using MovieApi.Domain;

namespace MovieApi.Services;

public class UserService : IUserService
{
	private readonly MovieContext _movieContext;

	public UserService(MovieContext movieContext)
	{
		_movieContext = movieContext ?? throw new ArgumentNullException(nameof(movieContext));
	}

	public async Task<User> Add(string name)
	{
		var user = new User(Guid.Empty, name);
		_movieContext.Users.Add(user);
		await _movieContext.SaveChangesAsync();
		return user;
	}

	public async Task<User?> GetById(Guid id)
	{
		return await _movieContext.Users.SingleOrDefaultAsync(user => user.Id == id);
	}

	public async Task<User?> GetByName(string name)
	{
		return await _movieContext.Users.SingleOrDefaultAsync(user => user.Name == name);
	}
}
