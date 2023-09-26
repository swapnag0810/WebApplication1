using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        //public IActionResult GetUser()
        //{

        //}
        //[HttpPost(Name = "AddUser")]
        //public IEnumerable<User> AddUser()
        //{
           
        //}

    }
}
