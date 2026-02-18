using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission07_Wong.Models;
using System.Linq;

namespace Mission07_Wong.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieContext _context;

        // Constructor: inject the DbContext
        public HomeController(MovieContext context)
        {
            _context = context;
        }

        // Index action: show all movies with genres
        public IActionResult Index()
        {
            var movies = _context.Movies
                                 .Include(m => m.Category)
                                 .ToList();
            return View(movies);
        }

        // Optional static page
        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        // GET: AddMovie form
        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Categories.ToList(); // Populate dropdown
            return View();
        }

        // POST: AddMovie form
        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();

                ViewBag.Message = "Movie added successfully!";
                ModelState.Clear();

                // Reload genres for dropdown
                ViewBag.Categories = _context.Categories.ToList();
                return View();
            }

            // If validation fails, reload genres and show form again
            ViewBag.Categories = _context.Categories.ToList();
            return View(movie);
        }

        public IActionResult MovieList()
        {
            var movies = _context.Movies.Include(m => m.Category).ToList();
            return View(movies);
        }

        // GET: /Home/Edit/5
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            ViewBag.Categories = _context.Categories.ToList(); // fixed casing
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Update(movie);
                _context.SaveChanges();

                // Set success message for redirect
                TempData["Message"] = "Movie updated successfully!";

                return RedirectToAction("MovieList"); // Redirect back to movie list
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(movie);
        }

        // GET: /Home/Delete/5
        public IActionResult Delete(int id)
        {
            // Load the movie including its Category
            var movie = _context.Movies
                                .Include(m => m.Category) // include related category
                                .FirstOrDefault(m => m.MovieId == id);

            if (movie == null)
            {
                return NotFound(); // 404 if movie not found
            }

            return View(movie); // return Delete.cshtml
        }


        // POST: /Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();

                // Set success message for redirect
                TempData["Message"] = "Movie deleted successfully!";
            }

            return RedirectToAction("MovieList"); // go back to movie list
        }





    }
}
