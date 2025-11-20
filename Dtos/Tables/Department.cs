using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JwtAuthDemo.Dtos.Tables
{
    [Table("department")]
    public class Department : BaseDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        // Navigation Property
        [JsonIgnore]
        public ICollection<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
    }

}
