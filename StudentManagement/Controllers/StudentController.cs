using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.DbContexts;
using StudentManagement.Dtos.Students;
using StudentManagement.Services.Abstract;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ApplicationDbContext _dbContext;
        public StudentController(IStudentService studentService, ApplicationDbContext dbContext)
        {
            _studentService = studentService;
            _dbContext = dbContext;
        }

        [HttpPost("create")]
        public IActionResult CreateStudent(CreateStudentDto input)
        {
            return Ok(_studentService.CreateStudent(input));
        }

        [HttpGet("get-all")]
        public IActionResult GetAllStudents()
        {
            return Ok(_studentService.GetAllStudents());
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                var student = _studentService.GetStudentById(id);

                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public IActionResult UpdateStudent(int id, [FromBody] UpdateStudentDto input)
        {
            try
            {
                _studentService.UpdateStudent(id, input);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("delete")]
        public IActionResult DeleteStudent(int id)
        {
            try { 
                _studentService.DeleteStudent(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
