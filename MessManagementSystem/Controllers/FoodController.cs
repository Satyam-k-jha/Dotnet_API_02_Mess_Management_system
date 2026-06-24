using AutoMapper;
using MessManagementSystem.CustomActionFilters;
using MessManagementSystem.Data;
using MessManagementSystem.Models.Domain;
using MessManagementSystem.Models.DTO;
using MessManagementSystem.Repositories.Interfaces;
using MessManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            this._foodService = foodService;
        }
        //GET: api/Food
        [HttpGet]
        public async Task<IActionResult> GetAllFoods()
        {
            var foods = await _foodService.GetAllFoodsAsync();
            return Ok(foods);
           
        }
        //GET: api/food/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetFoodById([FromRoute] Guid id)
        {
            var food = _foodService.GetFoodByIdAsync(id);
            if(food == null)
            {
                return NotFound("Food Not Found");
            }
            return Ok(food);
        }

        //POST: api/food
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddFood([FromBody] AddFoodDto addFoodDto)
        {
            var food = await _foodService.AddFoodAsync(addFoodDto);
            return CreatedAtAction(nameof(GetFoodById), new { id = food.Id }, food);
        }

        //PUT: api/food/{id}
        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateFood([FromRoute] Guid id, [FromBody] UpdateFoodDto updateFoodDto)
        {
            var food = await _foodService.UpdateFoodAsync(id, updateFoodDto);
            if(food == null)
            {
                return NotFound();
            }
            return Ok(food);
        }

        //Delete: api/food/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteFood([FromRoute] Guid id)
        {
            var food = _foodService.DeleteFoodAsync(id);
            if(food == null)
            {
                return NotFound();
            }
            return Ok(food);
        }
    }
}
