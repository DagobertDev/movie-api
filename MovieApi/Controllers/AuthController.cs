using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Model;

namespace MovieApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
	[AllowAnonymous]
	[HttpPost("signIn")]
	public async Task<bool> SignIn(SignInRequest request)
	{
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

	[HttpPost("signOut")]
	public void SignOutAction()
	{
		HttpContext.SignOutAsync();
	}
}
