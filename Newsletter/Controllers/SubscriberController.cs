using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newsletter.Data;
using Newsletter.Dtos;
using Newsletter.Models;
using System.Threading.Tasks;
using Userletter.Services.Interfaces;

namespace Newsletter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        private readonly ISubscriberService _subscriberService;

        public SubscriberController(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(SubscriberDto user)
        {
            if (user == null) return BadRequest();
            await _subscriberService.AddUser(user);

            return Ok(user);
        }
    }
}
