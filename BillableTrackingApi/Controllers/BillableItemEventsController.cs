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
    public class BillableItemEventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BillableItemEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BillableItemEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillableItemEventRecord>>> GetBillableItemEvents()
        {
            return await _context.BillableItemEvents.ToListAsync();
        }

        // GET: api/BillableItemEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillableItemEventRecord>> GetBillableItemEventRecord(Guid id)
        {
            var billableItemEventRecord = await _context.BillableItemEvents.FindAsync(id);

            if (billableItemEventRecord == null)
            {
                return NotFound();
            }

            return billableItemEventRecord;
        }

        // PUT: api/BillableItemEvents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillableItemEventRecord(Guid id, BillableItemEventRecord billableItemEventRecord)
        {
            if (id != billableItemEventRecord.ID)
            {
                return BadRequest();
            }

            _context.Entry(billableItemEventRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillableItemEventRecordExists(id))
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

        // POST: api/BillableItemEvents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BillableItemEventRecord>> PostBillableItemEventRecord(BillableItemEventRecord billableItemEventRecord)
        {
            _context.BillableItemEvents.Add(billableItemEventRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBillableItemEventRecord", new { id = billableItemEventRecord.ID }, billableItemEventRecord);
        }

        // DELETE: api/BillableItemEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBillableItemEventRecord(Guid id)
        {
            var billableItemEventRecord = await _context.BillableItemEvents.FindAsync(id);
            if (billableItemEventRecord == null)
            {
                return NotFound();
            }

            _context.BillableItemEvents.Remove(billableItemEventRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BillableItemEventRecordExists(Guid id)
        {
            return _context.BillableItemEvents.Any(e => e.ID == id);
        }
    }
}
