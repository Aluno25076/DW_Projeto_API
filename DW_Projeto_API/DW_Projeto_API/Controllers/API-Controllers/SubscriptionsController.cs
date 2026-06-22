using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DW_Projeto_API.Models;
using DW_Projeto_API.Data;
using DW_Projeto_API.Models.ViewModels;

[Route("api/[controller]")]
[ApiController]
public class SubscriptionsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public SubscriptionsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Subscription
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubscriptionDTO>>> GetSubscription()
    {
        // return await _context.Subscriptions.ToListAsync();
        return await _context.Subscriptions.Select(s => new SubscriptionDTO
        {
            //Id = new s.Id,
            Name = s.Name

        }).OrderBy(s => s.Name).ToListAsync();
    }

    // GET: api/Subscription/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Subscription>> GetSubscription(int id)
    {
        var subscription = await _context.Subscriptions.FindAsync(id);
        /*
        return await _context.Subscriptions.Where(s => s.Id == id).Select(s => new Subscription
        {
            //Id = new s.Id,
            Name = s.Name

        }).OrderBy(s => s.Name).ToListAsync();
        */

        if (subscription == null)
        {
            return NotFound();
        }

        return subscription;
    }

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

    // POST: api/Subscription
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Subscription>> PostSubscription(Subscription subscription)
    {
        _context.Subscriptions.Add(subscription);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetSubscription", new { id = subscription.Id }, subscription);
    }

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
}
