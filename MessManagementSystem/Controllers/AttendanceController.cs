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
    public class AttendanceController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceController(AppDbContext context, IMapper mapper,IAttendanceRepository attendanceRepository)
        {
            _context = context;
            this._mapper = mapper;
            this._attendanceRepository = attendanceRepository;
        }

        //GET: api/attendance

        [HttpGet]
        public async Task<IActionResult> GetAllAttendances()
        {
            var attendances = await _attendanceRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<AttendanceDto>>(attendances));
        }

        //GET: api/attendance/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetAttendanceById([FromRoute] Guid id)
        {
            var attendance = await _attendanceRepository.GetByIdAsync(id);
            if (attendance == null)
            {
                return NotFound();

            }
            //Model to Dto
            return Ok(_mapper.Map<AttendanceDto>(attendance));
        }

        //POST: api/attendance
        [HttpPost]
        public async Task<IActionResult> AddAttendance([FromBody] AddAttendanceDto addAttendanceDto)
        {
            //Dto -> Model
            var attendance = _mapper.Map<Attendance>(addAttendanceDto);
            attendance = await _attendanceRepository.CreateAsync(attendance);
            //Model to Dto
            return Ok(_mapper.Map<AttendanceDto>(attendance));
        }

        //PUT: api/attendance/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateAttendance([FromRoute] Guid id, [FromBody] UpdateAttendanceDto updateAttendanceDto)
        {

            var attendance = _mapper.Map<Attendance>(updateAttendanceDto);
            attendance = await _attendanceRepository.UpdateAsync(id, attendance);
            if(attendance == null)
            {
                return NotFound();
            }
            //Model to Dto
            return Ok(_mapper.Map<AttendanceDto>(attendance));
        }

        //DELETE: api/attendance/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAttendance([FromRoute] Guid id)
        {
            var attendance = await _attendanceRepository.DeleteAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }
            //Model to Dto
            return Ok(_mapper.Map<AttendanceDto>(attendance));
        }
    }
}
