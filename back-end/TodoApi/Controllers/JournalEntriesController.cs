using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HackathonApi.Models.Context;
using HackathonApi.Models.Dto;
using HackathonApi.Models.Service;

namespace HackathonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalEntriesController : ControllerBase
    {
        private readonly JournalEntryContext _context;
        private readonly JournalEntryService _journalEntryService;

        public JournalEntriesController(JournalEntryContext context)
        {
             _journalEntryService = new JournalEntryService();
            _context = context;
        }

        // GET: api/JournalEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JournalEntry>>> GetJournalEntries()
        {
            return await _context.JournalEntry.ToListAsync();
        }

        // GET: api/JournalEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JournalEntry>> GetJournalEntry(int id)
        {
            var journalEntry = await _context.JournalEntry.FindAsync(id);

            if (journalEntry == null)
            {
                return NotFound();
            }

            return journalEntry;
        }

        // PUT: api/JournalEntries/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJournalEntry(int id, JournalEntry journalEntry)
        {
            if (id != journalEntry.JournalKey)
            {
                return BadRequest();
            }

            _context.Entry(journalEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JournalEntryExists(id))
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

        // POST: api/JournalEntries
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<JournalEntry>> PostJournalEntry(UserEntry userEntry)
        {

<<<<<<< HEAD
            JournalEntry journalEntry = await _journalEntryService.GetTextAnalytics(userEntry);
=======
            JournalEntry journalEntry = _journalEntryService.GetTextAnalytics();
>>>>>>> e7fc36c... sentiment analysis added
            _context.JournalEntry.Add(journalEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJournalEntry", new { id = journalEntry.JournalKey }, journalEntry);
        }

        // DELETE: api/JournalEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JournalEntry>> DeleteJournalEntry(int id)
        {
            var journalEntry = await _context.JournalEntry.FindAsync(id);
            if (journalEntry == null)
            {
                return NotFound();
            }

            _context.JournalEntry.Remove(journalEntry);
            await _context.SaveChangesAsync();

            return journalEntry;
        }

        private bool JournalEntryExists(int id)
        {
            return _context.JournalEntry.Any(e => e.JournalKey == id);
        }
    }
}
