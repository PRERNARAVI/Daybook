using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HackathonApi.Models.Context;
using HackathonApi.Models.Dto;

namespace HackathonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromptsController : ControllerBase
    {
        private readonly PromptContext _context;

        public PromptsController(PromptContext context)
        {
            _context = context;
        }

        // GET: api/Prompts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prompt>>> GetPrompt()
        {
            return await _context.Prompt.ToListAsync();
        }

        // GET: api/Prompts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prompt>> GetPrompt(int id)
        {
            var prompt = await _context.Prompt.FindAsync(id);

            if (prompt == null)
            {
                return NotFound();
            }

            return prompt;
        }

        // PUT: api/Prompts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrompt(int id, Prompt prompt)
        {
            if (id != prompt.PromptId)
            {
                return BadRequest();
            }

            _context.Entry(prompt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromptExists(id))
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

        // POST: api/Prompts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Prompt>> PostPrompt(Prompt prompt)
        {
            _context.Prompt.Add(prompt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrompt", new { id = prompt.PromptId }, prompt);
        }

        // DELETE: api/Prompts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Prompt>> DeletePrompt(int id)
        {
            var prompt = await _context.Prompt.FindAsync(id);
            if (prompt == null)
            {
                return NotFound();
            }

            _context.Prompt.Remove(prompt);
            await _context.SaveChangesAsync();

            return prompt;
        }

        private bool PromptExists(int id)
        {
            return _context.Prompt.Any(e => e.PromptId == id);
        }
    }
}
