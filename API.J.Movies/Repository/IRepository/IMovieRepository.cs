using API.J.Movies.DAL.Models;

namespace API.J.Movies.Repository.IRepository
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetMoviesAsync(); //RETORNA UNA LISTA DE PELICULAS

        Task<Movie> GetMovieAsync(int id); //RETORNA UNA PELICULA POR ID

        Task<bool> MovieExistsById(int id);

        Task<bool> MovieExistsByName(string name);

        Task<bool> CreateMovieAsync(Movie movieDto);

        Task<bool> UpdateMovieAsync(Movie movieDto);

        Task<bool> DeleteMovieAsync(int id);
    }
}
