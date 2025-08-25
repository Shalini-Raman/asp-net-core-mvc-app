using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovieTickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDBContext _context;
        public ActorsService(AppDBContext context)
        {
            _context = context;
        }
        public void Add(Actor actor)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var result = await _context.Actors.ToListAsync(); return result;
        }

        public Actor GetByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public Actor Update(int id, Actor actor)
        {
            throw new System.NotImplementedException();
        }
    }
}
