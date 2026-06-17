using AutoMapper;
using MessManagementSystem.Data;
using MessManagementSystem.Models.Domain;
using MessManagementSystem.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AttendanceController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        //GET: api/attendance

        [HttpGet]
        public IActionResult GetAllAttendances()
        {
            var attendances = _context.Attendances.ToList();
            return Ok(_mapper.Map<IEnumerable<AttendanceDto>>(attendances));
        }

        //GET: api/attendance/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetAttendanceById([FromRoute] Guid id)
        {
            var attendance = _context.Attendances.Include(s=>s.Student).FirstOrDefault(s => s.Id == id);
            if (attendance == null)
            {
                return NotFound();

            }
            //Model to Dto
            return Ok(_mapper.Map<AttendanceDto>(attendance));
        }

        //POST: api/attendance
        [HttpPost]
        public IActionResult AddAttendance([FromBody] AddAttendanceDto addAttendanceDto)
        {
            //Dto -> Model
            var attendance = _mapper.Map<Attendance>(addAttendanceDto);
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            //Model to Dto
            return Ok(_mapper.Map<AttendanceDto>(attendance));
        }

        //PUT: api/attendance/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateAttendance([FromRoute] Guid id, [FromBody] UpdateAttendanceDto updateAttendanceDto)
        {
            var attendance = _context.Attendances.FirstOrDefault(s => s.Id == id);
            if(attendance == null)
            {
                return NotFound();
            }
            _mapper.Map(updateAttendanceDto, attendance);
            _context.SaveChanges();
            //Model to Dto
            return Ok(_mapper.Map<AttendanceDto>(attendance));
        }

        //DELETE: api/attendance/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteAttendance([FromRoute] Guid id)
        {
            var attendance = _context.Attendances.FirstOrDefault(s => s.Id == id);
            if (attendance == null)
            {
                return NotFound();
            }
            _context.Attendances.Remove(attendance);
            _context.SaveChanges();
            //Model to Dto
            return Ok(_mapper.Map<AttendanceDto>(attendance));
        }
    }
}
