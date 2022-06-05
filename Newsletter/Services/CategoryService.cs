using Microsoft.EntityFrameworkCore;
using Newsletter.Data;
using Newsletter.Models;
using Newsletter.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Newsletter.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> AddCategory(Category entity)
        {
            return await _categoryRepository.AddAsync(entity);

        }

        public async Task<bool> DeleteCategory(int id)
        {
            return await _categoryRepository.DeleteAsync(id);

        }

        public async Task<bool> ExistCategory(int id)
        {
            return await _categoryRepository.ExistAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<Category> UpdateCategory(Category entity)
        {
            return await _categoryRepository.UpdateAsync(entity);
        }
    }
}
