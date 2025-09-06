using eMovieTickets.Data.Base;
using eMovieTickets.Data.ViewModel;
using eTickets.Models;
using System.Threading.Tasks;

namespace eMovieTickets.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropDownsVM> GetNewMovieDropDownsValues();
        Task AddNewMovie(NewMovieVM data);

        Task UpdateMovieAsync(NewMovieVM newMovie);
    }
}
