using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phoenix.Data;
using Phoenix.Domains;

namespace Phoenix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentIndicationsController : ControllerBase
    {
        private readonly PhoenixContext _context;

        public PaymentIndicationsController(PhoenixContext context)
        {
            _context = context;
        }

        // GET: api/PaymentIndications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentIndication>>> GetPaymentIndication()
        {
            return await _context.PaymentIndication.ToListAsync();
        }

        // GET: api/PaymentIndications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentIndication>> GetPaymentIndication(int id)
        {
            var paymentIndication = await _context.PaymentIndication.FindAsync(id);

            if (paymentIndication == null)
            {
                return NotFound();
            }

            return paymentIndication;
        }

        // PUT: api/PaymentIndications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentIndication(int id, PaymentIndication paymentIndication)
        {
            if (id != paymentIndication.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentIndication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentIndicationExists(id))
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

        // POST: api/PaymentIndications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentIndication>> PostPaymentIndication(PaymentIndication paymentIndication)
        {
            _context.PaymentIndication.Add(paymentIndication);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PaymentIndicationExists(paymentIndication.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPaymentIndication", new { id = paymentIndication.Id }, paymentIndication);
        }

        // DELETE: api/PaymentIndications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentIndication(int id)
        {
            var paymentIndication = await _context.PaymentIndication.FindAsync(id);
            if (paymentIndication == null)
            {
                return NotFound();
            }

            _context.PaymentIndication.Remove(paymentIndication);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentIndicationExists(int id)
        {
            return _context.PaymentIndication.Any(e => e.Id == id);
        }
    }
}
