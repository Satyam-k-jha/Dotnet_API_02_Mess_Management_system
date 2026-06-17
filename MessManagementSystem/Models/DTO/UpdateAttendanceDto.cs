namespace MessManagementSystem.Models.DTO
{
    public class UpdateAttendanceDto
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public Guid StudentId { get; set; }
    }
}
