using MessManagementSystem.Models.Domain;

namespace MessManagementSystem.Repositories.Interfaces
{
    public interface IMenuFoodRepository
    {
        Task<List<MenuFood>> GetAllAsync();
        Task<MenuFood?> GetByIdAsync(Guid id);
        Task<MenuFood?> CreateAsync(MenuFood menuFood);
        Task<MenuFood?> UpdateAsync(Guid id, MenuFood menuFood);
        Task<MenuFood?> DeleteAsync(Guid menuId);
    }
}
