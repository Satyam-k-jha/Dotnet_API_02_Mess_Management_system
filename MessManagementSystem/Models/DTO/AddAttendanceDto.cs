using System.ComponentModel.DataAnnotations;

namespace MessManagementSystem.Models.DTO
{
    public class AddAttendanceDto
    {
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public Guid StudentId { get; set; }
    }
}
