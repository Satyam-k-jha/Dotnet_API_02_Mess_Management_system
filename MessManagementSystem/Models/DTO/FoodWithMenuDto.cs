using MessManagementSystem.Models.Domain;

namespace MessManagementSystem.Models.DTO
{
    public class FoodWithMenuDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<MenuSummaryDto> Menus { get; set; }
    }

    public class MenuSummaryDto
    {
        public DateOnly Date { get; set; }
    }
}
