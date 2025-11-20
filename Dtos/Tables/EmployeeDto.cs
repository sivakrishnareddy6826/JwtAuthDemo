using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtAuthDemo.Dtos.Tables
{
    [Table("employee")]
    public class EmployeeDto : BaseDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Email { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        // Foreign Keys
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        // Navigation properties
        public Department? Department { get; set; }
        public Role? Role { get; set; }
        public string? Position { get; internal set; }
    }

}
