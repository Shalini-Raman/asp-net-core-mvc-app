using eMovieTickets.Data;
using eMovieTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        //Get:Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _context.GetMovieByIdAsync(id);
            return View(movieDetails);
        }

        public async  Task<IActionResult> Create()
        {
            var moviesDropDownsData = await _context.GetNewMovieDropDownsValues();

            ViewBag.Cinemas=new SelectList(moviesDropDownsData.cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(moviesDropDownsData.producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(moviesDropDownsData.actors, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var moviesDropDownsData = await _context.GetNewMovieDropDownsValues();

                ViewBag.Cinemas = new SelectList(moviesDropDownsData.cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(moviesDropDownsData.producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(moviesDropDownsData.actors, "Id", "FullName");
                return View(movie);
            }
            await _context.AddNewMovie(movie);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _context.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                ImageURL = movieDetails.ImageURL,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                MovieCategory = movieDetails.MovieCategory,
                CinemaID = movieDetails.CinemaID,
                ProducerID = movieDetails.ProducerID,
                ActorIds = movieDetails.Actors_Movies?.Select(n => n.ActorId).ToList() ?? new List<int>()
            };

            var moviesDropDownsData = await _context.GetNewMovieDropDownsValues();

            ViewBag.Cinemas = new SelectList(moviesDropDownsData.cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(moviesDropDownsData.producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(moviesDropDownsData.actors, "Id", "FullName");
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var moviesDropDownsData = await _context.GetNewMovieDropDownsValues();

                ViewBag.Cinemas = new SelectList(moviesDropDownsData.cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(moviesDropDownsData.producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(moviesDropDownsData.actors, "Id", "FullName");
                return View(movie);
            }
            await _context.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Search(string searchString)
        {
            var allMovies = await _context.GetAllAsync(n => n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", allMovies);
        }

    }
}
