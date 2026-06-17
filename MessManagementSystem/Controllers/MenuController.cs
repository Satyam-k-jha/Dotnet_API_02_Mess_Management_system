using MessManagementSystem.Data;
using MessManagementSystem.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MenuController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/menu
        [HttpGet]
        public IActionResult GetAll()
        {
            var menus = _context.Menus.ToList();
            return Ok(menus);
        }

        //GET: api/menu/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetMenuById([FromRoute] Guid id)
        {
            var menu = _context.Menus.FirstOrDefault(s => s.MenuId == id);
            if (menu == null)
            {
                return NotFound();
            }
            return Ok(menu);
        }

        //POST: api/menu
        [HttpPost]
        public IActionResult CreateMenu([FromBody] Menu menu)
        {
            _context.Menus.Add(menu);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMenuById), new { id = menu.MenuId }, menu);
        }

        //PUT: api/menu/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateMenu([FromRoute] Guid id, [FromBody] Menu newMenu)
        {
            var menu = _context.Menus.FirstOrDefault(s => s.MenuId == id);
            if (menu == null)
            {
                return NotFound();
            }
            menu.Foods = newMenu.Foods;
            _context.SaveChanges();
            return Ok(menu);

        }

        //DELETE: api/menu/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var menu = _context.Menus.FirstOrDefault(s => s.MenuId == id);
            if (menu == null)
            {
                return NotFound();
            }
            _context.Menus.Remove(menu);
            return Ok(menu);
        }
    }
}
