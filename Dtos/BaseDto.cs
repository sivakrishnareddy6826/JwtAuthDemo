using System.ComponentModel.DataAnnotations;

namespace JwtAuthDemo.Dtos
{
    public class BaseDto
    {
        [Required]
        public string CreatedBy { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedDate { get; set; }

        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
