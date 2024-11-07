using CrudApiSln.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApiSln.Test.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void HomeController_Index_ValidLargeNumberResult()
        {
            //Arrange
            HomeController homeController = new HomeController();
            int guessNumber = 120;
            string expectedResult = "Wrong! Your guess is High!";

            //Act
            string result = homeController.Index(guessNumber);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void HomeController_Index_ValidSmallNumberResult()
        {
            //Arrange
            HomeController homeController = new HomeController();
            int guessNumber = 90;
            string expectedResult = "Wrong! Your guess is low!";

            //Act
            string result = homeController.Index(guessNumber);

            //Assert
            Assert.Equal(expectedResult, result);
        }
        //response = "Your guess is correct!";
        [Fact]
        public void HomeController_Index_ValidCorrectNumberResult()
        {
            //Arrange
            HomeController homeController = new HomeController();
            int guessNumber = 100;
            string expectedResult = "Your guess is correct!";

            //Act
            string result = homeController.Index(guessNumber);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        //if the methods have parameter then we use theory
        [Theory]
        [InlineData(80, "Wrong! Your guess is low!")]
        [InlineData(100, "Your guess is correct!")]
        [InlineData(120, "Wrong! Your guess is High!")]
        public void HomeController_Index_ValidNumberResult(int number, string expectedResultInput)
        {
            //Arrange
            HomeController homeController = new HomeController();
            int guessNumber = number;            

            //Act
            string result = homeController.Index(guessNumber);

            //Assert
            Assert.Equal(expectedResultInput, result);
        }

        [Theory]
        [ClassData(typeof (ValidNumberCollection))]
        public void HomeController_Index_ValidNumberUsingClassDataResult(int number, string expectedResultInput)
        {
            //Arrange
            HomeController homeController = new HomeController();
            int guessNumber = number;

            //Act
            string result = homeController.Index(guessNumber);

            //Assert
            Assert.Equal(expectedResultInput, result);
        }
    }

    public class ValidNumberCollection: IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 80, "Wrong! Your guess is low!" };
            yield return new object[] { 100, "Your guess is correct!" };
            yield return new object[] { 120, "Wrong! Your guess is High!" };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
