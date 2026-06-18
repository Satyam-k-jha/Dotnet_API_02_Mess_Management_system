using MessManagementSystem.Data;
using MessManagementSystem.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MessManagementSystem.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDbContext _context;

        public MenuRepository(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<Menu> CreateAsync(Menu menu)
        {
            await _context.Menus.AddAsync(menu);
            await _context.SaveChangesAsync();
            return menu;
        }

        public async Task<Menu?> DeleteAsync(Guid id)
        {
            var menu = _context.Menus.FirstOrDefault(s => s.MenuId == id);
            if (menu == null)
            {
                return null;

            }
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
            return menu;
        }

        public async Task<List<Menu>> GetAllAsync()
        {
            var menus = await _context.Menus.ToListAsync();
            return menus;
        }

        public async Task<Menu?> GetByIdAsync(Guid id)
        {
            var menu = await _context.Menus.FirstOrDefaultAsync(s => s.MenuId == id);
            if (menu == null)
            {
                return null;
            }
            return menu;
        }

        public async Task<Menu?> UpdateAsync(Guid id, Menu menu)
        {
            var existingMenu = await _context.Menus.FirstOrDefaultAsync(s => s.MenuId == id);
            if (existingMenu == null)
            {
                return null;
            }
            existingMenu.Date = menu.Date;
            await _context.SaveChangesAsync();
            return existingMenu;
        }
    }
}
