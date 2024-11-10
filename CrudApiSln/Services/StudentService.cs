using CrudApiSln.Repositories;
using CrudApiSln.DTOs;

namespace CrudApiSln.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository) { 
            _studentRepository = studentRepository;
        }
        public async Task<StudentDto> AddStudent(StudentDto student)
        {
            try
            {
                return await _studentRepository.AddStudent(student);
            }
            catch (Exception ex)
            {
                throw new Exception("Student not added!");
            }
        }

        public async Task<StudentDto> DeleteStudent(int id)
        {
            try
            {
                var student = await _studentRepository.GetStudentById(id);
                if (student == null || student.Id == 0)
                {
                    throw new Exception("Student not Found!");
                }
                return await _studentRepository.DeleteStudent(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Student not Deleted!");
            }
        }

        public async Task<StudentDto> GetStudentById(int id)
        {
            try
            {
                var student = await _studentRepository.GetStudentById(id);
                if (student == null || student.Id == 0)
                {
                    throw new Exception("Student not Found!");
                }
                return student;
            }
            catch (Exception ex)
            {
                throw new Exception("Student not Found!");
            }
        }

        public async Task<List<StudentDto>> GetStudents()
        {
            try
            {
                return await _studentRepository.GetStudents();
            }
            catch (Exception ex)
            {
                throw new Exception("Students not added!");
            }
        }

        public async Task<StudentDto> UpdateStudent(int id, StudentDto student)
        {
            try
            {
                return await _studentRepository.UpdateStudent(id, student);
            }
            catch (Exception ex)
            {
                throw new Exception("Student not Updated!");
            }
        }
    }
}
