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
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        private readonly IStudentRepository _studentRepository;

        public StudentController(AppDbContext context, IMapper mapper, IStudentService studentService, IStudentRepository studentRepository)
        {
            _context = context;
            _mapper = mapper;
            this._studentService = studentService;
            _studentRepository = studentRepository;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllStudentsAsync();

            return Ok(students);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if(student == null)
            {
                return NotFound();
            }
            //Model to Dto
            return Ok(_mapper.Map<StudentWithAttendanceDto>(student));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentDto addStudentDto)
        {
            //Dto -> Model
            var student = _mapper.Map<Student>(addStudentDto);
            student = await _studentRepository.CreateAsync(student);
            
            //Model -> Dto
            var dto = _mapper.Map<StudentDto>(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, dto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid id, [FromBody] UpdateStudentDto updateStudentDto)
        {
            var student = _mapper.Map<Student>(updateStudentDto);
            student = await _studentRepository.UpdateAsync(id, student);
            if (student == null)
            {
                return NotFound();
            }
            //Model to Dto
            return Ok(_mapper.Map<StudentDto>(student));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var student = _studentRepository.DeleteAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            //Model to Dto
            return Ok(_mapper.Map<StudentDto>(student));
        }

    }
}
