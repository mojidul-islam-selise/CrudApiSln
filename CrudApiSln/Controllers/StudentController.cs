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
        public async Task<IActionResult> CreateStudent(StudentDto student)
        {
            bool result = false;
            try
            {
                var response = await _studentService.AddStudent(student);
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
        public async Task<IActionResult> UpdateStudent(int id, StudentDto student)
        {
            try
            {
                bool result = false;
                var response = await _studentService.UpdateStudent(id, student);
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

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                bool result = false;
                var response = await _studentService.DeleteStudent(id);
                if (response != null && response.Id>0)
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
    }
}
