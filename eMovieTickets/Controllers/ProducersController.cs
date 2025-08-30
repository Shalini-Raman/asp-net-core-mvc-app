using eMovieTickets.Data;
using eMovieTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eMovieTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _Service;
        public ProducersController(IProducersService service)
        {
            _Service = service;
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
            var data =await _Service.GetAllAsync();
            return View(data);
        }
        public async Task<IActionResult> Details(int id)
        {
            var data = await _Service.GetByIDAsync(id);
            if (data == null) return View("NotFound");
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>  Create([Bind("FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _Service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var ProducerDetails = await _Service.GetByIDAsync(id);
            if (ProducerDetails == null) return View("NotFound");
            return View(ProducerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _Service.UpdateAsync(id, producer);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            var ProducerDetails = await _Service.GetByIDAsync(id);
            if (ProducerDetails == null) return View("NotFound");
            return View(ProducerDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Producer producer)
        {

            await _Service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
