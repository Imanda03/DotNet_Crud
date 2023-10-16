using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeginationController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public DeginationController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/Degination
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDegination>>> GetTbDesignation()
        {
          if (_context.TbDesignation == null)
          {
              return NotFound();
          }
            return await _context.TbDesignation.ToListAsync();
        }

        // GET: api/Degination/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDegination>> GetTbDegination(int id)
        {
          if (_context.TbDesignation == null)
          {
              return NotFound();
          }
            var tbDegination = await _context.TbDesignation.FindAsync(id);

            if (tbDegination == null)
            {
                return NotFound();
            }

            return tbDegination;
        }

        // PUT: api/Degination/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDegination(int id, TbDegination tbDegination)
        {
            if (id != tbDegination.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbDegination).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDeginationExists(id))
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

        // POST: api/Degination
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbDegination>> PostTbDegination(TbDegination tbDegination)
        {
          if (_context.TbDesignation == null)
          {
              return Problem("Entity set 'EmployeeContext.TbDesignation'  is null.");
          }
            _context.TbDesignation.Add(tbDegination);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbDegination", new { id = tbDegination.Id }, tbDegination);
        }

        // DELETE: api/Degination/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDegination(int id)
        {
            if (_context.TbDesignation == null)
            {
                return NotFound();
            }
            var tbDegination = await _context.TbDesignation.FindAsync(id);
            if (tbDegination == null)
            {
                return NotFound();
            }

            _context.TbDesignation.Remove(tbDegination);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDeginationExists(int id)
        {
            return (_context.TbDesignation?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
