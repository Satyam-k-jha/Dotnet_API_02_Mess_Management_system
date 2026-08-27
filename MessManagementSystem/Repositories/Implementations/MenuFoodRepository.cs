using MessManagementSystem.Data;
using MessManagementSystem.Models.Domain;
using MessManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MessManagementSystem.Repositories.Implementations
{
    public class MenuFoodRepository : IMenuFoodRepository
    {
        private readonly AppDbContext context;

        public MenuFoodRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<MenuFood?> CreateAsync(MenuFood menuFood)
        {

            var isMenuAndFoodPresent = await context.MenuFoods
                          .FirstOrDefaultAsync(r => r.FoodId == menuFood.FoodId
                          && r.MenuId == menuFood.MenuId);
            if(isMenuAndFoodPresent != null)
            {
                return null;
            }
            await context.AddAsync(menuFood);
            await context.SaveChangesAsync();
            return menuFood;
        }

        public async Task<List<MenuFood>?> DeleteAsync(Guid menuId)
        {
            var menuFoods = await context.MenuFoods
            .Where(o => o.MenuId == menuId)
            .ToListAsync();

            context.MenuFoods.RemoveRange(menuFoods);

            await context.SaveChangesAsync();
            return menuFoods;
        }

        public async Task<List<MenuFood>> GetAllAsync()
        {
            var menuFoods = await context.MenuFoods.ToListAsync();
            return menuFoods;
        }

        public async Task<List<MenuFood>?> GetByIdAsync(Guid id)
        {
            var menuFoods = await context.MenuFoods
            .Where(o => o.MenuId == id)
            .ToListAsync();

            return menuFoods;
        }

        public Task<MenuFood?> UpdateAsync(Guid id, MenuFood menuFood)
        {
            throw new NotImplementedException();
        }
    }
}
