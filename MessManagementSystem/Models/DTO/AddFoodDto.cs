using System.ComponentModel.DataAnnotations;

namespace MessManagementSystem.Models.DTO
{
    public class AddFoodDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
