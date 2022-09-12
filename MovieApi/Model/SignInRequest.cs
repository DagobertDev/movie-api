using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model;

public record SignInRequest([EmailAddress] string Email, string Password);
