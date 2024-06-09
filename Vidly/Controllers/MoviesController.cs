using System;
using System.Data.Entity;
using System.Collections.Generic;
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