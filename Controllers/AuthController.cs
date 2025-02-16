using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _jwtTokenService;

        public AuthController()
        {
            var key = "your-secret-key-should-be-longer"; // Store securely
            var issuer = "your-issuer";
            var audience = "your-audience";

            _jwtTokenService = new JwtTokenService(key, issuer, audience);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Username == "admin" && request.Password == "password") // Replace with real authentication
            {
                var token = _jwtTokenService.GenerateToken(request.Username, "Admin");
                return Ok(new { token });
            }

            return Unauthorized("Invalid username or password");
        }
    }
}
