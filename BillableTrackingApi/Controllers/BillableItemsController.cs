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
    public class BillableItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BillableItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BillableItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillableItemRecord>>> GetBillableItems()
        {
            return await _context.BillableItems.ToListAsync();
        }

        // GET: api/BillableItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillableItemRecord>> GetBillableItemRecord(Guid id)
        {
            var billableItemRecord = await _context.BillableItems.FindAsync(id);

            if (billableItemRecord == null)
            {
                return NotFound();
            }

            return billableItemRecord;
        }

        // PUT: api/BillableItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillableItemRecord(Guid id, BillableItemRecord billableItemRecord)
        {
            if (id != billableItemRecord.ID)
            {
                return BadRequest();
            }

            _context.Entry(billableItemRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillableItemRecordExists(id))
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

        // POST: api/BillableItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BillableItemRecord>> PostBillableItemRecord(BillableItemRecord billableItemRecord)
        {
            _context.BillableItems.Add(billableItemRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBillableItemRecord", new { id = billableItemRecord.ID }, billableItemRecord);
        }

        // DELETE: api/BillableItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBillableItemRecord(Guid id)
        {
            var billableItemRecord = await _context.BillableItems.FindAsync(id);
            if (billableItemRecord == null)
            {
                return NotFound();
            }

            _context.BillableItems.Remove(billableItemRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BillableItemRecordExists(Guid id)
        {
            return _context.BillableItems.Any(e => e.ID == id);
        }
    }
}
