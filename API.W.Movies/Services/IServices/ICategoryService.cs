using API.W.Movies.DAL.Models;
using API.W.Movies.DAL.Models.Dtos;

namespace API.W.Movies.Services.IServices
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryDto>> GetCategoriesAsync(); 
        Task<CategoryDto> GetCategoryAsync(int id); 
        Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryDto); 
        Task<CategoryDto> UpdateCategoryAsync(int id, Category categoryDto); 
        Task<bool> CategoryExistByIdAsync(int id);
        Task<bool> CategoryExistByNameAsync(string name); 
        Task<bool> DeleteCategoryAsync(int id); 
    }
}
