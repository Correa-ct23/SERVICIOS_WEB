using API.J.Movies.DAL.Dtos;

namespace API.J.Movies.Services.IServices
{
    public interface ICategoryServices
    {
        Task<ICollection<CategoryDto>> GetCategoriesAsync(); //RETORNA UNA LISTA DE CATEGORIAS

        Task<CategoryDto> GetCategoryAsync(int id); //RETORNA UNA CATEGORIA POR ID

        Task<bool> CategoryExistsById(int id);

        Task<bool> CategoryExistsByName(string name);

        Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryDto);

        Task<CategoryDto> UpdateCategoryAsync(CategoryCreateDto category, int id);

        Task<bool> DeleteCategoryAsync(int id);
    }
}
