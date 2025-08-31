using eMovieTickets.Data;
using eMovieTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eMovieTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _context;
        public MoviesController(IMoviesService context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.GetAllAsync(n=> n.Cinema);
            return View(data);
        }
    }
}
