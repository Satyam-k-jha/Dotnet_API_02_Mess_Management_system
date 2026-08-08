namespace MessManagementSystem.Models.Domain
{
    public class Student
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string Name { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
        public User? User { get; set; }

    }
}
