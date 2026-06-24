using AutoMapper;
using MessManagementSystem.Models.Domain;
using MessManagementSystem.Models.DTO;
using MessManagementSystem.Repositories.Implementations;
using MessManagementSystem.Repositories.Interfaces;
using MessManagementSystem.Services.Interfaces;

namespace MessManagementSystem.Services.Implementations
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository foodRepository;
        private readonly IMapper mapper;

        public FoodService(IFoodRepository foodRepository, IMapper mapper)
        {
            this.foodRepository = foodRepository;
            this.mapper = mapper;
        }

        public async Task<FoodDto> AddFoodAsync(AddFoodDto addFoodDto)
        {
            var food = mapper.Map<Food>(addFoodDto);
            food = await foodRepository.CreateAsync(food);

            return mapper.Map<FoodDto>(food);
        }

        public async Task<FoodDto> DeleteFoodAsync(Guid id)
        {
            var food = await foodRepository.DeleteAsync(id);
            if (food == null)
            {
                return null;
            }
            return mapper.Map<FoodDto>(food);
        }

        public async Task<List<FoodDto>> GetAllFoodsAsync()
        {
            var foods = await foodRepository.GetAllAsync();
            return mapper.Map<List<FoodDto>>(foods);
        }

        public async Task<FoodWithMenuDto> GetFoodByIdAsync(Guid id)
        {
            var food = await foodRepository.GetByIdAsync(id);
            if (food == null)
            {
                return null;
            }
            return mapper.Map<FoodWithMenuDto>(food);
        }

        public async Task<FoodDto> UpdateFoodAsync(Guid id, UpdateFoodDto updateFoodDto)
        {
            var food = mapper.Map<Food>(updateFoodDto);
            food = await foodRepository.UpdateAsync(id, food);
            if (food == null)
            {
                return null;
            }
            return mapper.Map<FoodDto>(food);
        }
    }
}
