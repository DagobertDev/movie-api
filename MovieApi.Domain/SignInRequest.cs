using System.ComponentModel.DataAnnotations;

namespace MovieApi.Domain;

public record SignInRequest([EmailAddress] string Email, string Password);
