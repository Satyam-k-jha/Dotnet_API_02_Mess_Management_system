using MessManagementSystem.Models.Domain;

namespace MessManagementSystem.Repositories.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<List<Attendance>> GetAllAsync();
        Task<Attendance?> GetByIdAsync(Guid id);
        Task<Attendance> CreateAsync(Attendance attendance);
        Task<Attendance?> UpdateAsync(Guid id, Attendance attendance);
        Task<Attendance?> DeleteAsync(Guid id);
        Task<List<Attendance>> GetByStudentIdAsync(Guid studentId);
        Task<List<Attendance>> GetByUserIdAsync(Guid userId);
    }
}
