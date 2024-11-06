using CrudApiSln.Controllers;
using System;
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
    }
}
