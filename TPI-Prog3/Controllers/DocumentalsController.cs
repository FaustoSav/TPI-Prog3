using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPI_Prog3.Data;
using TPI_Prog3.Models.DocumentalModels;


namespace TPI_Prog3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentalsController : Controller
    {
        

        private readonly MovieAPIDbContext _dbContext;
        public DocumentalsController (MovieAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        [HttpGet]
        public async Task<IActionResult> GetDocumentals()
        {

            return Ok(await _dbContext.Documentals.ToListAsync());

        }


        [HttpGet]
        [Route("{id:guid}")]

        public async Task<IActionResult> GetDocumental([FromRoute] Guid id)
        {
            var documental = await _dbContext.Documentals.FindAsync(id);
            if (documental == null)
            {
                return NotFound();
            }

            return Ok(documental);
        }



        [HttpPost]
        public async Task<IActionResult> AddDocumental(AddDocumentalRequest addDocumentalRequest)
        {
            var documental = new Documental()
            {
                Id = Guid.NewGuid(),
                Description = addDocumentalRequest.Description,
                Title = addDocumentalRequest.Title,
                Duration = addDocumentalRequest.Duration,
                Director = addDocumentalRequest.Director,
            };


            await _dbContext.Documentals.AddAsync(documental);
            await _dbContext.SaveChangesAsync();
            return Ok(documental);
        }



        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult> UpdateDocumental([FromRoute] Guid id, UpdateDocumentalRequest updateDocumentalRequest)
        {
            var documental = await _dbContext.Documentals.FindAsync(id);

            if (documental != null)
            {

                documental.Title = updateDocumentalRequest.Title;
                documental.Description = updateDocumentalRequest.Description;
                documental.Director = updateDocumentalRequest.Director;
                documental.Duration = updateDocumentalRequest.Duration;


                await _dbContext.SaveChangesAsync();
                return Ok(documental);
            }

            return NotFound();

        }

        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteDocumental([FromRoute] Guid id)
        {

            var documental = await _dbContext.Documentals.FindAsync(id);

            if (documental != null)
            {
                _dbContext.Remove(documental);
                await _dbContext.SaveChangesAsync();
                return Ok("Documental Eliminado:" + documental);
            }

            return NotFound();
        }
    }
}
