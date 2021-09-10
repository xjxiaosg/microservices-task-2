using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using microservices_task_2.Model;

namespace microservices_task_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MTBookingsController : ControllerBase
    {
        private readonly ApiDBContext _context;

        public MTBookingsController(ApiDBContext context)
        {
            _context = context;
        }

        // GET: api/MTBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MTBooking>>> GetMTBooking()
        {
            return await _context.MTBooking.ToListAsync();
        }

        // GET: api/MTBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MTBooking>> GetMTBooking(int id)
        {
            var mTBooking = await _context.MTBooking.FindAsync(id);

            if (mTBooking == null)
            {
                return NotFound();
            }

            return mTBooking;
        }

        // PUT: api/MTBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMTBooking(int id, MTBooking mTBooking)
        {
            if (id != mTBooking.MTBooking_ID)
            {
                return BadRequest();
            }

            _context.Entry(mTBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MTBookingExists(id))
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

        // POST: api/MTBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MTBooking>> PostMTBooking(MTBooking mTBooking)
        {
            _context.MTBooking.Add(mTBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMTBooking", new { id = mTBooking.MTBooking_ID }, mTBooking);
        }

        // DELETE: api/MTBookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMTBooking(int id)
        {
            var mTBooking = await _context.MTBooking.FindAsync(id);
            if (mTBooking == null)
            {
                return NotFound();
            }

            _context.MTBooking.Remove(mTBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MTBookingExists(int id)
        {
            return _context.MTBooking.Any(e => e.MTBooking_ID == id);
        }
    }
}
