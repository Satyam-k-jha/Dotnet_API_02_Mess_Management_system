using MessManagementSystem.Models.DTO;

namespace MessManagementSystem.Services.Interfaces
{
    public interface IAttendanceService
    {
        Task<List<AttendanceDto>> GetAllAttendancesAsync();
        Task<AttendanceDto?> DeleteAttendanceAsync(Guid id);
        Task<AttendanceDto> GetAttendanceByIdAsync(Guid id);
        Task<AttendanceDto> UpdateAttendanceAsync(Guid id, UpdateAttendanceDto updateAttendanceDto);
        Task<AttendanceDto> AddAttendanceAsync(AddAttendanceDto addAttendanceDto);
        Task<List<AttendanceResponseByUserDto>> GetAttendanceByStudentIdAsync(Guid studentId);
        Task<List<AttendanceResponseByUserDto>> GetAttendanceByUserIdAsync(Guid userId);
    }
}
