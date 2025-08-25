using eMovieTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eMovieTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDBContext _context;
        public CinemasController(AppDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.Cinemas.ToListAsync();
            return View(data);
        }
    }
}
