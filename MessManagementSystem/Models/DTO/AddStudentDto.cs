using System.ComponentModel.DataAnnotations;

namespace MessManagementSystem.Models.DTO
{
    public class AddStudentDto
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}
