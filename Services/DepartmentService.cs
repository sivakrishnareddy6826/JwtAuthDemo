using JwtAuthDemo.Dtos.Tables;
using JwtAuthDemo.Repository.Interfaces;
using JwtAuthDemo.Services.Interfaces;

namespace JwtAuthDemo.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Department> AddDepartment(Department department)
        {
            return await _departmentRepository.AddDepartment(department);
        }

        public async Task<bool> DeleteDepartment(int departmentId)
        {
            return await _departmentRepository.DeleteDepartment(departmentId);
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _departmentRepository.GetAllDepartments();
        }

        public async Task<Department> GetDepartmentById(int departmentId)
        {
            return await _departmentRepository.GetDepartmentById(departmentId);
        }

        public async Task<Department> UpdateDepartment(Department department)
        {
            return await _departmentRepository.UpdateDepartment(department);
        }
    }
}
