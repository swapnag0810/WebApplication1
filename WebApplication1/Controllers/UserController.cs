using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DBFirstApproach;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private TestdbContext _testdbContext;

        public UserController(ILogger<UserController> logger, TestdbContext testdbContext)
        {
            _logger = logger;
            _testdbContext = testdbContext;
        }

        //public IActionResult GetUser()
        //{

        //}
        [HttpPost(Name = "AddUser")]
        public async Task<IActionResult> AddUser(User userobj)
        {
            try
            {
                _testdbContext.Users.Add(userobj);
                await _testdbContext.SaveChangesAsync();
                return Ok(new { success = "true" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

   
