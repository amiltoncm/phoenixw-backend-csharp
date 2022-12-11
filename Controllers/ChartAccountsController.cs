using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phoenix.Data;
using Phoenix.Models;

namespace Phoenix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartAccountsController : ControllerBase
    {
        private readonly PhoenixContext _context;

        public ChartAccountsController(PhoenixContext context)
        {
            _context = context;
        }

        // GET: api/ChartAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChartAccounts>>> GetChartAccounts()
        {
            return await _context.ChartAccounts.ToListAsync();
        }

        // GET: api/ChartAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChartAccounts>> GetChartAccounts(int id)
        {
            var chartAccounts = await _context.ChartAccounts.FindAsync(id);

            if (chartAccounts == null)
            {
                return NotFound();
            }

            return chartAccounts;
        }

        // PUT: api/ChartAccounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChartAccounts(int id, ChartAccounts chartAccounts)
        {
            if (id != chartAccounts.Id)
            {
                return BadRequest();
            }

            _context.Entry(chartAccounts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChartAccountsExists(id))
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

        // POST: api/ChartAccounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChartAccounts>> PostChartAccounts(ChartAccounts chartAccounts)
        {
            _context.ChartAccounts.Add(chartAccounts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChartAccounts", new { id = chartAccounts.Id }, chartAccounts);
        }

        // DELETE: api/ChartAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChartAccounts(int id)
        {
            var chartAccounts = await _context.ChartAccounts.FindAsync(id);
            if (chartAccounts == null)
            {
                return NotFound();
            }

            _context.ChartAccounts.Remove(chartAccounts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChartAccountsExists(int id)
        {
            return _context.ChartAccounts.Any(e => e.Id == id);
        }
    }
}
