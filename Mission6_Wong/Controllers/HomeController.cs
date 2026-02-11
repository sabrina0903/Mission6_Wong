using Microsoft.AspNetCore.Mvc;
using Mission6_Wong.Models;

namespace Mission6_Wong.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieContext _context;

        public HomeController(MovieContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            // Optionally, show a list of movies
            var movies = _context.Movies.ToList();
            return View(movies);
        }

            public IActionResult GetToKnowJoel()
            {
                return View();
            }

        [HttpGet]
        public IActionResult AddMovie()
        {
            // Display the form
            return View();
        }
        [HttpPost]
        public IActionResult AddMovie(Movies movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();

                // Set a message to show in the view
                ViewBag.Message = "Movie added successfully!";

                // Optionally, clear the form
                ModelState.Clear();
                return View();
            }

            // If validation fails, show the form again
            return View(movie);
        }
    }
}