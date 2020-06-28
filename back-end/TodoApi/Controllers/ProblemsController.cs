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
    public class ProblemsController : ControllerBase
    {
        private readonly ProblemContext _context;

        public ProblemsController(ProblemContext context)
        {
            _context = context;
        }

        // GET: api/Problems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Problem>>> GetProblem()
        {
            return await _context.Problem.ToListAsync();
        }

        // GET: api/Problems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Problem>> GetProblem(MentalHealth id)
        {
            var problem = await _context.Problem.FindAsync(id);

            if (problem == null)
            {
                return NotFound();
            }

            return problem;
        }

        // PUT: api/Problems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProblem(MentalHealth id, Problem problem)
        {
            if (id != problem.ProblemId)
            {
                return BadRequest();
            }

            _context.Entry(problem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProblemExists(id))
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

        // POST: api/Problems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Problem>> PostProblem(Problem problem)
        {
            _context.Problem.Add(problem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProblemExists(problem.ProblemId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProblem", new { id = problem.ProblemId }, problem);
        }

        // DELETE: api/Problems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Problem>> DeleteProblem(MentalHealth id)
        {
            var problem = await _context.Problem.FindAsync(id);
            if (problem == null)
            {
                return NotFound();
            }

            _context.Problem.Remove(problem);
            await _context.SaveChangesAsync();

            return problem;
        }

        private bool ProblemExists(MentalHealth id)
        {
            return _context.Problem.Any(e => e.ProblemId == id);
        }
    }
}
