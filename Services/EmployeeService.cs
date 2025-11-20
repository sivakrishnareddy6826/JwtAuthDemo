using JwtAuthDemo.Dtos;
using JwtAuthDemo.Dtos.Tables;
using JwtAuthDemo.Repository.Interfaces;
using JwtAuthDemo.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthDemo.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllEmployees();
        }

        public async Task<EmployeeDto?> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeById(id);
        }

        public async Task<EmployeeDto> AddEmployeeAsync(EmployeeRequestDto employee)
        {
            //  Example business rule: Ensure unique email before adding
            /*var existing = await _employeeRepository.GetEmployeeByEmail(employee.Email);
            if (existing != null)
                throw new InvalidOperationException("Employee with same email already exists");*/
           
            EmployeeDto employeeDto = new EmployeeDto()
            {
               Name = employee.Name,
               Email = employee.Email,
               Position = employee.Position,
               DepartmentId = employee.DepartmentId,
               RoleId = employee.RoleId,
               Salary = employee.Salary,
            };
            employeeDto.CreatedDate = DateTime.Now;
            employeeDto.CreatedBy = "SYSTEM";

            return await _employeeRepository.AddEmployee(employeeDto);
        }

        public async Task<EmployeeDto> UpdateEmployeeAsync(int id, EmployeeDto employee)
        {
            if (id != employee.Id)
                throw new ArgumentException("Mismatched employee id");

            var existing = await _employeeRepository.GetEmployeeById(id);
            if (existing == null)
                throw new KeyNotFoundException("Employee not found");

            //Example business logic: preserve created date, etc.
            employee.CreatedDate = existing.CreatedDate;
            employee.ModifiedDate = employee.ModifiedDate ?? DateTime.Now;
            employee.ModifiedBy = employee.ModifiedBy ?? "SYSTEM";

            return await _employeeRepository.UpdateEmployee(employee);
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);
            if (employee == null)
                return false;

            return await _employeeRepository.DeleteEmployee(id);
        }
    }
}
