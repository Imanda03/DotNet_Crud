namespace JwtAuthentication.Controllers.Model
{
    public class LoginModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

    public class AuthenticatedResponse
    {
        public string? Token { get; set;}
    }
}
