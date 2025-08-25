using eTickets.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMovieTickets.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAll();

        Actor GetByID(int id);
        void Add(Actor actor);
        Actor Update(int id, Actor actor);

        void Delete(int id);
    }
}
