using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newsletter.Dtos;
using Newsletter.Models;
using System.Threading.Tasks;
using Userletter.Services.Interfaces;

namespace Newsletter.Controllers.Admin_Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminSubscriberController : ControllerBase
    {
        private readonly ISubscriberService _subscriberService;

        public AdminSubscriberController(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }

        [Authorize]
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetALlUsers()
        {
            var categories = await _subscriberService.GetAllUsers();

            return Ok(categories);
        }

        [Authorize]
        [HttpGet("ExistsUser/{id}")]
        public async Task<IActionResult> ExistsUser(int userId)
        {
            if (await _subscriberService.ExistUser(userId) == false) return NotFound("User not found!");
            var categories = await _subscriberService.ExistUser(userId);

            return Ok(categories);
        }

        [Authorize]
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(SubscriberDto obj)
        {
            if (obj == null) return BadRequest();

            await _subscriberService.AddUser(obj);
            return Ok(obj);
        }

        [Authorize]
        [HttpPatch("UpdateUser")]
        public async Task<IActionResult> UpdateUser(SubscriberDto obj)
        {
            if (obj == null) return BadRequest();

            await _subscriberService.UpdateUser(obj);
            return Ok(obj);
        }

        [Authorize]
        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            if (await _subscriberService.ExistUser(userId) == false) return NotFound();
            bool result = await _subscriberService.DeleteUser(userId);
            if (!result) return BadRequest("Failed to delete user");
            return Ok("User deleted!");
        }
    }
}
