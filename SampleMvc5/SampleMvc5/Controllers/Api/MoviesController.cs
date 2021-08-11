using SampleMvc5.Dtos;
using SampleMvc5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SampleMvc5.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: Movies
        public IEnumerable<MovieDto> GetMovies()
        {
            var movies = _dbContext.Movies.ToList().Select(x => new MovieDto
            {
                Id = x.Id,
                Name = x.Name,
                // all
            });
            return movies;
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(new MovieDto() { Id = movie.Id, Name = movie.Name });
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = new Movie { Id = movieDto.Id };
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var existingMovie = _dbContext.Movies.FirstOrDefault(x => x.Id == id);
            if (existingMovie == null)
            {
                return NotFound();
            }
            // use Mapper
            existingMovie.Id = movieDto.Id;
            _dbContext.SaveChanges();

            return Ok();
        }


        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var existingMovie = _dbContext.Movies.FirstOrDefault(x => x.Id == id);
            if (existingMovie == null)
            {
                return NotFound();
            }

            _dbContext.Movies.Remove(existingMovie);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}