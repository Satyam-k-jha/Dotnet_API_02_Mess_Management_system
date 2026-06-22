using MessManagementSystem.Models.DTO;
using MessManagementSystem.Repositories.Implementations;
using MessManagementSystem.Repositories.Interfaces;
using MessManagementSystem.Services.Interfaces;

namespace MessManagementSystem.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public async Task<StudentDto> DeleteStudentsSafely(Guid id)
        {
            var student = await studentRepository.GetByIdAsync(id);
            if (student == null) return null;

            // 2. APPLY BUSINESS LOGIC: Don't delete if they have attendances
            if (student.Attendances != null && student.Attendances.Any())
            {
                throw new Exception("Cannot delete a student with active mess attendances.");
            }

            // 3. If rules pass, tell repository to delete
            var deletedStudent = await studentRepository.DeleteAsync(id);

            // 4. Map back to DTO
            return new StudentDto { Id = deletedStudent.Id, Name = deletedStudent.Name };
        }

        public async Task<List<StudentDto>> GetAllStudentsAsync()
        {
            var students = await studentRepository.GetAllAsync();
            var studentDTOs = students.Select(s => new StudentDto
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();

            return studentDTOs;
        }
    }
}
