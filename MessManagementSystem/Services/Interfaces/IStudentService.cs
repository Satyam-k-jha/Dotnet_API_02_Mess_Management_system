using MessManagementSystem.Models.DTO;

namespace MessManagementSystem.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAllStudentsAsync();
        Task<StudentDto> DeleteStudentsSafely(Guid id);
    }
}
