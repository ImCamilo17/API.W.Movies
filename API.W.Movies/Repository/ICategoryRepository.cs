using API.W.Movies.DAL.Models;

namespace API.W.Movies.Repository
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetCategoriesAsync(); //Retorna una lista de las categorias
        Task<Category> GetCategoryAsync(int id); //Retorna una categoria por su Id
        Task<bool> CategoryExistByIdAsync(int id); //Verifica si una categoria existe por su Id
        Task<bool> CategoryExistByNameAsync(string name); //Verifica si una categoria existe por su Nombre
        Task<bool> CreateCategoryAsync(Category category); //Crea una nueva categoria
        Task<bool> UpdateCategoryAsync(Category category); //Crea una nueva categoria --Puedo actualizar el nombre y fecha de actualizacion
        Task<bool> DeleteCategoryAsync(int id); //Elimina una categoria 


    }
}
