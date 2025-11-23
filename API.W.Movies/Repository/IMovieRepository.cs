using API.W.Movies.DAL.Models;

namespace API.W.Movies.Repository
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetMoviesAsync(); //Retorna una lista de las películas
        Task<Movie> GetMovieAsync(int id); //Retorna una película por su Id
        Task<bool> MovieExistByIdAsync(int id); //Verifica si una película existe por su Id
        Task<bool> MovieExistByNameAsync(string name); //Verifica si una película existe por su Nombre
        Task<bool> CreateMovieAsync(Movie movie); //Crea una nueva película
        Task<bool> UpdateMovieAsync(Movie movie); //Actualiza una película existente
        Task<bool> DeleteMovieAsync(int id); //Elimina una película
    }
}