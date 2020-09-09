using System;
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
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            //movie.Name = "other";

            var customers = new List<Customer>
            {
                new Customer { Name="Customer1"}, new Customer { Name="Customer2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //return Content("Hello");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("index", "home");
        }

        public ActionResult Edit(int id)
        {
            //http://localhost:57812/movies/edit?id=1
            return Content("Movie id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            //http://localhost:57812/movies/index
            if (!pageIndex.HasValue )
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

        }


        public ActionResult ByReleaseDate(int year, int month)
        {
            // http://localhost:57812/movies/released/2019/04
            return Content("year=" + year + ", month=" + month);
        }

        //[Route("movies/released/{year}/{month:regex(\\d{4}:range(1, 12)}")]
        [Route("movies/released/{year}/{month:range(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            // http://localhost:57812/movies/released/2019/04
            return Content("year=" + year + ", month=" + month);
        }

    }
}