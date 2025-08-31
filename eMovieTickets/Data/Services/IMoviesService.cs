using eMovieTickets.Data.Base;
using eTickets.Models;

namespace eMovieTickets.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
    }
}
