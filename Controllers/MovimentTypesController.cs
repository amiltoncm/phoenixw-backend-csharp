using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phoenix.Data;
using Phoenix.Domains;

namespace Phoenix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentTypesController : ControllerBase
    {
        private readonly PhoenixContext _context;

        public MovimentTypesController(PhoenixContext context)
        {
            _context = context;
        }

        // GET: api/MovimentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovimentType>>> GetMovimentType()
        {
            return await _context.MovimentType.ToListAsync();
        }

        // GET: api/MovimentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovimentType>> GetMovimentType(string id)
        {
            var movimentType = await _context.MovimentType.FindAsync(id);

            if (movimentType == null)
            {
                return NotFound();
            }

            return movimentType;
        }

        // PUT: api/MovimentTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovimentType(string id, MovimentType movimentType)
        {
            if (id != movimentType.Id)
            {
                return BadRequest();
            }

            _context.Entry(movimentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimentTypeExists(id))
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

        // POST: api/MovimentTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovimentType>> PostMovimentType(MovimentType movimentType)
        {
            _context.MovimentType.Add(movimentType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MovimentTypeExists(movimentType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMovimentType", new { id = movimentType.Id }, movimentType);
        }

        // DELETE: api/MovimentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovimentType(string id)
        {
            var movimentType = await _context.MovimentType.FindAsync(id);
            if (movimentType == null)
            {
                return NotFound();
            }

            _context.MovimentType.Remove(movimentType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovimentTypeExists(string id)
        {
            return _context.MovimentType.Any(e => e.Id == id);
        }
    }
}
