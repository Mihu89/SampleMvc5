using SampleMvc5.Models;
using SampleMvc5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvc5.Controllers
{
    public class MoviesController : Controller
    {
        public ViewResult Index()
        {
            var movies = GetMovies();
            return View(movies);
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
    }
}