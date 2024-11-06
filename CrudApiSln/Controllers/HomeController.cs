using Microsoft.AspNetCore.Mvc;

namespace CrudApiSln.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpGet("index/{guessNumber}")]
        public string Index(int guessNumber)
        {
            string response = string.Empty;
            if (guessNumber > 100)
            {
                response = "Wrong! Your guess is High!";
            }
            else if (guessNumber < 100)
            {
                response = "Wrong! Your guess is low!";
            }
            else
            {
                response = "Your guess is correct!";
            }
            return response;
        }
    }
}
