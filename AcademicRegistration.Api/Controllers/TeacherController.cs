using AcademicRegistration.Business.DTOs;
using AcademicRegistration.Business.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AcademicRegistration.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly ILogger<TeacherController> _logger;

        public TeacherController(ITeacherService teacherService, ILogger<TeacherController> logger)
        {
            _teacherService = teacherService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            _logger.LogInformation("Fetching all teachers.");
            return Ok(_teacherService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(Guid id)
        {
            _logger.LogInformation("Fetching teacher with ID {id}", id);
            var teacher = _teacherService.FindById(id);
            if (teacher == null)
            {
                _logger.LogWarning("Teacher with ID {id} not found", id);
                return NotFound();
            }
            return Ok(teacher);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TeacherDTO teacher)
        {
            _logger.LogInformation("Create new teacher: {Name}", teacher.Name);
            var createdTeacher = _teacherService.Create(teacher);
            if (createdTeacher == null)
            {
                _logger.LogError("Error creating teacher.");
                return BadRequest();
            }
            return Ok(createdTeacher);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] TeacherDTO teacher)
        {
            if (id != teacher.Id)
            {
                _logger.LogWarning("Route ID {id} does not match teacher ID {teacherId}", id, teacher.Id);
                return BadRequest("ID mismatch.");
            }

            var existingTeacher = _teacherService.FindById(id);
            if (existingTeacher == null)
            {
                _logger.LogWarning("Teacher with ID {id} not found for update", id);
                return NotFound();
            }

            _logger.LogInformation("Updating teacher with ID {id}", id);

            var updatedTeacher = _teacherService.Update(teacher);
            return Ok(updatedTeacher);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _logger.LogInformation("Deleting teacher with ID {id}", id);
            var existingTeacher = _teacherService.FindById(id);
            if (existingTeacher == null)
            {
                _logger.LogWarning("Error deleting teacher with ID {id}", id);
                return NotFound();
            }
            _teacherService.Delete(id);
            return NoContent();
        }
    }
}
