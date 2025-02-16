using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers
{
    [Route("api/protected")]
    [ApiController]
    public class ProtectedController : ControllerBase
    {
        [HttpGet]
        [Authorize] // Requires valid JWT token
        public IActionResult GetSecureData()
        {
            return Ok(new { message = "This is a protected API endpoint!" });
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")] // Only users with "Admin" role can access
        public IActionResult GetAdminData()
        {
            return Ok(new { message = "This is an admin-only endpoint!" });
        }
    }
}
