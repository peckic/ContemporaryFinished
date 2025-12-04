using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectIzzy.Data;
using FinalProjectIzzy.Models;

namespace FinalProjectIzzy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoGamesController : ControllerBase
    {
        private readonly FinalProjectIzzyContext _context;

        public VideoGamesController(FinalProjectIzzyContext context)
        {
            _context = context;
        }


        // Get everything
        [HttpGet]
        public async Task<IActionResult> GetVideoGames()
        {
            var Games = await _context.VideoGame.ToListAsync();
            return Ok(Games);
        }


        // READ: Get by optional id
        // If id is null or 0 -> return first 5 results
        // If id has a value -> return that single game (or 404)
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDanceMoves(int id)
        {
            var videoGame = await _context.VideoGame.FindAsync(id);
            if (videoGame == null)
                return NotFound();
            return Ok(videoGame);
        }

        // CREATE
        [HttpPost]
        public async Task<ActionResult<VideoGame>> CreateVideoGame([FromBody] VideoGame videoGame)
        {
            videoGame.Id = 0;
            _context.VideoGame.Add(videoGame);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetVideoGames),
                new { id = videoGame.Id },
                videoGame
            );
        }

        // UPDATE
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateVideoGame(int id, [FromBody] VideoGame updatedGame)
        {
            if (id != updatedGame.Id)
            {
                return BadRequest("Id in URL and body must match.");
            }

            var existing = await _context.VideoGame.FindAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Title = updatedGame.Title;
            existing.Genre = updatedGame.Genre;
            existing.Platform = updatedGame.Platform;
            existing.ReleaseDate = updatedGame.ReleaseDate;
            existing.Developer = updatedGame.Developer;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteVideoGame(int id)
        {
            var existing = await _context.VideoGame.FindAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            _context.VideoGame.Remove(existing);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}