using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phoenix.Data;
using Phoenix.Models;

namespace Phoenix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTermsController : ControllerBase
    {
        private readonly PhoenixContext _context;

        public PaymentTermsController(PhoenixContext context)
        {
            _context = context;
        }

        // GET: api/PaymentTerms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentTerm>>> GetPaymentTerm()
        {
            return await _context.PaymentTerm.ToListAsync();
        }

        // GET: api/PaymentTerms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentTerm>> GetPaymentTerm(int id)
        {
            var paymentTerm = await _context.PaymentTerm.FindAsync(id);

            if (paymentTerm == null)
            {
                return NotFound();
            }

            return paymentTerm;
        }

        // PUT: api/PaymentTerms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentTerm(int id, PaymentTerm paymentTerm)
        {
            if (id != paymentTerm.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentTerm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTermExists(id))
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

        // POST: api/PaymentTerms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentTerm>> PostPaymentTerm(PaymentTerm paymentTerm)
        {
            _context.PaymentTerm.Add(paymentTerm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentTerm", new { id = paymentTerm.Id }, paymentTerm);
        }

        // DELETE: api/PaymentTerms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentTerm(int id)
        {
            var paymentTerm = await _context.PaymentTerm.FindAsync(id);
            if (paymentTerm == null)
            {
                return NotFound();
            }

            _context.PaymentTerm.Remove(paymentTerm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentTermExists(int id)
        {
            return _context.PaymentTerm.Any(e => e.Id == id);
        }
    }
}
