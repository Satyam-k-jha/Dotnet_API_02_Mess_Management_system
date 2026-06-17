using MessManagementSystem.Models.Domain;

namespace MessManagementSystem.Models.DTO
{
    public class AttendanceDto
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        //public Menu Menu { get; set; }

        //Foreign Key
        public Guid StudentId { get; set; }
        //Navigation property
        public StudentSummaryDto Student { get; set; }
    }

    public class StudentSummaryDto
    {
        public string Name { get; set; }
    }
}
