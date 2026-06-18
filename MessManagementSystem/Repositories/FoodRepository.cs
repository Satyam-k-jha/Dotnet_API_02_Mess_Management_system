using MessManagementSystem.Data;
using MessManagementSystem.Models.Domain;
using MessManagementSystem.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace MessManagementSystem.Repositories
{

    public class FoodRepository : IFoodRepository
    {
        private readonly AppDbContext _context;

        public FoodRepository(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<Food> CreateAsync(Food food)
        {
            await _context.Foods.AddAsync(food);
            await _context.SaveChangesAsync();
            return food;
        }

        public async Task<Food?> DeleteAsync(Guid id)
        {
            var food = _context.Foods.FirstOrDefault(s => s.Id == id);
            if (food == null)
            {
                return null;

            }
            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();
            return food;
        }

        public async Task<List<Food>> GetAllAsync()
        {
            var foods = await _context.Foods.ToListAsync();
            return foods;
        }

        public async Task<Food?> GetByIdAsync(Guid id)
        {
            var food = await _context.Foods.FirstOrDefaultAsync(s => s.Id == id);
            if (food == null)
            {
                return null;
            }
            return food;
        }

        public async Task<Food?> UpdateAsync(Guid id, Food food)
        {
            var existingFood = await _context.Foods.FirstOrDefaultAsync(s => s.Id == id);
            if (existingFood == null)
            {
                return null;
            }
            existingFood.Name = food.Name;
            existingFood.Description = food.Description;
            await _context.SaveChangesAsync();
            return existingFood;
        }
    }
}
