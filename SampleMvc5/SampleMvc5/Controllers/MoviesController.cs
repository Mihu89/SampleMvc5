using SampleMvc5.Models;
using SampleMvc5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvc5.Controllers
{
    [Authorize(Roles ="Admin, manager")] // or
    /* USE WHEN BOTH ROLES ARE NEEDED
    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "manager")] */
    public class MoviesController : Controller
    {
        public ViewResult Index()
        {
            //var movies = GetMovies();
            //return View(movies);
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View();
            }
            return View("ReadonlyList");
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie(){ Id = 1, Name="Matrix 4"},
                new Movie(){ Id = 2, Name="Iran Man 4"},
                new Movie(){ Id = 3, Name="Black Widow"},
            };
        }

        [AllowAnonymous]
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Iron Man - 4" };

            var customers = new List<Customer>
            {
                new Customer{Name = "John Rambo"},
                new Customer{Name = "Robert Downey" }
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        [Authorize(Roles =RoleName.CanManageMovies)]
        public ViewResult New()
        {
            //var genres = _
            return View();
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult Edit(int id)
        {
            //var genres = _
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {

            }
            return View();
        }
    }
}