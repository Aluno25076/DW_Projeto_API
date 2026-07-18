using DW_Projeto_API.Data;
using DW_Projeto_API.Models;
using DW_Projeto_API.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DW_Projeto_API.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Matches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchDTO>>> GetMatches()
        {
            /* pesquisa com relacionamentos, como no PhotosController do professor:
             * SELECT m.*, f.Name, e.Name
             * FROM Matches m INNER JOIN Fields f ON m.FieldFK = f.Id
             *                LEFT JOIN Employees e ON m.EmployeeFK = e.Id
             */
            return await _context.Matches
                                 .Select(m => new MatchDTO
                                 {
                                     Id = m.Id,
                                     MatchDate = m.MatchDate,
                                     DurationMinutes = m.DurationMinutes,
                                     Field = m.Field.Name,
                                     Employee = m.Employee != null ? m.Employee.Name : null,
                                     Participants = m.Participants.Select(p => p.Name).ToList()
                                 })
                                 .OrderBy(m => m.MatchDate)
                                 .ToListAsync();
        }

        // GET: api/Matches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchDTO>> GetMatch(int id)
        {
            var match = await _context.Matches
                                      .Where(m => m.Id == id)
                                      .Select(m => new MatchDTO
                                      {
                                          Id = m.Id,
                                          MatchDate = m.MatchDate,
                                          DurationMinutes = m.DurationMinutes,
                                          Field = m.Field.Name,
                                          Employee = m.Employee != null ? m.Employee.Name : null,
                                          Participants = m.Participants.Select(p => p.Name).ToList()
                                      })
                                      .FirstOrDefaultAsync();

            if (match == null) return NotFound();
            return match;
        }

        // POST: api/Matches
        [HttpPost]
        public async Task<ActionResult<Match>> PostMatch(Match match)
        {
            // verificar se o campo existe
            var fieldExists = await _context.Fields.AnyAsync(f => f.Id == match.FieldFK);
            if (!fieldExists) return BadRequest("O campo indicado não existe");

            try
            {
                _context.Matches.Add(match);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetMatch", new { id = match.Id }, match);
        }

        // DELETE: api/Matches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match == null) return NotFound();

            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}