using Microsoft.AspNetCore.Mvc;
using MoviesManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoviesManager.Controllers
{
    public class MoviesController : Controller
    {
        // In-memory movie list (no database)
        private static List<Movie> movies = new List<Movie>
        {
            new Movie { Id = 1, Title = "Inception", Director = "Christopher Nolan", Genre = "Sci-Fi", Year = 2010, Rating = 9.0 },
            new Movie { Id = 2, Title = "Gladiator", Director = "Ridley Scott", Genre = "Action", Year = 2000, Rating = 8.5 },
            new Movie { Id = 3, Title = "The Dark Knight", Director = "Christopher Nolan", Genre = "Action", Year = 2008, Rating = 9.1 },
            new Movie { Id = 4, Title = "Interstellar", Director = "Christopher Nolan", Genre = "Sci-Fi", Year = 2014, Rating = 8.6 },
            new Movie { Id = 5, Title = "The Intouchables", Director = "Olivier Nakache", Genre = "Drama", Year = 2011, Rating = 8.5 }
        };

        // READ – Display list
        public IActionResult Index()
        {
            return View(movies);
        }

        // CREATE – Show form
        public IActionResult Create()
        {
            return View();
        }

        // CREATE – Save new movie
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            movie.Id = movies.Max(m => m.Id) + 1;
            movies.Add(movie);
            return RedirectToAction("Index");
        }

        // EDIT – Show existing
        public IActionResult Edit(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            return View(movie);
        }

        // EDIT – Update movie
        [HttpPost]
        public IActionResult Edit(Movie updatedMovie)
        {
            var movie = movies.FirstOrDefault(m => m.Id == updatedMovie.Id);
            if (movie != null)
            {
                movie.Title = updatedMovie.Title;
                movie.Director = updatedMovie.Director;
                movie.Genre = updatedMovie.Genre;
                movie.Year = updatedMovie.Year;
                movie.Rating = updatedMovie.Rating;
            }
            return RedirectToAction("Index");
        }

        // DELETE – Confirm page
        public IActionResult Delete(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            return View(movie);
        }

        // DELETE – Remove movie
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                movies.Remove(movie);
            }
            return RedirectToAction("Index");
        }
    }
}
