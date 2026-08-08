namespace MessManagementSystem.Models.Domain
{
    public class Food
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //public ICollection<Menu> Menus { get; set; }
    }
}
