using API.W.Movies.DAL.Models;
using API.W.Movies.DAL.Models.Dtos;
using API.W.Movies.Repository;
using API.W.Movies.Services.IServices;
using AutoMapper;

namespace API.W.Movies.Services.IServices
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<bool> MovieExistByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> MovieExistByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto movieCreateDto)
        {
            //Validar si la película existe
            var movieExist = await _movieRepository.MovieExistByNameAsync(movieCreateDto.Name);
            if (movieExist)
            {
                throw new InvalidOperationException($"Ya existe una película con el nombre '{movieCreateDto.Name}'");
            }

            //Mapear el DTO a la entidad
            var movie = _mapper.Map<Movie>(movieCreateDto);

            //Crear la película en el repositorio
            var movieCreated = await _movieRepository.CreateMovieAsync(movie);

            if (!movieCreated)
            {
                throw new Exception("No se pudo crear la película");
            }

            //Mapear la entidad a DTO
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            //Verificar si la película existe
            var movieExists = await _movieRepository.GetMovieAsync(id);

            if (movieExists == null)
            {
                throw new InvalidOperationException($"No se encontró una película con el id '{id}'");
            }

            //Eliminar la película del repositorio
            var movieDeleted = await _movieRepository.DeleteMovieAsync(id);

            if (!movieDeleted)
            {
                throw new Exception("No se pudo eliminar la película");
            }

            return movieDeleted;
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync(); //llama el metodo desde la capa del repositorio

            return _mapper.Map<ICollection<MovieDto>>(movies); //mapea los datos obtenidos a DTOs
        }

        public async Task<MovieDto> GetMovieAsync(int id)
        {
            var movie = await _movieRepository.GetMovieAsync(id); //llama el metodo desde la capa del repositorio

            if (movie == null)
            {
                throw new InvalidOperationException($"No se encontró una película con el id '{id}'");
            }

            return _mapper.Map<MovieDto>(movie); //mapea los datos obtenidos a DTOs
        }

        public async Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto dto, int id)
        {
            //Validar si la película existe
            var movieExists = await _movieRepository.GetMovieAsync(id);

            if (movieExists == null)
            {
                throw new InvalidOperationException($"No se encontró una película con el id '{id}'");
            }

            var nameExist = await _movieRepository.MovieExistByNameAsync(dto.Name);

            if (nameExist)
            {
                throw new InvalidOperationException($"Ya existe una película con el nombre '{dto.Name}'");
            }

            //Mapear el DTO a la entidad
            _mapper.Map(dto, movieExists);

            //Actualizamos la película en el repositorio
            var movieUpdated = await _movieRepository.UpdateMovieAsync(movieExists);

            if (!movieUpdated)
            {
                throw new Exception("No se pudo actualizar la película");
            }

            //Retornar el dto actualizado
            return _mapper.Map<MovieDto>(movieExists);
        }
    }
}