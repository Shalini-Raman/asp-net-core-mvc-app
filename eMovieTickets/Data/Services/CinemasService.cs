using eMovieTickets.Data.Base;
using eTickets.Models;

namespace eMovieTickets.Data.Services
{
    public class CinemasService :  EntityBaseRepository<Cinema>, ICinemasService
    {
        private readonly AppDBContext _context;
        public CinemasService(AppDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
