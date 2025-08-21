namespace Eventing.Web.Components.Features.Register.Dtos
{
    public class RegisterRequestDto
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
    }

    public class LoginRequestDto
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    public class LoginResponseDto
    {
        public string AccessToken { get; set; } = null!;
        public int ExpiresIn { get; set; }
    }
}