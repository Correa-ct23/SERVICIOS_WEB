
using API.J.Movies.DAL;
using API.J.Movies.DAL.Models;
using API.J.Movies.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace API.J.Movies.Repository;
public class CategoryRepository : ICategoryRepository
{

    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context) {
        _context = context;
    }

    public async Task<bool> CategoryExistsById(int id)
    {
        return await _context.categories.AsNoTracking().AnyAsync(c => c.Id == id);
    }

	public async Task<bool> CategoryExistsByName(string name)
    {
		return await _context.categories.AsNoTracking().AnyAsync(c => c.Name == name);
	}

	public async Task<bool> CreateCategoryAsync(Category categoryDto)
    {
        categoryDto.CreatedDate = DateTime.UtcNow;
        await _context.categories.AddAsync(categoryDto);
        return await SaveAsync();
	}

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var category = await _context.categories
                .FirstOrDefaultAsync(c => c.Id == id);

        if (category == null) return false;

        _context.categories.Remove(category);
        return await SaveAsync();
	}

    public async Task<ICollection<Category>> GetCategoriesAsync()
    {
        return await _context.categories.AsNoTracking().OrderBy(c => c.Name).ToListAsync();
    }

    public async Task<Category> GetCategoryAsync(int id)
    {
        return await _context.categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
	}

	public async Task<bool> UpdateCategoryAsync(Category category)
    {
		category.ModifiedDate = DateTime.UtcNow;
		_context.categories.Update(category);
        return await SaveAsync();
	}

    private async Task<bool> SaveAsync() {
		return await _context.SaveChangesAsync() >= 0 ? true : false;
	}
}