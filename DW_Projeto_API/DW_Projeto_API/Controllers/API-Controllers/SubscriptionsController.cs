using DW_Projeto_API.Data;
using DW_Projeto_API.Models;
using DW_Projeto_API.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")] // Autenticação por JWT
public class SubscriptionsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public SubscriptionsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Subscription
    [HttpGet]
    [AllowAnonymous] 
    public async Task<ActionResult<IEnumerable<SubscriptionDTO>>> GetSubscription()
    {
        /* _context.Subscriptions.ToListAsync() its a LINQ command that means
          * SELECT *
          * FROM Subscriptions 
          */

        return await _context.Subscriptions.Select(s => new SubscriptionDTO {
            Id = s.Id,
            Name = s.Name
        }).OrderBy(s => s.Name).ToListAsync();
    }

    // GET: api/Subscription/5
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<SubscriptionSimplierDTO>> GetSubscription(int id)
    {
        // in LINQ
        // _context.Subscriptions.FindAsync(id); means
        // SELECT *
        // FROM Subscriptions
        // WHERE Id = id

        var subscription = await _context.Subscriptions
                                                .Where(s => s.Id == id)
                                                .Select(s => new SubscriptionSimplierDTO
                                                {
                                                    Name = s.Name,
                                                }).FirstOrDefaultAsync();

        if (subscription == null)
        {
            return NotFound();
        }

        return subscription;
    }

    /*
    // PUT: api/Subscription/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSubscription(int? id, Subscription subscription)
    {
        if (id != subscription.Id)
        {
            return BadRequest();
        }

        _context.Entry(subscription).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SubscriptionExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }
    */

    // POST: api/Subscription
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<SubscriptionSimplierDTO>> PostSubscription(SubscriptionSimplierDTO subscriptionName)
    {
        Subscription subscription = new()
        {
            Name = subscriptionName.Name,
        };

        try {
            _context.Subscriptions.Add(subscription);
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            //throw;
            /* use 'throw' ONLY in development environment
             * NEVER, NEVER in 'production', 
             * because it expose too much data related with your program
             */
            return BadRequest();
        }

        

        return CreatedAtAction("GetSubscription", new { id = subscription.Id }, subscription);
    }

    /*
    // DELETE: api/Subscription/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSubscription(int? id)
    {
        var subscription = await _context.Subscriptions.FindAsync(id);
        if (subscription == null)
        {
            return NotFound();
        }

        _context.Subscriptions.Remove(subscription);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool SubscriptionExists(int? id)
    {
        return _context.Subscriptions.Any(e => e.Id == id);
    }
    */
}
