using MessManagementSystem.Models.Domain;

namespace MessManagementSystem.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(Guid id);
        Task<Student> CreateAsync(Student student);
        Task<Student?> UpdateAsync(Guid id, Student student);
        Task<Student?> DeleteAsync(Guid id);
    }
}
