using AutoMapper;
using MessManagementSystem.Data;
using MessManagementSystem.Models.Domain;
using MessManagementSystem.Models.DTO;
using MessManagementSystem.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMenuRepository _menuRepository;

        public MenuController(AppDbContext context, IMapper mapper, IMenuRepository menuRepository)
        {
            _context = context;
            this._mapper = mapper;
            this._menuRepository = menuRepository;
        }

        //GET: api/menu
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var menus = await _menuRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<MenuDto>>(menus));
        }

        //GET: api/menu/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetMenuById([FromRoute] Guid id)
        {
            var menu = await _menuRepository.GetByIdAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<MenuDto>(menu));
        }

        //POST: api/menu
        [HttpPost]
        public async Task<IActionResult> CreateMenu([FromBody] AddMenuDto addMenuDto)
        {
            var menu = _mapper.Map<Menu>(addMenuDto);
            menu = await _menuRepository.CreateAsync(menu);
            
            return CreatedAtAction(nameof(GetMenuById), new { id = menu.MenuId }, _mapper.Map<MenuDto>(menu));
        }

        //PUT: api/menu/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateMenu([FromRoute] Guid id, [FromBody] UpdateMenuDto updateMenuDto)
        {
            var menu = _mapper.Map<Menu>(updateMenuDto);
            menu = await _menuRepository.UpdateAsync(id,menu);
            if (menu == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<MenuDto>(menu));

        }

        //DELETE: api/menu/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var menu = await _menuRepository.DeleteAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<MenuDto>(menu));
        }
    }
}
