using JwtAuthDemo.Dtos.Tables;
using System.ComponentModel.DataAnnotations;

namespace JwtAuthDemo.Dtos
{
    public class EmployeeRequestDto
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string? Position { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }
    }

}
