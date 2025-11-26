using API.J.Movies.DAL.Dtos;
using API.J.Movies.DAL.Models;
using API.J.Movies.Repository;
using API.J.Movies.Repository.IRepository;
using API.J.Movies.Services.IServices;
using AutoMapper;

namespace API.J.Movies.Services
{
    public class CategoryService : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository,  IMapper mapper) { 
           _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        Task<bool> ICategoryServices.CategoryExistsById(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICategoryServices.CategoryExistsByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryDto)
        {
            var categoryExists = await _categoryRepository.CategoryExistsByName(categoryDto.Name);

            if (categoryExists)
            {
                throw new InvalidOperationException("Ya existe una categoria con ese nombre");
            }

            var category = _mapper.Map<Category>(categoryDto);

            var categoryCreated = await _categoryRepository.CreateCategoryAsync(category);

            if (!categoryCreated) {
                throw new Exception("Ocurrio un error al crear la categoria.");
            }

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            await GetCategoryAsync(id);

            var isDeleted = await _categoryRepository.DeleteCategoryAsync(id);

            if (!isDeleted)
            {
                throw new Exception("Ocurrió un error al eliminar la categoría.");
            }

            return isDeleted;
        }

        public async Task<ICollection<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<ICollection<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryAsync(id);
            return _mapper.Map<CategoryDto>(category);

        }

        public async Task<CategoryDto> UpdateCategoryAsync(CategoryCreateDto category, int id)
        {
            //Verificar si la categoría existe
            var existingCategory = await GetCategoryAsync(id);

            var nameExists = await _categoryRepository.CategoryExistsByName(category.Name);
            if (nameExists)
            {
                throw new InvalidOperationException($"Ya existe una categoría con el nombre de '{category.Name}'");
            }

            //Mapear los cambios del DTO a la entidad existente Category
            _mapper.Map(category, existingCategory);

            //Actualizar la categoría en el repositorio
            var isUpdated = await _categoryRepository.UpdateCategoryAsync(existingCategory);

            if (!isUpdated)
            {
                throw new Exception("Ocurrió un error al actualizar la categoría.");
            }

            //retornar el CategoryDto actualizado
            return _mapper.Map<CategoryDto>(existingCategory);
        }
    }
}
