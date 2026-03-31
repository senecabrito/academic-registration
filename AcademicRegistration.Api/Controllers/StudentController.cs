using AcademicRegistration.Business.DTOs;
using AcademicRegistration.Business.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AcademicRegistration.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentService studentService, ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            _logger.LogInformation("Fetching all students.");
            return Ok(_studentService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(Guid id)
        {
            _logger.LogInformation("Fetching student with ID {id}", id);
            var student = _studentService.FindById(id);
            if (student == null)
            {
                _logger.LogWarning("Student with ID {id} not found", id);
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create([FromBody] StudentDTO student)
        {
            _logger.LogInformation("Create new student: {Name}", student.Name);
            var createdStudent = _studentService.Create(student);
            if (createdStudent == null)
            {
                _logger.LogError("Error creating student.");
                return BadRequest();
            }
            return Ok(createdStudent);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] StudentDTO student)
        {
            if (id != student.Id)
            {
                _logger.LogWarning("Route ID {id} does not match student ID {studentId}", id, student.Id);
                return BadRequest("ID mismatch.");
            }

            var existingStudent = _studentService.FindById(id);
            if (existingStudent == null)
            {
                _logger.LogWarning("Student with ID {id} not found for update", id);
                return NotFound();
            }

            _logger.LogInformation("Updating student with ID {id}", id);

            var updatedStudent = _studentService.Update(student);
            return Ok(updatedStudent);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _logger.LogInformation("Deleting student with ID {id}", id);
            var existingStudent = _studentService.FindById(id);
            if (existingStudent == null)
            {
                _logger.LogWarning("Error deleting student with ID {id}", id);
                return NotFound();
            }
            _studentService.Delete(id);
            return NoContent();
        }
    }
}
