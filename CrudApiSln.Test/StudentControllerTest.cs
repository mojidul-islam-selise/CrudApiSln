using CrudApiSln.Controllers;
using CrudApiSln.DTOs;
using CrudApiSln.Models;
using CrudApiSln.Services;
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


        private List<StudentDto> GetStudentsData()
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
