using BillableTrackingApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BillableTrackingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceCompanyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InsuranceCompanyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InsuranceCompanyRecord
        [HttpGet]
        public async Task<IActionResult> GetInsuranceCompanies()
        {
            var companies = await _context.InsuranceCompanies.ToListAsync();
            return Ok(companies);
        }

        // GET: api/InsuranceCompanyRecord/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInsuranceCompany(Guid id)
        {
            var company = await _context.InsuranceCompanies.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // POST: api/InsuranceCompanyRecord
        [HttpPost]
        public async Task<IActionResult> PostInsuranceCompany(InsuranceCompanyRecord company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.InsuranceCompanies.Add(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsuranceCompany", new { id = company.ID }, company);
        }

        // PUT: api/InsuranceCompanyRecord/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsuranceCompany(Guid id, InsuranceCompanyRecord company)
        {
            if (id != company.ID)
            {
                return BadRequest();
            }

            _context.Entry(company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceCompanyRecordExists(id))
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

        // DELETE: api/InsuranceCompanyRecord/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsuranceCompany(Guid id)
        {
            var company = await _context.InsuranceCompanies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.InsuranceCompanies.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InsuranceCompanyRecordExists(Guid id)
        {
            return _context.InsuranceCompanies.Any(e => e.ID == id);
        }
    }
}
