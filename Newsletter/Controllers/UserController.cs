using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newsletter.Models;
using Newsletter.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpPost("Login")]
        public async Task<IActionResult> Login(CreateUser user)
        {
            var userObj = await _userService.GetUserByUserName(user.UserName);
            if (await _userService.ExistsUser(userObj.Id) == false) return NotFound();

            var token = await _userService.GenerateJwtToken(user);
            if (token == null) return Unauthorized();

            return Ok(token);
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserByID(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest("Id cannot be null");
            var result = await _userService.GetUserById(id);
            return Ok(result);
        }

        [HttpGet("GetUserByUserName")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName)) return NotFound();
            var result = await _userService.GetUserByUserName(userName);
            return Ok(result);
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsers();
            return Ok(result);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUser user)
        {
            if (user == null) return BadRequest("User cannot be null");
            var result = await _userService.CreateUser(user);
            if (result == null) return BadRequest("Create user Error!");
            return Created("/", result);
        }

        [HttpPatch("UpdateUser")]
        public async Task<IActionResult> UpdateUser(IdentityUser user)
        {
            if (user == null) return BadRequest("User cannot be null");
            if (await _userService.ExistsUser(user.Id)) return NotFound();
            var result = await _userService.UpdateUser(user);
            return Ok(result);
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest("Id cannot be null");
            if (await _userService.ExistsUser(id)) return NotFound();
            var result = await _userService.DeleteUser(id);
            return Ok(result);
        }
    }
}
