using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPI_Prog3.Data;
using TPI_Prog3.Models.MovieModels;

namespace TPI_Prog3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {

        private readonly MovieAPIDbContext _dbContext;
        public MoviesController(MovieAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {

            return Ok( await _dbContext.Movies.ToListAsync());
           
        }


        [HttpGet]
        [Route("{id:guid}")]

        public async Task<IActionResult> GetMovie([FromRoute] Guid id)
        {
            var movie = await _dbContext.Movies.FindAsync(id);
            if(movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }



        [HttpPost]
        public async Task<IActionResult> AddMovie(AddMovieRequest addMovieRequest)
        {
            var movie = new Movie()
            {
                Id = Guid.NewGuid(),
                Description = addMovieRequest.Description,
                Director = addMovieRequest.Director,
                Genre = addMovieRequest.Genre,
                Title = addMovieRequest.Title,
            };


           await  _dbContext.Movies.AddAsync(movie);
            await _dbContext.SaveChangesAsync();
            return Ok(movie);
        }



        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult> UpdateMovies([FromRoute] Guid id, UpdateMovieRequest updateMovieRequest)
        {
          var movie = await   _dbContext.Movies.FindAsync(id);

          if (movie != null)
            {
                movie.Title = updateMovieRequest.Title;
                movie.Director = updateMovieRequest.Director;
                movie.Description = updateMovieRequest.Description;
                movie.Genre = updateMovieRequest.Genre;

                await _dbContext.SaveChangesAsync();
                return Ok(movie);
            }
            
            return NotFound();

        }

        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteMovie([FromRoute] Guid id)
        {

            var movie = await _dbContext.Movies.FindAsync(id);

            if(movie != null)
            {
                _dbContext.Remove(movie);
                await _dbContext.SaveChangesAsync();
                return Ok("Pelicula Eliminada:" + movie);
            }

            return NotFound();
        }
    }
}
