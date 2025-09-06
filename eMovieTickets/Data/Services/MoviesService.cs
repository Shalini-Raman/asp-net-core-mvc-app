using eMovieTickets.Data.Base;
using eMovieTickets.Data.ViewModel;
using eMovieTickets.Models;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eMovieTickets.Data.Services
{
    public class MoviesService: EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDBContext _context;
        public MoviesService(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovie(NewMovieVM data)
        {
            var newMovie=new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategory = data.MovieCategory,
                CinemaID = data.CinemaID,
                ProducerID = data.ProducerID
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();


            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actors_Movies()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails= _context.Movies
                .Include(C => C.Cinema)
                .Include(P => P.Producer)
                .Include(am=> am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return await movieDetails;
        }

        public async Task<NewMovieDropDownsVM> GetNewMovieDropDownsValues()
        {
            var response = new NewMovieDropDownsVM()
            {
                actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public  async Task UpdateMovieAsync(NewMovieVM newMovie)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == newMovie.Id);
            if (dbMovie != null)
            {
                dbMovie.Name = newMovie.Name;
                dbMovie.Description = newMovie.Description;
                dbMovie.Price = newMovie.Price;
                dbMovie.ImageURL = newMovie.ImageURL;
                dbMovie.StartDate = newMovie.StartDate;
                dbMovie.EndDate = newMovie.EndDate;
                dbMovie.MovieCategory = newMovie.MovieCategory;
                dbMovie.CinemaID = newMovie.CinemaID;
                dbMovie.ProducerID = newMovie.ProducerID;
                await _context.SaveChangesAsync();
            }
            //Remove existing actors
            var existingActorsDb = _context.Actors_Movies.Where(n => n.MovieId == newMovie.Id).ToList();
            _context.Actors_Movies.RemoveRange(existingActorsDb);

            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in newMovie.ActorIds)
            {
                var newActorMovie = new Actors_Movies()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            _context.SaveChanges();

        }
    }
}
