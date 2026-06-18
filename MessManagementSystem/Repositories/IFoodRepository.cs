using MessManagementSystem.Models.Domain;

namespace MessManagementSystem.Repositories
{
    public interface IFoodRepository
    {
        Task<List<Food>> GetAllAsync();
        Task<Food?> GetByIdAsync(Guid id);
        Task<Food> CreateAsync(Food food);
        Task<Food?> UpdateAsync(Guid id, Food food);
        Task<Food?> DeleteAsync(Guid id);
    }
}
