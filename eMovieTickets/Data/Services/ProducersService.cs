using eMovieTickets.Data.Base;
using eTickets.Models;

namespace eMovieTickets.Data.Services
{
    public class ProducersService:EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(AppDBContext context) : base(context)
        {
        }
    }
   
}
