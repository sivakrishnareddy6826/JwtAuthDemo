using JwtAuthDemo.Dtos;
using JwtAuthDemo.Dtos.Tables;

namespace JwtAuthDemo.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto?> GetEmployeeByIdAsync(int id);
        Task<EmployeeDto> AddEmployeeAsync(EmployeeRequestDto employee);
        Task<EmployeeDto> UpdateEmployeeAsync(int id, EmployeeDto employee);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
