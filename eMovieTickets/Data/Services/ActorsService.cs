using eMovieTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovieTickets.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>,IActorsService
    {
        private readonly AppDBContext _context;
        public ActorsService(AppDBContext context) : base(context)
        {
        }
     
    }
}
