using JwtAuthDemo.Dtos.Tables;
using JwtAuthDemo.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthDemo.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _context;

        public DepartmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Department> AddDepartment(Department department)
        {
           _context.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if(department == null)
            {
                return false;
            }
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Department> UpdateDepartment(Department department)
        {
            _context.Entry(department).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return department;
        }
    }
}
