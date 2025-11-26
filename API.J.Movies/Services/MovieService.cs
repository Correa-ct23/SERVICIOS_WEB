using API.J.Movies.DAL.Dtos;
using API.J.Movies.DAL.Models;
using API.J.Movies.Repository.IRepository;
using API.J.Movies.Services.IServices;
using AutoMapper;

namespace API.J.Movies.Services
{
    public class MovieService : IMovieServices
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        Task<bool> IMovieServices.MovieExistsById(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IMovieServices.MovieExistsByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieDto> CreateMovieAsync(MovieCreateDto movieDto)
        {
            var MovieExists = await _movieRepository.MovieExistsByName(movieDto.Name);

            if (MovieExists)
            {
                throw new InvalidOperationException("Ya existe una pelicula con ese nombre");
            }

            var movie = _mapper.Map<Movie>(movieDto);

            var MovieCreated = await _movieRepository.CreateMovieAsync(movie);

            if (!MovieCreated)
            {
                throw new Exception("Ocurrio un error al crear la pelicula.");
            }

            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            await GetMovieByIdAsync(id);

            var isDeleted = await _movieRepository.DeleteMovieAsync(id);

            if (!isDeleted)
            {
                throw new Exception("Ocurrió un error al eliminar la pelicula.");
            }

            return isDeleted;
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();
            return _mapper.Map<ICollection<MovieDto>>(movies);
        }

        public async Task<MovieDto> GetMovieAsync(int id)
        {
            var movie = await GetMovieByIdAsync(id);

            return _mapper.Map<MovieDto>(movie);

        }

        public async Task<MovieDto> UpdateMovieAsync(MovieCreateDto movie, int id)
        {
            //Verificar si la pelicula existe
            var existingMovie = await GetMovieByIdAsync(id);

            var nameExists = await _movieRepository.MovieExistsByName(movie.Name);
            if (nameExists)
            {
                throw new InvalidOperationException($"Ya existe una pelicula con el nombre de '{movie.Name}'");
            }

            //Mapear los cambios del DTO a la entidad existente Movie
            _mapper.Map(movie, existingMovie);

            //Actualizar la pelicula en el repositorio
            var isUpdated = await _movieRepository.UpdateMovieAsync(existingMovie);

            if (!isUpdated)
            {
                throw new Exception("Ocurrió un error al actualizar la pelicula.");
            }

            //retornar el MovieDto actualizado
            return _mapper.Map<MovieDto>(existingMovie);
        }

        private async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetMovieAsync(id);

            if (movie == null)
            {
                throw new InvalidOperationException($"No se encontró la pelicula con ID: '{id}'");
            }

            return movie;
        }
    }
}
