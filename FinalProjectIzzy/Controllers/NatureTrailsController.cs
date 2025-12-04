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
    public class NatureTrailController : ControllerBase
    {
        private readonly FinalProjectIzzyContext _context;

        public NatureTrailController(FinalProjectIzzyContext context)
        {
            _context = context;
        }

        // GET: api/NatureTrail
        // READ operation - Get all Nature Trails
        [HttpGet]
        public async Task<IActionResult> GetNatureTrails()
        {
            var trails = await _context.NatureTrail.ToListAsync();
            return Ok(trails);
        }

        // GET: api/NatureTrail/5
        // READ operation - Get Nature Trail by ID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetNatureTrail(int id)
        {
            var natureTrail = await _context.NatureTrail.FindAsync(id);
            if (natureTrail == null)
                return NotFound();
            return Ok(natureTrail);
        }

        // POST: api/NatureTrail
        // CREATE operation - Add a new Nature Trail
        [HttpPost]
        public async Task<IActionResult> PostNatureTrail([FromBody] NatureTrail natureTrail)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Ensure we don't try to insert a conflicting primary key (use DB identity)
            natureTrail.Id = 0;

            _context.NatureTrail.Add(natureTrail);

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
            return CreatedAtAction(nameof(GetNatureTrail), new { id = natureTrail.Id }, natureTrail);
        }

        // DELETE: api/NatureTrail/5
        // DELETE operation - Delete Nature Trail by ID
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteNatureTrail(int id)
        {
            var natureTrail = await _context.NatureTrail.FindAsync(id);
            if (natureTrail == null)
                return NotFound();

            _context.NatureTrail.Remove(natureTrail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/NatureTrail/5
        // UPDATE operation - Update Nature Trail by ID
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutNatureTrail(int id, [FromBody] NatureTrail natureTrail)
        {
            if (id != natureTrail.Id)
                return BadRequest();

            _context.Entry(natureTrail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.NatureTrail.Any(e => e.Id == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }
    }
}
