using eMovieTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eMovieTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDBContext _Context;
        public ProducersController(AppDBContext context)
        {
            _Context = context;
        }
        //Synchronous
        //public IActionResult Index()
        //{
        //    var data = _Context.Producers.ToList();
        //    return View();
        //}
        //ASynchronous
        public async Task<IActionResult> Index()
        {
            var data =await _Context.Producers.ToListAsync();
            return View();
        }
    }
}
