using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newsletter.Data;
using Newsletter.Dtos;
using Newsletter.Models;
using Newsletter.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Newsletter.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Category> AddCategory(CategoryDto entity)
        {
            var result = _mapper.Map<Category>(entity);
            return await _categoryRepository.AddAsync(result);
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
