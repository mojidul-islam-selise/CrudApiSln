using CrudApiSln.Controllers;
using CrudApiSln.DTOs;
using CrudApiSln.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CrudApiSln.Test
{
    public class StudentControllerTest
    {
        private readonly Mock<IStudentService> studentService;
        private readonly StudentController studentController;
        public StudentControllerTest()
        {
            studentService = new Mock<IStudentService>();
            studentController = new StudentController(studentService.Object);
        }

        [Fact]
        public async Task Get_All_Student_StudentList()
        {
            //arrange
            var studentList = GetStudentsData();
            studentService.Setup(x => x.GetStudents())
               .ReturnsAsync(studentList);

            //act
            var result = await studentController.GetStudents();

            //assert
            Assert.NotNull(result.Value);
            Assert.Equal(3, result.Value.Count());
        }


        [Fact]
        public async Task GetStudentByID_UsingValidIdStudentId()
        {
            //arrange
            // Define the Book ID to retrieve
            var id =1;
            // Define the expected Book
            var students = GetStudentsData();
            var expectedStudent = students.FirstOrDefault(x => x.Id == id);
            // Configure the mock service to return the expected Book
            studentService.Setup(service => service.GetStudentById(id)).ReturnsAsync(expectedStudent);

            //act
            var studentResult = await studentController.GetStudentById(id);
            //var resultType = (OkObjectResult)bookResult.Result;
            //var book = (Book)resultType.Value;
            //var book = bookResult.Value;

            //assert
            // Check that result is not null
            Assert.NotNull(studentResult.Value);
            // Check that the ID of the returned user is correct
            //Assert.Equal(id, studentResult?.Id);
            Assert.Equal(expectedStudent, studentResult.Value);
            //Assert.Equal(200, resultType.StatusCode);
        }

        [Fact]
        public async Task GetStudentByID_UsingInvalidIdStudentId()
        {
            //arrange
            // Define the Book ID to retrieve
            var id = 6;
            // Define the expected Book
            var students = GetStudentsData();
            var expectedStudent = students.FirstOrDefault(x => x.Id == id);
            // Configure the mock service to return the expected Book
            studentService.Setup(service => service.GetStudentById(id)).ReturnsAsync(expectedStudent);

            //act
            var studentResult = await studentController.GetStudentById(id);
            //var resultType = (OkObjectResult)bookResult.Result;
            //var book = (Book)resultType.Value;
            //var book = bookResult.Value;

            //assert
            // Check that result is not null
            Assert.Null(studentResult.Value);
            // Check that the ID of the returned user is correct
            //Assert.Equal(id, studentResult?.Id);
            //Assert.Equal(expectedStudent, studentResult.Value);
            //Assert.Equal(200, resultType.StatusCode);
        }

        [Fact]
        public async Task AddStudent_AddStudentCorrectly()
        {
            // Arrange
            var newStudent = new StudentDto
            {
                Id = 4,
                Name = "Book Test 4",
                Department = "CSE",
                Section = "B",
                DateOfBirth = new DateOnly(1995, 8, 19),
                Age = 30.5f,
                Address = "Dhaka, Bangladesh"
            };
            studentService.Setup(service => service.AddStudent(newStudent)).ReturnsAsync(newStudent);

            // Act
            var result = await studentController.CreateStudent(newStudent) as OkObjectResult;

            // Assert
            Assert.NotNull(result); // Check that the student was added and returned
            Assert.True((bool)result?.Value); // Check that the return value is true
            Assert.Equal(200, result?.StatusCode); // Check that the status code is correct
        }

        [Fact]
        public async Task UpdateStudent_UpdateStudentCorrectly()
        {
            // Arrange
            int id = 3;
            var editStudent = new StudentDto
            {
                Id = 3,
                Name = "Book Test 3 Update",
                Department = "CSE",
                Section = "B",
                DateOfBirth = new DateOnly(1995, 8, 19),
                Age = 30.5f,
                Address = "Badda, Dhaka, Bangladesh"
            };
            studentService.Setup(service => service.UpdateStudent(id, editStudent)).ReturnsAsync(editStudent);

            // Act
            var result = await studentController.UpdateStudent(id, editStudent) as OkObjectResult;

            // Assert
            Assert.NotNull(result); // Check that the student was added and returned
            Assert.True((bool)result?.Value); // Check that the return value is true
            Assert.Equal(200, result?.StatusCode); // Check that the status code is correct
        }

        [Fact]
        public async Task DeleteStudent_DeleteStudentCorrectly()
        {
            // Arrange
            int id = 3;//pass
            //int id = 6;//fail
            var students = GetStudentsData();
            var expectedStudent = students.FirstOrDefault(x => x.Id == id);
            studentService.Setup(service => service.DeleteStudent(id)).ReturnsAsync(expectedStudent);

            // Act
            //var result = studentController.DeleteStudent(id) as OkObjectResult;
            var result = await studentController.DeleteStudent(id);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            result.Should().NotBeNull();
            //Assert.NotNull(result); // Check that the student was added and returned
            //Assert.True((bool)result?.Value); // Check that the return value is true
            result.Should().BeAssignableTo<OkObjectResult>();
            //result?.Should().Equals(200)); // Check that the status code is correct
            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.Be(true);
        }

        public List<StudentDto> GetStudentsData()
        {
            List<StudentDto> studentData = new List<StudentDto>
            {
                new StudentDto
                {
                    Id = 1,
                    Name = "Book Test 1",
                    Department = "CSE",
                    Section = "A",
                    DateOfBirth = new DateOnly(1995, 8, 19),
                    Age = 30.5f,
                    Address = "Dhaka, Bangladesh"
                },
                new StudentDto
                {
                    Id = 2,
                    Name = "Book Test 2",
                    Department = "CSE",
                    Section = "A",
                    DateOfBirth = new DateOnly(1995, 8, 19),
                    Age = 30.5f,
                    Address = "Dhaka, Bangladesh"
                },
                new StudentDto
                {
                    Id = 3,
                    Name = "Book Test 3",
                    Department = "CSE",
                    Section = "A",
                    DateOfBirth = new DateOnly(1995, 8, 19),
                    Age = 30.5f,
                    Address = "Dhaka, Bangladesh"
                },
            };
            return studentData;
        }
    }
}
