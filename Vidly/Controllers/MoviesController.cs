using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private VidlyDbContext _context;

        public MoviesController()
        {
            _context = new VidlyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            
            return View(movies);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            /*
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new MovieFormViewModel
                    {
                        Movie = movie,
                        Genres = _context.Genres.ToList()
                    };

                    return View("MovieForm", viewModel);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }*/
            
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.GenreId= movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }   

        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        

        public ActionResult Detail(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);
            return View(movie);
        }


        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            
            /*
            return Content("Hello World!");

            return HttpNotFound();

            return new EmptyResult();

            return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });

            */
        }
    }
}