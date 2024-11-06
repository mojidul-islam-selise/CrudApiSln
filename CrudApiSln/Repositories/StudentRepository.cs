using AutoMapper;
using CrudApiSln.DTOs;
using CrudApiSln.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApiSln.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public StudentRepository(
            ApplicationDbContext dbContext,
            IMapper mapper
            )
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<StudentDto> AddStudent(StudentDto student)
        {
            var entity = _mapper.Map<Student>(student);
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            student.Id = entity.Id;
            return student;
        }

        public async Task<StudentDto> DeleteStudent(int id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto> GetStudentById(int id)
        {
            var entity = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            var dto = _mapper.Map<StudentDto>(entity);
            return dto;
        }

        public async Task<List<StudentDto>> GetStudents()
        {
            var entities = await _dbContext.Students.ToListAsync();
            var dtos = _mapper.Map<List<StudentDto>>(entities);
            return dtos;
        }

        public async Task<StudentDto> UpdateStudent(int id, StudentDto student)
        {
            var existStudent = await _dbContext.Students.FindAsync(id);
            if (existStudent == null)
            {
                return new StudentDto();
            }
            existStudent.Name = student.Name;
            existStudent.Department = student.Department;
            existStudent.Section = student.Section;
            existStudent.DateOfBirth = student.DateOfBirth;
            existStudent.Address = student.Address;

            _dbContext.Update(existStudent);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<StudentDto>(existStudent);
        }
    }
}
