using JwtAuthDemo.Dtos;
using JwtAuthDemo.Dtos.Tables;
using JwtAuthDemo.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace JwtAuthDemo.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly JwtTokenService _jwtTokenService;
        public AuthController(DataContext context, JwtTokenService jwtService)
        {
            _context = context;
            _jwtTokenService = jwtService;
        }

        //[HttpPost("admin/login")]
        //public async Task<IActionResult> AdminLogin([FromBody] LoginRequest request)
        //{
        //    var admin = await _context.AdminAccounts.FirstOrDefaultAsync(a => a.Username == request.Email);
        //    if (admin == null || !BCrypt.Net.BCrypt.Verify(request.Password, admin.PasswordHash))
        //        return Unauthorized("Invalid admin credentials.");

        //    var token = _jwtTokenService.GenerateToken(admin.Username, admin.Role);
        //    return Ok(new { token, role = admin.Role });
        //}

        [HttpPost("employee/signup")]
        public async Task<IActionResult> EmployeeSignup([FromBody] SignupRequest request)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Email == request.Email);
            if (employee == null)
                return BadRequest("Employee email not found. Please contact Admin.");
            var role = await _context.Roles.FindAsync(employee.RoleId);
            if (role == null)
                return BadRequest("Employee email found but no role assigned. Please contact Admin.");
            if (await _context.EmployeeAccounts.AnyAsync(a => a.Email == request.Email))
                return BadRequest("Account already exists.");

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var account = new EmployeeAccount
            {
                Email = request.Email,
                PasswordHash = hashedPassword,
                Role = role.Name,
                EmployeeId = employee.Id,
                CreatedDate = DateTime.UtcNow
            };

            _context.EmployeeAccounts.Add(account);
            await _context.SaveChangesAsync();

            return Ok("Signup successful. You can now login.");
        }

        [HttpPost("employee/login")]
        public async Task<IActionResult> EmployeeLogin([FromBody] LoginRequest request)
        {
            var account = await _context.EmployeeAccounts
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(a => a.Email == request.Email);

            if (account == null || !BCrypt.Net.BCrypt.Verify(request.Password, account.PasswordHash))
                return Unauthorized("Invalid email or password.");

            var token = _jwtTokenService.GenerateToken(account.Email, account.Role);
            return Ok(new { token, role = account.Role });
        }
    }
}
