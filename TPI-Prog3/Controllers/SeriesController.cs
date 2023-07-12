using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPI_Prog3.Data;
using TPI_Prog3.Models.SerieModels;

namespace TPI_Prog3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeriesController : Controller
    {

        private readonly MovieAPIDbContext _dbContext;
        public SeriesController(MovieAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        [HttpGet]
        public async Task<IActionResult> GetSeries()
        {

            return Ok(await _dbContext.Series.ToListAsync());

        }


        [HttpGet]
        [Route("{id:guid}")]

        public async Task<IActionResult> GetSerie([FromRoute] Guid id)
        {
            var serie = await _dbContext.Series.FindAsync(id);
            if (serie == null)
            {
                return NotFound();
            }

            return Ok(serie);
        }



        [HttpPost]
        public async Task<IActionResult> AddSerie(AddSerieRequest addSerieRequest)
        {
            var serie = new Serie()
            {
                Id = Guid.NewGuid(),
                Description = addSerieRequest.Description,
                Name = addSerieRequest.Name,
                Genre = addSerieRequest.Genre,
                Seasons = addSerieRequest.Seasons,
            };


            await _dbContext.Series.AddAsync(serie);
            await _dbContext.SaveChangesAsync();
            return Ok(serie);
        }



        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult> UpdateSerie([FromRoute] Guid id, UpdateSerieRequest updateSerieRequest)
        {
            var serie = await _dbContext.Series.FindAsync(id);

            if (serie != null)
            {

                serie.Name = updateSerieRequest.Name;
                serie.Description = updateSerieRequest.Description;
                serie.Genre = updateSerieRequest.Genre;
                serie.Seasons = updateSerieRequest.Seasons;
                

                await _dbContext.SaveChangesAsync();
                return Ok(serie);
            }

            return NotFound();

        }

        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteSerie([FromRoute] Guid id)
        {

            var serie = await _dbContext.Series.FindAsync(id);

            if (serie != null)
            {
                _dbContext.Remove(serie);
                await _dbContext.SaveChangesAsync();
                return Ok("Serie Eliminada" + serie);
            }

            return NotFound();
        }
    }
}
