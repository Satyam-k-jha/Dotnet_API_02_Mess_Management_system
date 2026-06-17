namespace MessManagementSystem.Models.Domain
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Attendance> Attendances { get; set; }

    }
}
