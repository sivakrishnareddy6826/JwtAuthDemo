using JwtAuthDemo.Dtos.Tables;
using JwtAuthDemo.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace JwtAuthDemo.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/admin/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly DataContext _context;

        public RoleController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddRole([FromBody] Role request)
        {
            if (await _context.Roles.AnyAsync(r => r.Name == request.Name))
                return BadRequest("Role already exists.");

            request.CreatedDate = DateTime.UtcNow;
            request.CreatedBy = "Admin";
            _context.Roles.Add(request);
            await _context.SaveChangesAsync();

            return Ok("Role added successfully.");
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            return Ok(roles);
        }
    }

}
