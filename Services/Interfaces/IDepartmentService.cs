using JwtAuthDemo.Dtos.Tables;

namespace JwtAuthDemo.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<Department> AddDepartment(Department department);
        Task<Department> UpdateDepartment(Department department);
        Task<bool> DeleteDepartment(int departmentId);
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int departmentId);
    }
}
