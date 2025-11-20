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

        async Task<CategoryDto> ICategoryServices.CreateCategoryAsync(CategoryCreateDto categoryDto)
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

        Task<bool> ICategoryServices.DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
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

        Task<CategoryDto> ICategoryServices.UpdateCategoryAsync(int id, Category category)
        {
            throw new NotImplementedException();
        }
    }
}
