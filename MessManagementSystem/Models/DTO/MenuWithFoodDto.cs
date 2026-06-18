using MessManagementSystem.Models.Domain;

namespace MessManagementSystem.Models.DTO
{
    public class MenuWithFoodDto
    {
        public Guid MenuId { get; set; }
        public DateOnly Date { get; set; }
        public ICollection<FoodSummaryDto> Foods { get; set; }
    }

    public class FoodSummaryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
