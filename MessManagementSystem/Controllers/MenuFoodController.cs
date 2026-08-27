using MessManagementSystem.CustomActionFilters;
using MessManagementSystem.Models.DTO;
using MessManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuFoodController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuFoodController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        //GET: api/menu
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var menus = await _menuService.GetAllMenusAsync();
            return Ok(menus);
        }

        //GET: api/menu/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetMenuById([FromRoute] Guid id)
        {
            var menu = await _menuService.GetMenuByIdAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            return Ok(menu);
        }

        //POST: api/menu
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateMenu([FromBody] AddMenuDto addMenuDto)
        {
            var menu = await _menuService.AddMenuAsync(addMenuDto);
            return CreatedAtAction(nameof(GetMenuById), new { id = menu.MenuId }, menu);
        }

        //PUT: api/menu/{id}
        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateMenu([FromRoute] Guid id, [FromBody] UpdateMenuDto updateMenuDto)
        {
            var menu = await _menuService.UpdateMenuAsync(id, updateMenuDto);
            if (menu == null)
            {
                return NotFound();
            }
            return Ok(menu);
        }

        //DELETE: api/menu/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var menu = await _menuService.DeleteMenuAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            return Ok(menu);
        }
    }
}
