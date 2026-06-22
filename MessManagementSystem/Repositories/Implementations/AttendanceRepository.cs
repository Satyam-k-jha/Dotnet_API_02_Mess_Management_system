using MessManagementSystem.Data;
using MessManagementSystem.Models.Domain;
using MessManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MessManagementSystem.Repositories.Implementations
{
    public class AttendanceRepository:IAttendanceRepository
    {
        private readonly AppDbContext _context;

        public AttendanceRepository(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<Attendance> CreateAsync(Attendance attendance)
        {
            await _context.Attendances.AddAsync(attendance);
            await _context.SaveChangesAsync();
            return attendance;
        }

        public async Task<Attendance?> DeleteAsync(Guid id)
        {
            var attendance = _context.Attendances.FirstOrDefault(s => s.Id == id);
            if (attendance == null)
            {
                return null;

            }
            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();
            return attendance;
        }

        public async Task<List<Attendance>> GetAllAsync()
        {
            var attendances = await _context.Attendances.ToListAsync();
            return attendances;
        }

        public async Task<Attendance?> GetByIdAsync(Guid id)
        {
            var attendance = await _context.Attendances.Include(s => s.Student).FirstOrDefaultAsync(s => s.Id == id);
            if (attendance == null)
            {
                return null;
            }
            return attendance;
        }

        public async Task<Attendance?> UpdateAsync(Guid id, Attendance attendance)
        {
            var existingAttendance = await _context.Attendances.FirstOrDefaultAsync(s => s.Id == id);
            if (existingAttendance == null)
            {
                return null;
            }
            existingAttendance.StudentId = attendance.StudentId;
            existingAttendance.Date = attendance.Date;
            await _context.SaveChangesAsync();
            return existingAttendance;
        }
    }
}
