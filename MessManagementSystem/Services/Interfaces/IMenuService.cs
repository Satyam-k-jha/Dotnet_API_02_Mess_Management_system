using MessManagementSystem.Models.DTO;

namespace MessManagementSystem.Services.Interfaces
{
    public interface IMenuService
    {
        Task<List<MenuDto>>GetAllMenusAsync();
        Task<MenuDto> DeleteMenuAsync(Guid id);
        Task<MenuWithFoodDto> GetMenuByIdAsync(Guid id);
        Task<MenuDto> UpdateMenuAsync(Guid id, UpdateMenuDto updateMenuDto);
        Task<MenuDto> AddMenuAsync(AddMenuDto addMenuDto);
    }
}
