using JwtAuthDemo.Dtos;
using JwtAuthDemo.Dtos.Tables;
using JwtAuthDemo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await _employeeService.GetAllEmployeesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeRequestDto employee)
        {
            return Ok(await _employeeService.AddEmployeeAsync(employee));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeRequestDto employee)
        {
            if (id < 0) return BadRequest();
            return Ok(await _employeeService.UpdateEmployeeAsync(id, employee));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (!await _employeeService.DeleteEmployeeAsync(id)) return NotFound();
            return Ok(new { message = "Deleted Successfully" });
        }
    }
}
