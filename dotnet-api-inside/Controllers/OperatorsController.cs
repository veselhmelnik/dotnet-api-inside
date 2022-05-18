using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnet_api_inside.Data;
using dotnet_api_inside.Models;

namespace dotnet_api_inside.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OperatorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Operators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operator>>> GetOperators()
        {
          if (_context.Operators == null)
          {
              return NotFound();
          }
            return await _context.Operators.ToListAsync();
        }

        // GET: api/Operators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Operator>> GetOperator(Guid id)
        {
          if (_context.Operators == null)
          {
              return NotFound();
          }
            var @operator = await _context.Operators.FindAsync(id);

            if (@operator == null)
            {
                return NotFound();
            }

            return @operator;
        }

        // PUT: api/Operators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperator(Guid id, Operator @operator)
        {
            if (id != @operator.Id)
            {
                return BadRequest();
            }

            _context.Entry(@operator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperatorExists(id))
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

        // POST: api/Operators
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Operator>> PostOperator(Operator @operator)
        {
          if (_context.Operators == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Operators'  is null.");
          }
            _context.Operators.Add(@operator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperator", new { id = @operator.Id }, @operator);
        }

        // DELETE: api/Operators/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperator(Guid id)
        {
            if (_context.Operators == null)
            {
                return NotFound();
            }
            var @operator = await _context.Operators.FindAsync(id);
            if (@operator == null)
            {
                return NotFound();
            }

            _context.Operators.Remove(@operator);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OperatorExists(Guid id)
        {
            return (_context.Operators?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
