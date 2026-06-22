using MessManagementSystem.Models.Domain;

namespace MessManagementSystem.Repositories.Interfaces
{
    public interface IMenuRepository
    {
        Task<List<Menu>> GetAllAsync();
        Task<Menu?> GetByIdAsync(Guid id);
        Task<Menu> CreateAsync(Menu menu);
        Task<Menu?> UpdateAsync(Guid id, Menu menu);
        Task<Menu?> DeleteAsync(Guid id);
    }
}
