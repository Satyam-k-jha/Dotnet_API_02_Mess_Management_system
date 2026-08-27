using AutoMapper;
using MessManagementSystem.Models.DTO;
using MessManagementSystem.Services.Interfaces;

namespace MessManagementSystem.Services.Implementations
{
    public class MenuFoodService : IMenuFoodService
    {
        public void MenuService(IMapper mapper)
        {

        }
        public Task<MenuFoodDto> AddMenuFoodAsync(AddMenuDto addMenuDto)
        {
            throw new NotImplementedException();
        }

        public Task<MenuFoodDto> DeleteMenuFoodAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MenuFoodDto>> GetAllMenuFoodsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MenuFoodDto> GetMenuFoodByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<MenuFoodDto> UpdateMenuFoodAsync(Guid id, UpdateMenuDto updateMenuDto)
        {
            throw new NotImplementedException();
        }
    }
}
