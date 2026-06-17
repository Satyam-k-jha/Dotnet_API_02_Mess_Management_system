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
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Student
        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _context.Students
            .Select(s => new StudentDto
                {
            Id = s.Id,
            Name = s.Name
                    })
                .ToList();

            return Ok(_mapper.Map<IEnumerable<StudentDto>>(students));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var student = _context.Students.Include(s=>s.Attendances).FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            //Model to Dto
            return Ok(_mapper.Map<StudentWithAttendanceDto>(student));
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] AddStudentDto addStudentDto)
        {
            //Dto -> Model
            var student = _mapper.Map<Student>(addStudentDto);
            _context.Students.Add(student);
            _context.SaveChanges();
            //Model -> Dto
            var dto = _mapper.Map<StudentDto>(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, dto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateStudent([FromRoute] Guid id, [FromBody] UpdateStudentDto updateStudentDto)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            _mapper.Map(updateStudentDto, student);
            _context.SaveChanges();
            //var dto = new StudentDto
            //{
            //    Id = student.Id,
            //    Name = updateStudentDto.Name
            //};

            //Model to Dto
            return Ok(_mapper.Map<StudentDto>(student));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            _context.Students.Remove(student);
            _context.SaveChanges();
            //Model to Dto
            return Ok(_mapper.Map<StudentDto>(student));
        }

    }
}
