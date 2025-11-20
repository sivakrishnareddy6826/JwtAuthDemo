using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtAuthDemo.Dtos.Tables
{
    [Table("employee_account")]
    public class EmployeeAccount : BaseDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "Employee";

        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }

        public EmployeeDto? Employee { get; set; }
    }
}
