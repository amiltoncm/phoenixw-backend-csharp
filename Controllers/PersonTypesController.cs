using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phoenix.Data;
using Phoenix.Domains;

namespace Phoenix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonTypesController : ControllerBase
    {
        private readonly PhoenixContext _context;

        public PersonTypesController(PhoenixContext context)
        {
            _context = context;
        }

        // GET: api/PersonTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonType>>> GetPersonType()
        {
            return await _context.PersonType.ToListAsync();
        }

        // GET: api/PersonTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonType>> GetPersonType(string id)
        {
            var personType = await _context.PersonType.FindAsync(id);

            if (personType == null)
            {
                return NotFound();
            }

            return personType;
        }

        // PUT: api/PersonTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonType(string id, PersonType personType)
        {
            if (id != personType.Id)
            {
                return BadRequest();
            }

            _context.Entry(personType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonTypeExists(id))
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

        // POST: api/PersonTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonType>> PostPersonType(PersonType personType)
        {
            _context.PersonType.Add(personType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonTypeExists(personType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPersonType", new { id = personType.Id }, personType);
        }

        // DELETE: api/PersonTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonType(string id)
        {
            var personType = await _context.PersonType.FindAsync(id);
            if (personType == null)
            {
                return NotFound();
            }

            _context.PersonType.Remove(personType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonTypeExists(string id)
        {
            return _context.PersonType.Any(e => e.Id == id);
        }
    }
}
