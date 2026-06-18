using MessManagementSystem.Data;
using MessManagementSystem.Models.Domain;
using MessManagementSystem.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace MessManagementSystem.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<Student> CreateAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student?> DeleteAsync(Guid id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (student == null)
            {
                return null;
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            var students = await _context.Students
            .Select(s => new Student
            {
                Id = s.Id,
                Name = s.Name
            }).ToListAsync();
            return students;
        }

        public async Task<Student?> GetByIdAsync(Guid id)
        {
            var student = await _context.Students.Include(s => s.Attendances).FirstOrDefaultAsync(s => s.Id == id);
            if (student == null)
            {
                return null;
            }
            return student;
        }

        public async Task<Student?> UpdateAsync(Guid id, Student student)
        {
            var existingStudent = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (existingStudent == null)
            {
                return null;
            }
            existingStudent.Name = student.Name;
            await _context.SaveChangesAsync();
            return student;
        }
    }
}
