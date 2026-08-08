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
using System.Security.Claims;

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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAttendances()
        {
            var attendances = await attendanceService.GetAllAttendancesAsync();
            return Ok(attendances);
        }

        [HttpGet("me")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetMyAttendance()
        {
            var studentId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (studentId == null)
            {
                return Unauthorized();
            }
            //Console.WriteLine(studentId);
            var attendance = await attendanceService.GetAttendanceByUserIdAsync(Guid.Parse(studentId));
            if(attendance == null)
            {
                return NotFound();
            }
            return Ok(attendance);
        }

        //GET: api/attendance/{id}
        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAttendanceById([FromRoute] Guid id)
        {
            var attendance = await attendanceService.GetAttendanceByIdAsync(id);
            if(attendance == null) {
                return NotFound();
            }
            return Ok(attendance);
        }

        //GET: api/attendance/{studentid}
        [HttpGet]
        [Route("student/{studentId:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAttendanceByStudentId([FromRoute] Guid studentId)
        {
            var attendance = await attendanceService.GetAttendanceByStudentIdAsync(studentId);
            if (attendance == null)
            {
                return NotFound();
            }
            return Ok(attendance);
        }

        //POST: api/attendance
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> AddAttendance([FromBody] AddAttendanceDto addAttendanceDto)
        {
            var attendance = await attendanceService.AddAttendanceAsync(addAttendanceDto);
            return Ok(attendance);
        }

        //PUT: api/attendance/{id}
        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
