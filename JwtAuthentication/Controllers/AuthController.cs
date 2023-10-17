using JwtAuthentication.Controllers.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel user)
    {
        if (user is null)
        {
            return BadRequest("Invalid client request");
        }
        if (user.Username == "admin" && user.Password == "admin")
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.Role, "Manager")
    };

            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:7051",
                audience: "https://localhost:7051",
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new AuthenticatedResponse { Token = tokenString });
        }
        return Unauthorized();
    }
}