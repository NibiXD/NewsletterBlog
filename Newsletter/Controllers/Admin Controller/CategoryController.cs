using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newsletter.Data;
using Newsletter.Models;
using Newsletter.Services.Interfaces;
using System.Threading.Tasks;

namespace Newsletter.Controllers.Admin_Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetALlCategories()
        {
            var categories = await _categoryService.GetAllCategories();

            return Ok(categories);
        }

        [HttpGet("ExistsCategory/{id}")]
        public async Task<IActionResult> ExistsCategory(int categoryId)
        {
            if (await _categoryService.ExistCategory(categoryId) == false) return NotFound("Category not found!");
            var categories = await _categoryService.ExistCategory(categoryId);

            return Ok(categories);
        }

        [Authorize]
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(Category obj)
        {
            if (obj == null) return BadRequest();

            await _categoryService.AddCategory(obj);
            return Ok(obj);
        }

        [Authorize]
        [HttpPatch("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(Category obj)
        {
            if (obj == null) return BadRequest();

            await _categoryService.UpdateCategory(obj);
            return Ok(obj);
        }

        [Authorize]
        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            bool result = await _categoryService.DeleteCategory(categoryId);
            if (!result) return NotFound("Category not found");
            return Ok("Category deleted!");
        }
    }
}
