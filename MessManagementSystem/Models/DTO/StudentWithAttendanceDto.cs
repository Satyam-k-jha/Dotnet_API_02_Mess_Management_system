using MessManagementSystem.Models.Domain;
using System.Text.Json.Serialization;

namespace MessManagementSystem.Models.DTO
{
    public class StudentWithAttendanceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<AttendanceSummaryDto> Attendances { get; set; }

    }
    public class AttendanceSummaryDto
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
    }
}
