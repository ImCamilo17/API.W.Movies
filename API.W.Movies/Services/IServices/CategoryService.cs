using API.W.Movies.DAL.Models;
using API.W.Movies.DAL.Models.Dtos;
using API.W.Movies.Repository;
using API.W.Movies.Services.IServices;
using AutoMapper;

namespace API.W.Movies.Services.IServices
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

        public async Task<bool> CategoryExistByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CategoryExistByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryCreateDto)
        {
            //Validar si la categoria existe
           var categoryExist = await _categoryRepository.CategoryExistByNameAsync(categoryCreateDto.Name);
            if (categoryExist)
            {
                throw new InvalidOperationException($"Ya existe una categoria con el nombre '{categoryCreateDto.Name}'");
            } 

            //Mapear el DTO a la entidad
            var category = _mapper.Map<Category>(categoryCreateDto);

            //Crear la categoria en el repositorio
            var categoryCreated = await _categoryRepository.CreateCategoryAsync(category);

            if (!categoryCreated)
            {
                throw new Exception("No se pudo crear la categoria");
            }

            //Mapear la entidad a DTO
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync(); //llama el metodo desde la capa del repositorio

            return _mapper.Map<ICollection<CategoryDto>>(categories); //mapea los datos obtenidos a DTOs

        }

        public async Task<CategoryDto> GetCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryAsync(id); //llama el metodo desde la capa del repositorio

            return _mapper.Map<CategoryDto>(category); //mapea los datos obtenidos a DTOs

        }

        public async Task<CategoryDto> UpdateCategoryAsync(int id, Category category)
        {
            throw new NotImplementedException();
        }
    }
}
