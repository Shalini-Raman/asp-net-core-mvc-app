using eMovieTickets.Data.Base;
using eTickets.Models;

namespace eMovieTickets.Data.Services
{
    public class MoviesService: EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDBContext _context;
        public MoviesService(AppDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
