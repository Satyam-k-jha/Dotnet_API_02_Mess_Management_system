namespace MessManagementSystem.Models.DTO
{
    public class MenuFoodDto
    {
        public Guid MenuId { get; set; }
        public Guid FoodId { get; set; }

        public List<FoodSummary> FoodSummary { get; set; }
    }

    public class FoodSummary
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
