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
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRecord>>> GetUserRecord()
        {
            return await _context.UserRecord.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRecord>> GetUserRecord(Guid id)
        {
            var userRecord = await _context.UserRecord.FindAsync(id);

            if (userRecord == null)
            {
                return NotFound();
            }

            return userRecord;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRecord(Guid id, UserRecord userRecord)
        {
            if (id != userRecord.ID)
            {
                return BadRequest();
            }

            _context.Entry(userRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRecordExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserRecord>> PostUserRecord(UserRecord userRecord)
        {
            _context.UserRecord.Add(userRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserRecord", new { id = userRecord.ID }, userRecord);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRecord(Guid id)
        {
            var userRecord = await _context.UserRecord.FindAsync(id);
            if (userRecord == null)
            {
                return NotFound();
            }

            _context.UserRecord.Remove(userRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserRecordExists(Guid id)
        {
            return _context.UserRecord.Any(e => e.ID == id);
        }
    }
}
