using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phoenix.Data;
using Phoenix.Models;

namespace Phoenix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTermMethodsController : ControllerBase
    {
        private readonly PhoenixContext _context;

        public PaymentTermMethodsController(PhoenixContext context)
        {
            _context = context;
        }

        // GET: api/PaymentTermMethods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentTermMethod>>> GetPaymentTermMethod_1()
        {
            return await _context.PaymentTermMethod_1.ToListAsync();
        }

        // GET: api/PaymentTermMethods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentTermMethod>> GetPaymentTermMethod(int id)
        {
            var paymentTermMethod = await _context.PaymentTermMethod_1.FindAsync(id);

            if (paymentTermMethod == null)
            {
                return NotFound();
            }

            return paymentTermMethod;
        }

        // PUT: api/PaymentTermMethods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentTermMethod(int id, PaymentTermMethod paymentTermMethod)
        {
            if (id != paymentTermMethod.PaymentTermId)
            {
                return BadRequest();
            }

            _context.Entry(paymentTermMethod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTermMethodExists(id))
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

        // POST: api/PaymentTermMethods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentTermMethod>> PostPaymentTermMethod(PaymentTermMethod paymentTermMethod)
        {
            _context.PaymentTermMethod_1.Add(paymentTermMethod);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PaymentTermMethodExists(paymentTermMethod.PaymentTermId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPaymentTermMethod", new { id = paymentTermMethod.PaymentTermId }, paymentTermMethod);
        }

        // DELETE: api/PaymentTermMethods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentTermMethod(int id)
        {
            var paymentTermMethod = await _context.PaymentTermMethod_1.FindAsync(id);
            if (paymentTermMethod == null)
            {
                return NotFound();
            }

            _context.PaymentTermMethod_1.Remove(paymentTermMethod);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentTermMethodExists(int id)
        {
            return _context.PaymentTermMethod_1.Any(e => e.PaymentTermId == id);
        }
    }
}
