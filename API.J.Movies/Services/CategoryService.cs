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

        Task<bool> ICategoryServices.CreateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
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

        public Task<CategoryDto> GetCategoriesAsync(int id)
        {
            throw new NotImplementedException();
 
        }

        Task<bool> ICategoryServices.UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
