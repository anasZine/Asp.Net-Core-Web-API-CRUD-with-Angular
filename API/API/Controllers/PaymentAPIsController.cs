using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Ecommerce.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentAPIsController : ControllerBase
    {
        private readonly PaymentDetailsContext _context;

        public PaymentAPIsController(PaymentDetailsContext context)
        {
            _context = context;
        }

        // GET: api/PaymentAPIs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentAPI>>> GetPaymentsAPI()
        {
          if (_context.PaymentsAPI == null)
          {
              return NotFound();
          }
            return await _context.PaymentsAPI.ToListAsync();
        }

        // GET: api/PaymentAPIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentAPI>> GetPaymentAPI(int id)
        {
          if (_context.PaymentsAPI == null)
          {
              return NotFound();
          }
            var paymentAPI = await _context.PaymentsAPI.FindAsync(id);

            if (paymentAPI == null)
            {
                return NotFound();
            }

            return paymentAPI;
        }

        // PUT: api/PaymentAPIs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentAPI(int id, PaymentAPI paymentAPI)
        {
            if (id != paymentAPI.PaymentDetailsId)
            {
                return BadRequest();
            }

            _context.Entry(paymentAPI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentAPIExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await _context.PaymentsAPI.ToListAsync());
        }

        // POST: api/PaymentAPIs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentAPI>> PostPaymentAPI(PaymentAPI paymentAPI)
        {
          if (_context.PaymentsAPI == null)
          {
              return Problem("Entity set 'PaymentDetailsContext.PaymentsAPI'  is null.");
          }
            _context.PaymentsAPI.Add(paymentAPI);
            await _context.SaveChangesAsync();

            return Ok(  await _context.PaymentsAPI.ToListAsync());
        }

        // DELETE: api/PaymentAPIs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentAPI(int id)
        {
            if (_context.PaymentsAPI == null)
            {
                return NotFound();
            }
            var paymentAPI = await _context.PaymentsAPI.FindAsync(id);
            if (paymentAPI == null)
            {
                return NotFound();
            }

            _context.PaymentsAPI.Remove(paymentAPI);
            await _context.SaveChangesAsync();

            return Ok(await _context.PaymentsAPI.ToListAsync());
        }

        private bool PaymentAPIExists(int id)
        {
            return (_context.PaymentsAPI?.Any(e => e.PaymentDetailsId == id)).GetValueOrDefault();
        }
    }
}
