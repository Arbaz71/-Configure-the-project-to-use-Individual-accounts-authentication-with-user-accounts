using Azure.Core;
using CodingExercise.Data;
using CodingExercise.Dto;
using CodingExercise.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PresentationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Presentations>>> GetPresentations()
        {
            return await _context.Presentation.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Presentations>> AddPresentation(PresentationDto presentation)
        {
            Presentations presentationsObj = new Presentations
            {
                Title = presentation.Title,
                PresenterName = presentation.PresenterName,
                Duration = presentation.Duration,
                IsDeleted = false
            };
            _context.Presentation.Add(presentationsObj);
            await _context.SaveChangesAsync();
            return Ok(presentation);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePresentation(Presentations presentation)
        {
            if (presentation.Id != 0)
            {
                return BadRequest();
            }
            var presentationObj = await _context.Presentation.FirstOrDefaultAsync(x=>x.Id== presentation.Id);
            
            if (presentationObj != null)
            {
                presentationObj.Title = presentation.Title;
                presentationObj.PresenterName = presentation.PresenterName;
                presentationObj.Duration = presentation.Duration;
                 _context.Update(presentation);
                await _context.SaveChangesAsync(); 

                return Ok(presentation);

            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePresentation(int id)
        {
            var item = await _context.Presentation.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            item.IsDeleted = true;
            _context.Update(item);
            await _context.SaveChangesAsync();

            return Ok("Deleted");
        }
    }
}
