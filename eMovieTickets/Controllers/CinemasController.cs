using eMovieTickets.Data;
using eMovieTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eMovieTickets.Controllers
{
    [Authorize]
    public class CinemasController : Controller
    {
        private readonly ICinemasService _context;
        public CinemasController(ICinemasService context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _context.GetAllAsync();
            return View(data);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                await _context.AddAsync(cinema);
                return RedirectToAction(nameof(Index));
            }
            return View(cinema);

        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var cinema=await _context.GetByIDAsync(id);
            if (cinema == null) return View("NotFound");
            return View(cinema);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _context.GetByIDAsync(id);
            if (cinema == null) return View("NotFound");
            return View(cinema);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                await _context.UpdateAsync(id, cinema);
                return RedirectToAction(nameof(Index));
            }
            return View(cinema);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var cinema = await _context.GetByIDAsync(id);
            if (cinema == null) return View("NotFound");
            return View(cinema);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinema = await _context.GetByIDAsync(id);
            if (cinema == null) return View("NotFound");
            await _context.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
