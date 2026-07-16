using AutoMapper;
using MessManagementSystem.CustomActionFilters;
using MessManagementSystem.Data;
using MessManagementSystem.Models.Domain;
using MessManagementSystem.Models.DTO;
using MessManagementSystem.Repositories.Interfaces;
using MessManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            this.attendanceService = attendanceService;
        }

        //GET: api/attendance

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAttendances()
        {
            var attendances = await attendanceService.GetAllAttendancesAsync();
            return Ok(attendances);
        }

        //GET: api/attendance/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetAttendanceById([FromRoute] Guid id)
        {
            var attendance = await attendanceService.GetAttendanceByIdAsync(id);
            if(attendance == null) {
                return NotFound();
            }
            return Ok(attendance);
        }

        //POST: api/attendance
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddAttendance([FromBody] AddAttendanceDto addAttendanceDto)
        {
            var attendance = await attendanceService.AddAttendanceAsync(addAttendanceDto);
            return Ok(attendance);
        }

        //PUT: api/attendance/{id}
        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateAttendance([FromRoute] Guid id, [FromBody] UpdateAttendanceDto updateAttendanceDto)
        {
            var attendance = await attendanceService.UpdateAttendanceAsync(id, updateAttendanceDto);
            if (attendance == null)
            {
                return NotFound();
            }
            return Ok(attendance);
        }

        //DELETE: api/attendance/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAttendance([FromRoute] Guid id)
        {
            var attendance = await attendanceService.DeleteAttendanceAsync(id);
            if(attendance == null)
            {
                return NotFound();
            }
            return Ok(attendance);
        }
    }
}
