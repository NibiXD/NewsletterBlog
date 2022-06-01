using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newsletter.Models;
using System.Threading.Tasks;
using Userletter.Services.Interfaces;

namespace Newsletter.Controllers.Admin_Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        private readonly IUserService _userService;

        public AdminUserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetALlUsers()
        {
            var categories = await _userService.GetAllUsers();

            return Ok(categories);
        }

        [HttpGet("ExistsUser/{id}")]
        public async Task<IActionResult> ExistsUser(int userId)
        {
            if (await _userService.ExistUser(userId) == false) return NotFound("User not found!");
            var categories = await _userService.ExistUser(userId);

            return Ok(categories);
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(User obj)
        {
            if (obj == null) return BadRequest();

            await _userService.AddUser(obj);
            return Ok(obj);
        }

        [HttpPatch("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User obj)
        {
            if (obj == null) return BadRequest();

            await _userService.UpdateUser(obj);
            return Ok(obj);
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            bool result = await _userService.DeleteUser(userId);
            if (!result) return NotFound("User not found");
            return Ok("User deleted!");
        }
    }
}
