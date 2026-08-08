namespace MessManagementSystem.Models.Domain
{
    public class Menu
    {
        public Guid MenuId { get; set; }
        public DateOnly Date { get; set; }
        public string Type { get; set; }

        //// Navigation property to represent the many-to-many relationship with Food
        //public ICollection<Food> Foods { get; set; }

    }
}
