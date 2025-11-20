using JwtAuthDemo.Dtos.Tables;
using JwtAuthDemo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/admin/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            return Ok(await _departmentService.GetAllDepartments());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var employee = await _departmentService.GetDepartmentById(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(Department department)
        {
            return Ok(await _departmentService.AddDepartment(department));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, Department department)
        {
            if (id != department.Id) return BadRequest();
            return Ok(await _departmentService.UpdateDepartment(department));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            if (!await _departmentService.DeleteDepartment(id)) return NotFound();
            return Ok(new { message = "Deleted Successfully" });
        }
    }
}
