using MessManagementSystem.Models.DTO;

namespace MessManagementSystem.Services.Interfaces
{
    public interface IAttendanceService
    {
        Task<List<AttendanceDto>> GetAllAttendancesAsync();
        Task<AttendanceDto> DeleteAttendancesSafely(Guid id);
        Task<AttendanceDto> GetAttendanceByIdAsync(Guid id);
        Task<AttendanceDto> UpdateAttendanceAsync(Guid id, UpdateAttendanceDto updateAttendanceDto);
        Task<AttendanceDto> AddAttendanceAsync(AddAttendanceDto addAttendanceDto);
    }
}
