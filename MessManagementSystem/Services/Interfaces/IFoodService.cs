using MessManagementSystem.Models.DTO;

namespace MessManagementSystem.Services.Interfaces
{
    public interface IFoodService
    {
        Task<List<FoodDto>> GetAllFoodsAsync();
        Task<FoodDto> DeleteFoodAsync(Guid id);
        Task<FoodWithMenuDto> GetFoodByIdAsync(Guid id);
        Task<FoodDto> UpdateFoodAsync(Guid id, UpdateFoodDto updateFoodDto);
        Task<FoodDto> AddFoodAsync(AddFoodDto addFoodDto);
    }
}
