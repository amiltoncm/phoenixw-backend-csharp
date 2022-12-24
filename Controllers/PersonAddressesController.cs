using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phoenix.Data;
using Phoenix.Models;

namespace Phoenix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonAddressesController : ControllerBase
    {
        private readonly PhoenixContext _context;

        public PersonAddressesController(PhoenixContext context)
        {
            _context = context;
        }

        // GET: api/PersonAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonAddress>>> GetPersonAddress()
        {
            return await _context.PersonAddress.ToListAsync();
        }

        // GET: api/PersonAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonAddress>> GetPersonAddress(int id)
        {
            var personAddress = await _context.PersonAddress.FindAsync(id);

            if (personAddress == null)
            {
                return NotFound();
            }

            return personAddress;
        }

        // PUT: api/PersonAddresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonAddress(int id, PersonAddress personAddress)
        {
            if (id != personAddress.Id)
            {
                return BadRequest();
            }

            _context.Entry(personAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonAddressExists(id))
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

        // POST: api/PersonAddresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonAddress>> PostPersonAddress(PersonAddress personAddress)
        {
            _context.PersonAddress.Add(personAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonAddress", new { id = personAddress.Id }, personAddress);
        }

        // DELETE: api/PersonAddresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonAddress(int id)
        {
            var personAddress = await _context.PersonAddress.FindAsync(id);
            if (personAddress == null)
            {
                return NotFound();
            }

            _context.PersonAddress.Remove(personAddress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonAddressExists(int id)
        {
            return _context.PersonAddress.Any(e => e.Id == id);
        }
    }
}
