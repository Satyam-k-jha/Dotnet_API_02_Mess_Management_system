using MessManagementSystem.Models.Domain;

namespace MessManagementSystem.Models.DTO
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        //public ICollection<Attendance> Attendances { get; set; }
    }

   
}
