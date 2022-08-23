using Microsoft.AspNetCore.Mvc;
using MovieApi.Model;
using MovieApi.Services;

namespace MovieApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
	private readonly IUserService _userService;

	public UsersController(IUserService userService)
	{
		_userService = userService ?? throw new ArgumentNullException(nameof(userService));
	}

	[HttpPost]
	public Task<User> Add(string name)
	{
		return _userService.Add(name);
	}

	[HttpGet("{id:guid}")]
	public Task<User?> GetById(Guid id)
	{
		return _userService.GetById(id);
	}

	[HttpGet]
	public Task<User?> GetByName([FromQuery] string name)
	{
		return _userService.GetByName(name);
	}
}
