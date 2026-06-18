using MessManagementSystem.Models.Domain;

namespace MessManagementSystem.Repositories
{
    public interface IAttendanceRepository
    {
        Task<List<Attendance>> GetAllAsync();
        Task<Attendance?> GetByIdAsync(Guid id);
        Task<Attendance> CreateAsync(Attendance attendance);
        Task<Attendance?> UpdateAsync(Guid id, Attendance attendance);
        Task<Attendance?> DeleteAsync(Guid id);
    }
}
