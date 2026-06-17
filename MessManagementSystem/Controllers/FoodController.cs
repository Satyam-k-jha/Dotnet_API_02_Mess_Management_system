using AutoMapper;
using MessManagementSystem.Data;
using MessManagementSystem.Models.Domain;
using MessManagementSystem.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public FoodController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //GET: api/Food
        [HttpGet]
        public IActionResult GefAllFoods()
        {
                var foods = _context.Foods.ToList();
                return Ok(_mapper.Map<IEnumerable<FoodDto>>(foods));
        }
        //GET: api/food/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetFoodById([FromRoute] Guid id)
        {
            var food = _context.Foods.FirstOrDefault(s => s.Id == id);
            if (food == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<FoodDto>(food));
        }

        //POST: api/food
        [HttpPost]
        public IActionResult AddFood([FromBody] AddFoodDto addFoodDto)
        {
            var food = _mapper.Map<Food>(addFoodDto);
            _context.Foods.Add(food);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFoodById), new { id = food.Id }, food);
        }

        //PUT: api/food/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateFood([FromRoute] Guid id, [FromBody] UpdateFoodDto updateFoodDto)
        {
            var food = _context.Foods.FirstOrDefault(s => s.Id == id);
            if (food == null)
            {
                return NotFound();
            }
            _mapper.Map(updateFoodDto, food);
            _context.SaveChanges();
            return Ok(_mapper.Map<FoodDto>(food));
        }

        //Delete: api/food/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteFood([FromRoute] Guid id)
        {
            var food = _context.Foods.FirstOrDefault(s => s.Id == id);
            if (food == null)
            {
                return NotFound();

            }
            _context.Foods.Remove(food);
            _context.SaveChanges();
            return Ok(_mapper.Map<FoodDto>(food));
        }
    }
}
