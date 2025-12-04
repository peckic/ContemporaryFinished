using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectIzzy.Data;
using FinalProjectIzzy.Models;

namespace FinalProjectIzzy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanceMovesController : ControllerBase
    {
        private readonly FinalProjectIzzyContext _context;

        public DanceMovesController(FinalProjectIzzyContext context)
        {
            _context = context;
        }

        // GET: api/DanceMoves
        // READ operation - Get all Dance Moves
        [HttpGet]
        public async Task<IActionResult> GetDanceMoves()
        {
            var Dances = await _context.DanceMoves.ToListAsync();
            return Ok(Dances);
        }

        // GET: api/DanceMoves/5
        // READ operation - Get Dance Move by ID
        [HttpGet("{moveid:int}")]
        public async Task<IActionResult> GetDanceMoves(int moveid)
        {
            var danceMoves = await _context.DanceMoves.FindAsync(moveid);
            if (danceMoves == null)
                return NotFound();
            return Ok(danceMoves);
        }

        // POST: api/DanceMoves
        // CREATE operation - Add a new Dance Move
        [HttpPost]
        public async Task<IActionResult> PostDanceMoves([FromBody] DanceMoves danceMoves)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Ensure we don't try to insert a conflicting primary key (use DB identity)
            danceMoves.MoveId = 0;

            _context.DanceMoves.Add(danceMoves);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                // Return a Problem response during development so you can see the error.
                // In production, log dbEx and return a generic error.
                return Problem(detail: dbEx.InnerException?.Message ?? dbEx.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }

            // assumes Id is the key
            return CreatedAtAction(nameof(GetDanceMoves), new { moveid = danceMoves.MoveId }, danceMoves);
        }

        // DELETE: api/DanceMoves/5
        // DELETE operation - Delete Dance Move by ID
        [HttpDelete("{moveid:int}")]
        public async Task<IActionResult> DeleteDanceMoves(int moveid)
        {
            var danceMoves = await _context.DanceMoves.FindAsync(moveid);
            if (danceMoves == null)
                return NotFound();

            _context.DanceMoves.Remove(danceMoves);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/DanceMoves/5
        // UPDATE operation - Update Dance Move by ID
        [HttpPut("{moveid:int}")]
        public async Task<IActionResult> PutDanceMoves(int moveid, [FromBody] DanceMoves danceMoves)
        {
            if (moveid != danceMoves.MoveId)
                return BadRequest();

            _context.Entry(danceMoves).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.DanceMoves.Any(e => e.MoveId == moveid))
                    return NotFound();
                throw;
            }

            return NoContent();
        }
    }
}
