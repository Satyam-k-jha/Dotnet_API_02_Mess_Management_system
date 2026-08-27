namespace MessManagementSystem.Models.Domain
{
    public class MenuFood
    {
        public Guid MenuId { get; set; }
        public Guid FoodId { get; set; }

        //Navigation
        public List<Food> Food { get; set; }
    }
}
