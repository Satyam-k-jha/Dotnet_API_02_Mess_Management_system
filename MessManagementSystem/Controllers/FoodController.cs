using AutoMapper;
using MessManagementSystem.CustomActionFilters;
using MessManagementSystem.Data;
using MessManagementSystem.Models.Domain;
using MessManagementSystem.Models.DTO;
using MessManagementSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFoodRepository _foodRepostiory;

        public FoodController(AppDbContext context, IMapper mapper,IFoodRepository foodRepostiory)
        {
            _context = context;
            _mapper = mapper;
            _foodRepostiory = foodRepostiory;
        }
        //GET: api/Food
        [HttpGet]
        public async Task<IActionResult> GefAllFoods()
        {
            var foods = await _foodRepostiory.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<FoodDto>>(foods));
        }
        //GET: api/food/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetFoodById([FromRoute] Guid id)
        {
            var food = await _foodRepostiory.GetByIdAsync(id);
            if (food == null)
            {
                return null;
            }
            return Ok(_mapper.Map<FoodWithMenuDto>(food));
        }

        //POST: api/food
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddFood([FromBody] AddFoodDto addFoodDto)
        {
            var food = _mapper.Map<Food>(addFoodDto);
            food = await _foodRepostiory.CreateAsync(food);
            return CreatedAtAction(nameof(GetFoodById), new { id = food.Id }, food);
        }

        //PUT: api/food/{id}
        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateFood([FromRoute] Guid id, [FromBody] UpdateFoodDto updateFoodDto)
        {
            var food = _mapper.Map<Food>(updateFoodDto);
            food = await _foodRepostiory.UpdateAsync(id, food);
            if (food == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<FoodDto>(food));
        }

        //Delete: api/food/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteFood([FromRoute] Guid id)
        {
            var food = await _foodRepostiory.DeleteAsync(id);
            if (food == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<FoodDto>(food));
        }
    }
}
