using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.DbContexts;
using StudentManagement.Dtos.Classrooms;
using StudentManagement.Dtos.Students;
using StudentManagement.Services.Abstract;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly IClassroomService _classroomService;
        private readonly ApplicationDbContext _dbContext;
        public ClassroomController(IClassroomService classroomService, ApplicationDbContext dbContext)
        {
            _classroomService = classroomService;
            _dbContext = dbContext;
        }
        [HttpPost("add-student")]
        public IActionResult AddStudent(AddStudentToClassDto input)
        {
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult CreateStudent(CreateClassroomDto input)
        {
            return Ok(_classroomService.CreateClassroom(input));
        }

        [HttpGet("get-all")]
        public IActionResult GetAllClassrooms()
        {
            return Ok(_classroomService.GetAllStudents());
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                var classroom = _classroomService.GetClassroomById(id);

                return Ok(classroom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public IActionResult UpdateClassroom(int id, [FromBody] UpdateClassroomDto input)
        {
            try
            {
                _classroomService.UpdateClassroom(id, input);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("delete")]
        public IActionResult DeleteClassroom(int id)
        {
            try
            {
                _classroomService.DeleteClassroom(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
