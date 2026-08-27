using MessManagementSystem.Models.DTO;

namespace MessManagementSystem.Services.Interfaces
{
    public interface IMenuFoodService
    {
        Task<List<MenuFoodDto>> GetAllMenuFoodsAsync();
        Task<MenuFoodDto> DeleteMenuFoodAsync(Guid id);
        Task<MenuFoodDto> GetMenuFoodByIdAsync(Guid id);
        Task<MenuFoodDto> UpdateMenuFoodAsync(Guid id, UpdateMenuDto updateMenuDto);
        Task<MenuFoodDto> AddMenuFoodAsync(AddMenuDto addMenuDto);
    }
}
