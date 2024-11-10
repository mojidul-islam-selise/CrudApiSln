using CrudApiSln.Controllers;
using CrudApiSln.DTOs;
using CrudApiSln.Repositories;
using CrudApiSln.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApiSln.Test.Services
{
    public class StudentServiceTest
    {
        private readonly Mock<IStudentRepository> studentRepository;
        private readonly IStudentService studentService;
        public StudentServiceTest()
        {
            studentRepository = new Mock<IStudentRepository>();
            studentService = new StudentService(studentRepository.Object);
        }

        [Fact]
        public async Task Get_All_Student_StudentList()
        {
            //arrange
            var studentList = GetStudentsData();
            studentRepository.Setup(x => x.GetStudents())
               .ReturnsAsync(studentList);

            //act
            var result = await studentService.GetStudents();

            //assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<List<StudentDto>>();
            Assert.Equal(studentList.Count, result?.Count());
        }

        private List<StudentDto> GetStudentsData()
        {
            StudentControllerTest studentControllerTest = new StudentControllerTest();
            return studentControllerTest.GetStudentsData();
        }

    }
}
