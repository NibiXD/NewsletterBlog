using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newsletter.Models;
using Newsletter.Services;
using System.Threading.Tasks;
using AutoMapper;
using Newsletter.Dtos;

namespace Newsletter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        private readonly IMapper _mapper;

        public NewsController(INewsService newsService, IMapper mapper)
        {
            _newsService = newsService;
            _mapper = mapper;
        }

        [HttpGet("GetNewsByTittle")]
        public async Task<IActionResult> GetNewsByTittle(string tittle)
        {
            var result = await _newsService.GetNewsByTittle(tittle);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet("GetAllNews")]
        public async Task<IActionResult> GetAllNews()
        {
            var news = await _newsService.GetAllNews();

            return Ok(news);
        }

        [HttpGet("GetNewsLatestToOldest")]
        public async Task<IActionResult> GetNewsLatestToOldest()
        {
            var news = await _newsService.GetLatestToOldest();

            if (news == null) return NotFound();

            return Ok(news);
        }

        [HttpGet("Exists")]
        public async Task<IActionResult> Exists(int id)
        {
            bool news = await _newsService.ExistNews(id);

            return Ok(news);
        }
        
        [HttpGet("GetNewsById/{id}")]
        public async Task<IActionResult> GetNewsById(int id)
        {
            if (await _newsService.ExistNews(id) == false) return NotFound("News not found!");
            var news = await _newsService.GetNewsById(id);
            if (news == null) return NotFound();

            return Ok(news);
        }

        [HttpGet("GetNewsByCategoryId/{id}")]
        public async Task<IActionResult> GetNewsByCategoryId(int categoryId)
        {
            if (await _newsService.ExistNews(categoryId) == false) return NotFound("Category not found!");
            var news = await _newsService.GetNewsByCategoryId(categoryId);

            return Ok(news);
        }

        [HttpGet("GetNewsByCategoryName")]
        public async Task<IActionResult> GetNewsByCategoryName(string categoryName)
        {
            var news = await _newsService.GetNewsByCategoryName(categoryName);

            return Ok(news);
        }

        [Authorize]
        [HttpPost("AddNews")]
        public async Task<IActionResult> AddNews(NewsDto obj)
        {
            obj.NewsAuthor = User.Identity.Name;
            if (obj == null) return BadRequest();

            await _newsService.AddNews(obj);
            return Ok(obj);
        }

        [Authorize]
        [HttpPatch("UpdateNews")]
        public async Task<IActionResult> UpdateNews(NewsDto obj)
        {
            var result = _mapper.Map<News>(obj);
            if (obj == null) return BadRequest();

            await _newsService.UpdateNews(obj);
            return Ok(obj);
        }

        [Authorize]
        [HttpDelete("DeleteNews/{id}")]
        public async Task<IActionResult> DeleteNews(int id)
        {
            if (await _newsService.ExistNews(id) == false) return NotFound("News not found!");
            bool result = await _newsService.DeleteNews(id);

            if (!result) return BadRequest("Delete function error");
            return Ok("Object deleted");
        }
    }
}
