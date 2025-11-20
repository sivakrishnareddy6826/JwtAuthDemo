using JwtAuthDemo.Dtos.Tables;

namespace JwtAuthDemo.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployees();
        Task<EmployeeDto> GetEmployeeById(int id);
        Task<EmployeeDto> AddEmployee(EmployeeDto employee);
        Task<EmployeeDto> UpdateEmployee(EmployeeDto employee);
        Task<bool> DeleteEmployee(int id);
    }
}
