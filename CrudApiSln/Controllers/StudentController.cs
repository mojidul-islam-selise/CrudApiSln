using CrudApiSln.DTOs;
using CrudApiSln.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudApiSln.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public IActionResult CreateStudent(StudentDto student)
        {
            bool result = false;
            try
            {
                var response = _studentService.AddStudent(student);
                if (response != null)
                {
                    result = true;
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<StudentDto>> GetStudentById(int studentID)
        {
            var response = await _studentService.GetStudentById(studentID);
            return response;
        }

        [HttpGet("List")]
        public async Task<ActionResult<List<StudentDto>>> GetStudents()
        {
            var response = await _studentService.GetStudents();
            return response;
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateStudent(int id, StudentDto student)
        {
            try
            {
                var response = await _studentService.UpdateStudent(id, student);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteStudent(int id)
        {
            try
            {
                var response = await _studentService.DeleteStudent(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
