using fortest.Controllers.Module;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fortest.Controllers
{
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDetails _employeeDetails;
        public EmployeesController(EmployeeDetails employeeDetails) { 
            _employeeDetails = employeeDetails;
        }

         

        [HttpGet("")]
        public ActionResult<IEnumerable<Employees>> GetEmployees()
        {
            var employees = _employeeDetails.GetEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult GetEmployeeById(int id)
        {
            var employee = _employeeDetails.GetEmployeeById(id);

      /*      if(employee == null)
            {
                throw new Exception("Employee Not Found");
            }*/

            return Ok(employee);
        }



        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employees employee) {
            if(id != employee.EmpId)
            {
                throw new Exception("Employee Not Found");
            }   
            _employeeDetails.UpdateEmployee(employee);
            return NoContent();
        }

        [HttpPost("")]

        public IActionResult AddEmployee([FromBody] Employees employee)
        {
            _employeeDetails.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.EmpId });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            _employeeDetails.DeleteEmployee(id);
            return NoContent();
        }
    }
}
