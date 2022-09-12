using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Model;
using MovieApi.Services;

namespace MovieApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
	private readonly IUserService _userService;

	public AuthController(IUserService userService)
	{
		_userService = userService ?? throw new ArgumentNullException(nameof(userService));
	}

	[AllowAnonymous]
	[HttpPost("signIn")]
	public async Task<ActionResult<bool>> SignIn(SignInRequest request)
	{
		var user = await _userService.GetByName(request.Email);
		if (user is null)
		{
			return Unauthorized();
		}

		var claims = new Claim[]
		{
			new(ClaimTypes.Name, request.Email),
			new(ClaimTypes.NameIdentifier, request.Email),
		};

		var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

		await HttpContext.SignInAsync(
			CookieAuthenticationDefaults.AuthenticationScheme,
			new ClaimsPrincipal(claimsIdentity));

		return true;
	}

	[AllowAnonymous]
	[HttpPost("register")]
	public async Task<User> Register(SignInRequest request)
	{
		var user = await _userService.Add(request.Email);
		await SignIn(request);
		return user;
	}

	[HttpPost("signOut")]
	public void SignOutAction()
	{
		HttpContext.SignOutAsync();
	}
}
