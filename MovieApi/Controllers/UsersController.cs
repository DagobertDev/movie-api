using Microsoft.AspNetCore.Mvc;
using MovieApi.Domain;
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
