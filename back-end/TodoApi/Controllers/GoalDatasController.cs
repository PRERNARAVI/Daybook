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
    public class GoalDatasController : ControllerBase
    {
        private readonly GoalDataContext _context;

        public GoalDatasController(GoalDataContext context)
        {
            _context = context;
        }

        // GET: api/GoalDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoalData>>> GetGoalData()
        {
            return await _context.GoalData.ToListAsync();
        }

        // GET: api/GoalDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GoalData>> GetGoalData(int id)
        {
            var goalData = await _context.GoalData.FindAsync(id);

            if (goalData == null)
            {
                return NotFound();
            }

            return goalData;
        }

        // PUT: api/GoalDatas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoalData(int id, GoalData goalData)
        {
            if (id != goalData.GoalId)
            {
                return BadRequest();
            }

            _context.Entry(goalData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoalDataExists(id))
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

        // POST: api/GoalDatas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GoalData>> PostGoalData(GoalData goalData)
        {
            _context.GoalData.Add(goalData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGoalData", new { id = goalData.GoalId }, goalData);
        }

        // DELETE: api/GoalDatas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GoalData>> DeleteGoalData(int id)
        {
            var goalData = await _context.GoalData.FindAsync(id);
            if (goalData == null)
            {
                return NotFound();
            }

            _context.GoalData.Remove(goalData);
            await _context.SaveChangesAsync();

            return goalData;
        }

        private bool GoalDataExists(int id)
        {
            return _context.GoalData.Any(e => e.GoalId == id);
        }
    }
}
