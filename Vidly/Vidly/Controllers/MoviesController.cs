using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Razor;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            
            var movie  = new Movies() { Name = "Black Panther"};

            var customers = new List<Customer>
            {
                new Customer { Name =  "Ivan"},
                new Customer { Name =  "Irina"}
            };

            //we created the RandomViewModel so that we can pass two or more domain models to one view
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //ActioResult is the prefered run type, so that we can return any of its subtypes; ViewResult, PartialViewResult, ContentResult, RedirectResult, FileResult, HttpNotFoundResult

            return View(viewModel);

            //return View(movie);

            //return Content("Hi Ivan");

            //return HttpNotFound();

            //return RedirectToAction("Index", "Home");

        }
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        //movies
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")] //Attribute route maintained with contraints on parameters
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrEmpty(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={0}", pageIndex));

        }

        public IEnumerable<Movies> GetMovies()
        {
            return new List<Movies>
            {
                new Movies {id = 1, Name = "Black Panther"},
                new Movies {id = 2, Name = "Infinity War"} 
            };
        }
    }
}