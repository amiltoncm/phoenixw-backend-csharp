using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phoenix.Data;
using Phoenix.Domains;

namespace Phoenix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicPlacesController : ControllerBase
    {
        private readonly PhoenixContext _context;

        public PublicPlacesController(PhoenixContext context)
        {
            _context = context;
        }

        // GET: api/PublicPlaces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicPlace>>> GetPublicPlace()
        {
            return await _context.PublicPlace.ToListAsync();
        }

        // GET: api/PublicPlaces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicPlace>> GetPublicPlace(int id)
        {
            var publicPlace = await _context.PublicPlace.FindAsync(id);

            if (publicPlace == null)
            {
                return NotFound();
            }

            return publicPlace;
        }

        // PUT: api/PublicPlaces/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicPlace(int id, PublicPlace publicPlace)
        {
            if (id != publicPlace.Id)
            {
                return BadRequest();
            }

            _context.Entry(publicPlace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicPlaceExists(id))
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

        // POST: api/PublicPlaces
        [HttpPost]
        public async Task<ActionResult<PublicPlace>> PostPublicPlace(PublicPlace publicPlace)
        {
            _context.PublicPlace.Add(publicPlace);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PublicPlaceExists(publicPlace.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPublicPlace", new { id = publicPlace.Id }, publicPlace);
        }

        // DELETE: api/PublicPlaces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublicPlace(int id)
        {
            var publicPlace = await _context.PublicPlace.FindAsync(id);
            if (publicPlace == null)
            {
                return NotFound();
            }

            _context.PublicPlace.Remove(publicPlace);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublicPlaceExists(int id)
        {
            return _context.PublicPlace.Any(e => e.Id == id);
        }
    }
}
