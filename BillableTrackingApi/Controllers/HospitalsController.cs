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
    public class HospitalsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HospitalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Hospitals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalRecord>>> GetHospitalRecord()
        {
            return await _context.HospitalRecord.ToListAsync();
        }

        // GET: api/Hospitals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalRecord>> GetHospitalRecord(Guid id)
        {
            var hospitalRecord = await _context.HospitalRecord.FindAsync(id);

            if (hospitalRecord == null)
            {
                return NotFound();
            }

            return hospitalRecord;
        }

        // PUT: api/Hospitals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalRecord(Guid id, HospitalRecord hospitalRecord)
        {
            if (id != hospitalRecord.HospitalID)
            {
                return BadRequest();
            }

            _context.Entry(hospitalRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalRecordExists(id))
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

        // POST: api/Hospitals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HospitalRecord>> PostHospitalRecord(HospitalRecord hospitalRecord)
        {
            _context.HospitalRecord.Add(hospitalRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalRecord", new { id = hospitalRecord.HospitalID }, hospitalRecord);
        }

        // DELETE: api/Hospitals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHospitalRecord(Guid id)
        {
            var hospitalRecord = await _context.HospitalRecord.FindAsync(id);
            if (hospitalRecord == null)
            {
                return NotFound();
            }

            _context.HospitalRecord.Remove(hospitalRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HospitalRecordExists(Guid id)
        {
            return _context.HospitalRecord.Any(e => e.HospitalID == id);
        }
    }
}
