using eMovieTickets.Data;
using eMovieTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace eMovieTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _Service;
        public ActorsController(IActorsService Service)
        {
            _Service = Service;
        }
        public async Task<IActionResult> Index()
        {
            var data =await _Service.GetAll();
            return View(data);
        
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
