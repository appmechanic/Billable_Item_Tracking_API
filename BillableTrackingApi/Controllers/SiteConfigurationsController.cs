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
    public class SiteConfigurationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SiteConfigurationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SiteConfigurations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SiteConfiguration>>> GetSiteConfigurations()
        {
            return await _context.SiteConfigurations.ToListAsync();
        }

        // GET: api/SiteConfigurations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SiteConfiguration>> GetSiteConfiguration(Guid id)
        {
            var siteConfiguration = await _context.SiteConfigurations.FindAsync(id);

            if (siteConfiguration == null)
            {
                return NotFound();
            }

            return siteConfiguration;
        }

        // PUT: api/SiteConfigurations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSiteConfiguration(Guid id, SiteConfiguration siteConfiguration)
        {
            if (id != siteConfiguration.Id)
            {
                return BadRequest();
            }

            _context.Entry(siteConfiguration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiteConfigurationExists(id))
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

        // POST: api/SiteConfigurations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SiteConfiguration>> PostSiteConfiguration(SiteConfiguration siteConfiguration)
        {
            _context.SiteConfigurations.Add(siteConfiguration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSiteConfiguration", new { id = siteConfiguration.Id }, siteConfiguration);
        }

        // DELETE: api/SiteConfigurations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSiteConfiguration(Guid id)
        {
            var siteConfiguration = await _context.SiteConfigurations.FindAsync(id);
            if (siteConfiguration == null)
            {
                return NotFound();
            }

            _context.SiteConfigurations.Remove(siteConfiguration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SiteConfigurationExists(Guid id)
        {
            return _context.SiteConfigurations.Any(e => e.Id == id);
        }
    }
}
