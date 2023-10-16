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
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<List<Employeedetails_DTO>>> GetEmployeesAsync()
        {
            try
            {
                var employees = await (from e in _context.TbEmployee
                                       join d in _context.TbDesignation on e.DeginationId equals d.Id
                                       select new Employeedetails_DTO
                                       {
                                           Id = e.Id,
                                           Name = e.Name,
                                           LastName = e.LastName,
                                           Email = e.Email,
                                           Age = e.Age,
                                           Doj = e.Doj,
                                           Gender = e.Gender,
                                           IsMarried = e.IsMarried,
                                           IsActive = e.IsActive,
                                           DeginationId = e.DeginationId,
                                           Designation = d.Designation,
                                       }).ToListAsync();

                if (employees == null || employees.Count == 0)
                {
                    return NotFound(); // Assuming you are returning an HTTP 404 Not Found status
                }

                return employees;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Internal server error"); // You might want to return a more meaningful error message
            }
        }


        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbEmployee>> GetTbEmployee(int id)
        {
          if (_context.TbEmployee == null)
          {
              return NotFound();
          }
            var tbEmployee = await _context.TbEmployee.FindAsync(id);

            if (tbEmployee == null)
            {
                return NotFound();
            }

            return tbEmployee;
        }

        // PUT: api/Employee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbEmployee(int id, TbEmployee tbEmployee)
        {
            if (id != tbEmployee.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbEmployeeExists(id))
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

        // POST: api/Employee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbEmployee>> PostTbEmployee(TbEmployee tbEmployee)
        {
          if (_context.TbEmployee == null)
          {
              return Problem("Entity set 'EmployeeContext.TbEmployee'  is null.");
          }
            _context.TbEmployee.Add(tbEmployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbEmployee", new { id = tbEmployee.Id }, tbEmployee);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbEmployee(int id)
        {
            if (_context.TbEmployee == null)
            {
                return NotFound();
            }
            var tbEmployee = await _context.TbEmployee.FindAsync(id);
            if (tbEmployee == null)
            {
                return NotFound();
            }

            _context.TbEmployee.Remove(tbEmployee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbEmployeeExists(int id)
        {
            return (_context.TbEmployee?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
