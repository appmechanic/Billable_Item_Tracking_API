using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BillableTrackingApi.Models;

namespace BillableTrackingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferralSourceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReferralSourceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ReferralSource
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReferralSourceRecord>>> GetReferralSources()
        {
            return await _context.ReferralSources.ToListAsync();
        }

        // GET: api/ReferralSource/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReferralSourceRecord>> GetReferralSourceRecord(Guid id)
        {
            var referralSourceRecord = await _context.ReferralSources.FindAsync(id);

            if (referralSourceRecord == null)
            {
                return NotFound();
            }

            return referralSourceRecord;
        }

        // PUT: api/ReferralSource/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReferralSourceRecord(Guid id, ReferralSourceRecord referralSourceRecord)
        {
            if (id != referralSourceRecord.ID)
            {
                return BadRequest();
            }

            _context.Entry(referralSourceRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferralSourceRecordExists(id))
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

        // POST: api/ReferralSource
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReferralSourceRecord>> PostReferralSourceRecord(ReferralSourceRecord referralSourceRecord)
        {
            _context.ReferralSources.Add(referralSourceRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReferralSourceRecord", new { id = referralSourceRecord.ID }, referralSourceRecord);
        }

        // DELETE: api/ReferralSource/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReferralSourceRecord(Guid id)
        {
            var referralSourceRecord = await _context.ReferralSources.FindAsync(id);
            if (referralSourceRecord == null)
            {
                return NotFound();
            }

            _context.ReferralSources.Remove(referralSourceRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReferralSourceRecordExists(Guid id)
        {
            return _context.ReferralSources.Any(e => e.ID == id);
        }
    }
}
