using API.J.Movies.DAL;
using API.J.Movies.DAL.Models;
using API.J.Movies.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace API.J.Movies.Repository
{
    public class MovieRepository :  IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> MovieExistsById(int id)
        {
            return await _context.movies.AsNoTracking().AnyAsync(m => m.Id == id);
        }

        public async Task<bool> MovieExistsByName(string name)
        {
            return await _context.movies.AsNoTracking().AnyAsync(m => m.Name == name);
        }

        public async Task<bool> CreateMovieAsync(Movie movieDto)
        {
            movieDto.CreatedDate = DateTime.UtcNow;
            await _context.movies.AddAsync(movieDto);
            return await SaveAsync();
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await _context.movies
                    .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null) return false;

            _context.movies.Remove(movie);
            return await SaveAsync();
        }

        public async Task<ICollection<Movie>> GetMoviesAsync()
        {
            return await _context.movies.AsNoTracking().OrderBy(m => m.Name).ToListAsync();
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            return await _context.movies.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            movie.ModifiedDate = DateTime.UtcNow;
            _context.movies.Update(movie);
            return await SaveAsync();
        }

        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
