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
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.KeyVault;

namespace HackathonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalEntriesController : ControllerBase
    {
        private readonly JournalEntryContext _contextJE;
        private readonly GoalContext _contextGoal;
        private readonly UserDataContext _contextUser;
        private readonly PromptContext _contextPrompt;
        private readonly JournalEntryService _journalEntryService;

        public JournalEntriesController(JournalEntryContext contextJE, GoalContext contextGoal, PromptContext contextPrompt, UserDataContext contextUser,IConfiguration configuration, KeyVaultClient keyVaultClient)
        {
             _journalEntryService = new JournalEntryService(configuration,keyVaultClient);
            _contextJE = contextJE;
            _contextGoal = contextGoal;
            _contextUser = contextUser;
            _contextPrompt = contextPrompt;
        }

        // GET: api/JournalEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JournalEntry>>> GetJournalEntries()
        {
            return await _contextJE.JournalEntry.ToListAsync();
        }

        [HttpGet("goals/{id}/{mood}")]
        public async Task<IEnumerable<string>> GetBestGoals(int id, int mood)
        {
            IEnumerable<Goal> goals = await _contextGoal.Goal.ToListAsync();
            var userData = await _contextUser.UserData.FindAsync(id);

            if (userData == null)
            {
                throw new Exception();
            }
            return await _journalEntryService.GetBestGoals(goals, userData, mood);
        }

        [HttpGet("prompts/{id}/{mood}")]
        public async Task<IEnumerable<string>> GetBestPrompts(int id, int mood)
        {
            IEnumerable<Prompt> prompts = await _contextPrompt.Prompt.ToListAsync();
            var userData = await _contextUser.UserData.FindAsync(id);

            if (userData == null)
            {
                throw new Exception();
            }
            return await _journalEntryService.GetBestPrompts(prompts, userData, mood);
        }

        // GET: api/JournalEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JournalEntry>> GetJournalEntry(int id)
        {
            var journalEntry = await _contextJE.JournalEntry.FindAsync(id);

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

            _contextJE.Entry(journalEntry).State = EntityState.Modified;

            try
            {
                await _contextJE.SaveChangesAsync();
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
            JournalEntry journalEntry = await _journalEntryService.GetTextAnalytics(userEntry);

            _contextJE.JournalEntry.Add(journalEntry);
            await _contextJE.SaveChangesAsync();

            return CreatedAtAction("GetJournalEntry", new { id = journalEntry.JournalKey }, journalEntry);
        }

        // DELETE: api/JournalEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JournalEntry>> DeleteJournalEntry(int id)
        {
            var journalEntry = await _contextJE.JournalEntry.FindAsync(id);
            if (journalEntry == null)
            {
                return NotFound();
            }

            _contextJE.JournalEntry.Remove(journalEntry);
            await _contextJE.SaveChangesAsync();

            return journalEntry;
        }

        private bool JournalEntryExists(int id)
        {
            return _contextJE.JournalEntry.Any(e => e.JournalKey == id);
        }
    }
}
