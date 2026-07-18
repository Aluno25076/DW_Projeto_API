using DW_Projeto_API.Data;
using DW_Projeto_API.Models;
using DW_Projeto_API.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DW_Projeto_API.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FieldsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Fields
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FieldDTO>>> GetFields()
        {
            /* SELECT * FROM Fields ORDER BY Name */
            return await _context.Fields
                                 .Select(f => new FieldDTO
                                 {
                                     Id = f.Id,
                                     Name = f.Name,
                                     Surface = f.Surface.ToString(),
                                     IsIndoor = f.IsIndoor
                                 })
                                 .OrderBy(f => f.Name)
                                 .ToListAsync();
        }

        // GET: api/Fields/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FieldDTO>> GetField(int id)
        {
            var field = await _context.Fields
                                      .Where(f => f.Id == id)
                                      .Select(f => new FieldDTO
                                      {
                                          Id = f.Id,
                                          Name = f.Name,
                                          Surface = f.Surface.ToString(),
                                          IsIndoor = f.IsIndoor
                                      })
                                      .FirstOrDefaultAsync();

            if (field == null) return NotFound();
            return field;
        }

        // POST: api/Fields
        [HttpPost]
        public async Task<ActionResult<FieldDTO>> PostField(FieldDTO fieldDTO)
        {
            // converter o texto do piso para o enum
            if (!Enum.TryParse<Field.SurfaceType>(fieldDTO.Surface, out var surface))
            {
                return BadRequest("Tipo de piso inválido");
            }

            Field field = new()
            {
                Name = fieldDTO.Name,
                Surface = surface,
                IsIndoor = fieldDTO.IsIndoor
            };

            try
            {
                _context.Fields.Add(field);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                // 'throw' APENAS em desenvolvimento, NUNCA em produção
                return BadRequest();
            }

            return CreatedAtAction("GetField", new { id = field.Id }, field);
        }

        // DELETE: api/Fields/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteField(int id)
        {
            var field = await _context.Fields.FindAsync(id);
            if (field == null) return NotFound();

            _context.Fields.Remove(field);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}