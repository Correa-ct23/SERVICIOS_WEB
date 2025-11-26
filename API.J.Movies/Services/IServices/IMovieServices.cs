using API.J.Movies.DAL.Dtos;

namespace API.J.Movies.Services.IServices
{
    public interface IMovieServices
    {
        Task<ICollection<MovieDto>> GetMoviesAsync(); //RETORNA UNA LISTA DE PELICULAS

        Task<MovieDto> GetMovieAsync(int id); //RETORNA UNA PELICULA POR ID

        Task<bool> MovieExistsById(int id);

        Task<bool> MovieExistsByName(string name);

        Task<MovieDto> CreateMovieAsync(MovieCreateDto movieDto);

        Task<MovieDto> UpdateMovieAsync(MovieCreateDto movie, int id);

        Task<bool> DeleteMovieAsync(int id);
    }
}
