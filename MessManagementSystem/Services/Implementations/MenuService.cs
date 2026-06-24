using AutoMapper;
using MessManagementSystem.Models.Domain;
using MessManagementSystem.Models.DTO;
using MessManagementSystem.Repositories.Implementations;
using MessManagementSystem.Repositories.Interfaces;
using MessManagementSystem.Services.Interfaces;

namespace MessManagementSystem.Services.Implementations
{
    public class MenuService : IMenuService
    {
        private readonly IMapper mapper;
        private readonly IMenuRepository menuRepository;

        public MenuService(IMapper mapper, IMenuRepository menuRepository)
        {
            this.mapper = mapper;
            this.menuRepository = menuRepository;
        }

        public async Task<MenuDto> AddMenuAsync(AddMenuDto addMenuDto)
        {
            var menu = mapper.Map<Menu>(addMenuDto);
            menu = await menuRepository.CreateAsync(menu);
            return mapper.Map<MenuDto>(menu);
        }

        public async Task<MenuDto> DeleteMenuAsync(Guid id)
        {
            var menu = await menuRepository.DeleteAsync(id);
            if (menu == null)
            {
                return null;
            }
            return mapper.Map<MenuDto>(menu);
        }

        public async Task<List<MenuDto>> GetAllMenusAsync()
        {
            var menus = await menuRepository.GetAllAsync();
            return mapper.Map<List<MenuDto>>(menus);
        }

        public async Task<MenuWithFoodDto> GetMenuByIdAsync(Guid id)
        {
            var menu = await menuRepository.GetByIdAsync(id);
            if (menu == null)
            {
                return null;
            }
            return mapper.Map<MenuWithFoodDto>(menu);
        }

        public async Task<MenuDto> UpdateMenuAsync(Guid id, UpdateMenuDto updateMenuDto)
        {
            var menu = mapper.Map<Menu>(updateMenuDto);
            menu = await menuRepository.UpdateAsync(id, menu);
            if (menu == null)
            {
                return null;
            }
            return mapper.Map<MenuDto>(menu);
        }
    }
}
