﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phoenix.Data;
using Phoenix.Models;

namespace Phoenix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        private readonly PhoenixContext _context;

        public PaymentMethodsController(PhoenixContext context)
        {
            _context = context;
        }

        // GET: api/PaymentMethods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentMethod>>> GetPaymentMethod()
        {
            return await _context.PaymentMethod.ToListAsync();
        }

        // GET: api/PaymentMethods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentMethod>> GetPaymentMethod(int id)
        {
            var paymentMethod = await _context.PaymentMethod.FindAsync(id);

            if (paymentMethod == null)
            {
                return NotFound();
            }

            return paymentMethod;
        }

        // PUT: api/PaymentMethods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentMethod(int id, PaymentMethod paymentMethod)
        {
            if (id != paymentMethod.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentMethod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentMethodExists(id))
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

        // POST: api/PaymentMethods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentMethod>> PostPaymentMethod(PaymentMethod paymentMethod)
        {
            _context.PaymentMethod.Add(paymentMethod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentMethod", new { id = paymentMethod.Id }, paymentMethod);
        }

        // DELETE: api/PaymentMethods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentMethod(int id)
        {
            var paymentMethod = await _context.PaymentMethod.FindAsync(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            _context.PaymentMethod.Remove(paymentMethod);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentMethodExists(int id)
        {
            return _context.PaymentMethod.Any(e => e.Id == id);
        }
    }
}
