using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newsletter.Data;
using Newsletter.Models;
using Newsletter.Services;
using System.Collections.Generic;
using System.Linq;

namespace Newsletter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        private readonly IBaseRepository<News> _nRepository; 
        private readonly INewsRepository _newsRepository;

        public NewsController(IBaseRepository<News> nRepository, INewsService newsService, INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
            _newsService = newsService;
            _nRepository = nRepository;
        }

        [HttpGet]
        public IActionResult GetNewsByTittle(string tittle)
        {
            var result = _newsService.GetNewsByTittle(tittle);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet("GetAllNews")]
        public IActionResult GetAllNews()
        {
            var news = _newsService.GetAllNews();

            return Ok(news);
        }

        [HttpGet("Exists")]
        public IActionResult Exists(int id)
        {
            bool news = _nRepository.Exist(id);

            return Ok(news);
        }
        
        [HttpGet("GetNewsById")]
        public IActionResult GetNewsById(int id)
        {
            var news = _nRepository.GetById(id);

            if (news == null) return NotFound();
            return Ok(news);
        }

        [HttpPost("AddNews")]
        public IActionResult AddNews(News obj)
        {
            if (obj == null) return BadRequest();

            _newsService.AddNews(obj);
            return Ok(obj);
        }
    }
}
