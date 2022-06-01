using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newsletter.Data;
using Newsletter.Models;
using System.Threading.Tasks;
using Userletter.Services.Interfaces;

namespace Newsletter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("CreateUser")]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (user == null) return BadRequest();
            await _userService.AddUser(user);

            return Ok(user);
        }
    }
}
