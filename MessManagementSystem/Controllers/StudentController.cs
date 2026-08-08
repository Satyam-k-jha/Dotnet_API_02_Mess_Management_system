using AutoMapper;
using MessManagementSystem.CustomActionFilters;
using MessManagementSystem.Data;
using MessManagementSystem.Models.Domain;
using MessManagementSystem.Models.DTO;
using MessManagementSystem.Repositories.Interfaces;
using MessManagementSystem.Services.Implementations;
using MessManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace MessManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles =("Admin"))]
    public class StudentController : ControllerBase
    {
       
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
           
            this._studentService = studentService;
           
        }

        // GET: api/Student
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllStudentsAsync();

            return Ok(students);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if(student == null)
            {
                return NotFound("Student not found");
            }
            return Ok(student);
        }


        //Logged in user data

        [HttpGet("me")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetMyProfile()
        {
            var studentId = User.FindFirst("StudentId")?.Value;

            if (studentId == null)
                return Unauthorized();

            var student = await _studentService.GetStudentByIdAsync(Guid.Parse(studentId));

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentDto addStudentDto)
        {
            var student = await _studentService.AddStudentAsync(addStudentDto);
            return CreatedAtAction(nameof(GetById), new Student { Id = student.Id},student);
            
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid id, [FromBody] UpdateStudentDto updateStudentDto)
        {
            var student = await _studentService.UpdateStudentAsync(id, updateStudentDto);
            if (student == null)
            {
                return NotFound("Student Not Found");
            }
            return Ok(student);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var student = await _studentService.DeleteStudentsSafely(id);
            if (student == null)
            {
                return NotFound("Student not Found");
            }
            //Model to Dto
            return Ok(student);
        }

    }
}
