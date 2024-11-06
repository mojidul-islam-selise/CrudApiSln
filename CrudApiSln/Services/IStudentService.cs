using CrudApiSln.DTOs;

namespace CrudApiSln.Services
{
    public interface IStudentService
    {
        Task<StudentDto> AddStudent(StudentDto student);
        Task<StudentDto> DeleteStudent(int id);
        Task<StudentDto> GetStudentById(int id);
        Task<List<StudentDto>> GetStudents();
        Task<StudentDto> UpdateStudent(int id, StudentDto student);
    }
}
