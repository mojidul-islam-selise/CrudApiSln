using CrudApiSln.DTOs;

namespace CrudApiSln.Repositories
{
    public interface IStudentRepository
    {
        Task<StudentDto> AddStudent(StudentDto student);
        Task<StudentDto> DeleteStudent(int id);
        Task<StudentDto> GetStudentById(int id);
        Task<List<StudentDto>> GetStudents();
        Task<StudentDto> UpdateStudent(int id, StudentDto student);
    }
}
