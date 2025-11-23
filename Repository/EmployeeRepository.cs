using JwtAuthDemo.Dtos.Tables;
using JwtAuthDemo.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthDemo.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            return await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Role)
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Email = e.Email,
                    Salary = e.Salary,
                    DepartmentId = e.DepartmentId,
                    RoleId = e.RoleId,
                    Position = e.Position,

                    // Navigation properties
                    Department = new Department
                    {
                        Id = e.Department.Id,
                        Name = e.Department.Name
                    },
                    Role = new Role
                    {
                        Id = e.Role.Id,
                        Name = e.Role.Name
                    }
                })
                .ToListAsync();
        }
         
        public async Task<EmployeeDto?> GetEmployeeById(int id)
        {
            return await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Role)
                .Where(e => e.Id == id)
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Email = e.Email,
                    Salary = e.Salary,
                    DepartmentId = e.DepartmentId,
                    RoleId = e.RoleId,
                    Position = e.Position,

                    // Navigation properties
                    Department = new Department
                    {
                        Id = e.Department.Id,
                        Name = e.Department.Name
                    },
                    Role = new Role
                    {
                        Id = e.Role.Id,
                        Name = e.Role.Name
                    }
                }).FirstOrDefaultAsync();
        }

        public async Task<EmployeeDto> AddEmployee(EmployeeDto employee)
        {
            var department = await _context.Departments.FindAsync(employee.DepartmentId);
            var role = await _context.Roles.FindAsync(employee.RoleId);

            if (department == null || role == null)
                throw new Exception("Deparment or Role not exist give valid");
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<EmployeeDto> UpdateEmployee(EmployeeDto employee)
        {
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
