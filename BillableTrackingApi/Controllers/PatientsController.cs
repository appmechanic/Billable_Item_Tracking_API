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
    public class PatientsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PatientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientRecord>>> GetPatients()
        {
            return await _context.Patients.ToListAsync();
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientRecord>> GetPatientRecord(Guid id)
        {
            var patientRecord = await _context.Patients.FindAsync(id);

            if (patientRecord == null)
            {
                return NotFound();
            }

            return patientRecord;
        }

        // PUT: api/Patients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientRecord(Guid id, PatientRecord patientRecord)
        {
            if (id != patientRecord.ID)
            {
                return BadRequest();
            }

            _context.Entry(patientRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientRecordExists(id))
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

        // POST: api/Patients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PatientRecord>> PostPatientRecord(PatientRecord patientRecord)
        {
            _context.Patients.Add(patientRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatientRecord", new { id = patientRecord.ID }, patientRecord);
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientRecord(Guid id)
        {
            var patientRecord = await _context.Patients.FindAsync(id);
            if (patientRecord == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patientRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientRecordExists(Guid id)
        {
            return _context.Patients.Any(e => e.ID == id);
        }
    }
}
