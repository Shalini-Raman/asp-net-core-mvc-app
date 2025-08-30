using eMovieTickets.Data;
using eMovieTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
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
            var data =await _Service.GetAllAsync();
            return View(data);
        
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _Service.AddAsync(actor);
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Details(int id)
        {
          var actorDetails=await _Service.GetByIDAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _Service.GetByIDAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _Service.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _Service.GetByIDAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        [HttpPost , ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
           
            await _Service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
