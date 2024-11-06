using CrudApiSln.Repositories;
using CrudApiSln.DTOs;
using CrudApiSln.Models;

namespace CrudApiSln.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository) { 
            _studentRepository = studentRepository;
        }
        public Task<StudentDto> AddStudent(StudentDto student)
        {
            try
            {
                return _studentRepository.AddStudent(student);
            }
            catch (Exception ex)
            {
                throw new Exception("Student not added!");
            }
        }

        public Task<StudentDto> DeleteStudent(int id)
        {
            try
            {
                return _studentRepository.DeleteStudent(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Student not Deleted!");
            }
        }

        public Task<StudentDto> GetStudentById(int id)
        {
            try
            {
                return _studentRepository.GetStudentById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Student not Found!");
            }
        }

        public Task<List<StudentDto>> GetStudents()
        {
            try
            {
                return _studentRepository.GetStudents();
            }
            catch (Exception ex)
            {
                throw new Exception("Students not added!");
            }
        }

        public Task<StudentDto> UpdateStudent(int id, StudentDto student)
        {
            try
            {
                return _studentRepository.UpdateStudent(id, student);
            }
            catch (Exception ex)
            {
                throw new Exception("Student not Updated!");
            }
        }
    }
}
