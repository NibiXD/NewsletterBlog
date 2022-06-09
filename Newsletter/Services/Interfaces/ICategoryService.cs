using Newsletter.Dtos;
using Newsletter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Newsletter.Services.Interfaces
{
    public interface ICategoryService 
    {
        Task<Category> AddCategory(CategoryDto category);
        Task<Category> UpdateCategory(Category category);
        Task<bool> ExistCategory(int id);
        Task<bool> DeleteCategory(int id);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
    }
}
