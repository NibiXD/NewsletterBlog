using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newsletter.Data;
using Newsletter.Models;

namespace Newsletter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepo;

        public UserController(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet("CreateUser")]
        public IActionResult CreateUser(User user)
        {
            if (user == null) return BadRequest();
            _userRepo.Add(user);

            return Ok(user);
        }
    }
}
