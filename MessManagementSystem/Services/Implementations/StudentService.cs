using AutoMapper;
using MessManagementSystem.Models.Domain;
using MessManagementSystem.Models.DTO;
using MessManagementSystem.Repositories.Implementations;
using MessManagementSystem.Repositories.Interfaces;
using MessManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MessManagementSystem.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        public async Task<StudentDto> AddStudentAsync(AddStudentDto addStudentDto)
        {
            //Dto -> Model
            var student = mapper.Map<Student>(addStudentDto);
            student = await studentRepository.CreateAsync(student);

            //Model -> Dto
            var dto = mapper.Map<StudentDto>(student);
            return dto;
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
            return mapper.Map<StudentDto>(student);
        }

        public async Task<List<StudentDto>> GetAllStudentsAsync()
        {
            var students = await studentRepository.GetAllAsync();
            

            return mapper.Map<List<StudentDto>>(students);
        }

        public async Task<StudentWithAttendanceDto> GetStudentByIdAsync(Guid id)
        {
            var student = await studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return null;
            }
            //Model to Dto
            return mapper.Map<StudentWithAttendanceDto>(student);
        }

        public async Task<StudentDto> UpdateStudentAsync(Guid id, UpdateStudentDto updateStudentDto)
        {
            var student = mapper.Map<Student>(updateStudentDto);
            student = await studentRepository.UpdateAsync(id, student);
            if (student == null)
            {
                return null;
            }
            //Model to Dto
            return mapper.Map<StudentDto>(student);

        }
    }
}
