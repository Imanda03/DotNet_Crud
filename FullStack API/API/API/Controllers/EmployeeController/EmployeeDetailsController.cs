using API.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.EmployeeController
{
    [Route("api/[controller]")]
    public class EmployeeDetailsController : Controller
    {
        private readonly EmployeeContext _eContext;
        public EmployeeDetailsController(EmployeeContext eContext) {
            _eContext = eContext;
        }

        //Post : api/addEmployee
        [HttpPost]
        [Route("getData")]
        public async Task<ActionResult<Employees>> AddEmployeeDetail([FromBody] Employees employees)
        {
            if(_eContext.Employees == null)
            {
                return Problem("Entity set 'EmployeeContext.Employees' is null.");
            }
            _eContext.Employees.Add(employees);
            await _eContext.SaveChangesAsync();

            return Ok(await _eContext.Employees.ToListAsync());
        }
    }

}
