using MovieApi.Model;

namespace MovieApi.Services;

public interface IUserService
{
	Task<User> Add(string name);
	Task<User?> GetById(Guid id);
	Task<User?> GetByName(string name);
}
