using DW_Projeto_API.Data;
using DW_Projeto_API.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DW_Projeto_API.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            return await _context.Employees
                                 .Select(e => new EmployeeDTO
                                 {
                                     Id = e.Id,
                                     Name = e.Name,
                                     Position = e.Position,
                                     NumberOfMatches = e.Matches.Count
                                 })
                                 .OrderBy(e => e.Name)
                                 .ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            var employee = await _context.Employees
                                         .Where(e => e.Id == id)
                                         .Select(e => new EmployeeDTO
                                         {
                                             Id = e.Id,
                                             Name = e.Name,
                                             Position = e.Position,
                                             NumberOfMatches = e.Matches.Count
                                         })
                                         .FirstOrDefaultAsync();

            if (employee == null) return NotFound();
            return employee;
        }
    }
}