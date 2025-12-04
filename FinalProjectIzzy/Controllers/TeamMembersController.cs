using FinalProjectIzzy.Data;
using FinalProjectIzzy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace FinalProjectIzzy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamMembersController : ControllerBase
    {
        private readonly FinalProjectIzzyContext _db;

        public TeamMembersController(FinalProjectIzzyContext db)
        {
            _db = db;
        }

        // GET: api/TeamMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamMembers>>> GetAll()
        {
            return await _db.TeamMembers.ToListAsync();
        }

        // GET: api/TeamMembers/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TeamMembers>> Get(int id)
        {
            var tm = await _db.TeamMembers.FindAsync(id);
            if (tm == null) return NotFound();
            return Ok(tm);
        }

        // POST: api/TeamMembers
        [HttpPost]
        public async Task<ActionResult<TeamMembers>> Create([FromBody] TeamMembers teamMember)
        {
            teamMember.MemberId = 0;
            _db.TeamMembers.Add(teamMember);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = teamMember.MemberId }, teamMember);
        }

        // PUT: api/TeamMembers/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, TeamMembers teamMember)
        {
            if (id != teamMember.MemberId) return BadRequest();

            var existing = await _db.TeamMembers.FindAsync(id);
            if (existing == null) return NotFound();

            existing.MemberName = teamMember.MemberName;
            existing.BirthDate = teamMember.BirthDate;
            existing.CollegeProgram = teamMember.CollegeProgram;
            existing.YearInProgram = teamMember.YearInProgram;

            await _db.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/TeamMembers/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _db.TeamMembers.FindAsync(id);
            if (existing == null) return NotFound();

            _db.TeamMembers.Remove(existing);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}