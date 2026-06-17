namespace MessManagementSystem.Models.DTO
{
    public class AddAttendanceDto
    {
        public DateOnly Date { get; set; }
        public Guid StudentId { get; set; }
    }
}
