namespace MessManagementSystem.Models.Domain
{
    public class Attendance
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        //public Menu Menu { get; set; }

        //Foreign Key
        public Guid StudentId { get; set; }
        //Navigation property
        public Student Student { get; set; }
    }
}
