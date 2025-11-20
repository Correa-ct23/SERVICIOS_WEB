using API.J.Movies.DAL.Dtos;
using API.J.Movies.DAL.Models;

namespace API.J.Movies.Repository.IRepository;
public interface ICategoryRepository
{
	Task<ICollection<Category>> GetCategoriesAsync(); //RETORNA UNA LISTA DE CATEGORIAS

	Task<Category> GetCategoryAsync(int id); //RETORNA UNA CATEGORIA POR ID

	Task<bool> CategoryExistsById(int id); 

	Task<bool> CategoryExistsByName(string name);

    Task<bool> CreateCategoryAsync(Category categoryDto);

    Task<bool> UpdateCategoryAsync(Category categoryDto);

    Task<bool> DeleteCategoryAsync(int id);

}
