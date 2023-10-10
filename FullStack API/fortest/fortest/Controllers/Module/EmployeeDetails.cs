using API.Controllers.Models;
using Microsoft.EntityFrameworkCore;

namespace fortest.Controllers.Module
{
    public class EmployeeDetails
    {
        private readonly EmployeeContext _context;

        public EmployeeDetails(EmployeeContext context)
        {
            _context = context;
        }


        //Post
        public void AddEmployee(Employees employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        //Get
        public IEnumerable<Employees> GetEmployees()
        {
            return _context.Employees.Include(a=>a.Students).ToList();
        }

        //Get Single Employee
        public Employees GetEmployeeById(int id) {
            return _context.Employees.Include(a => a.Students).First(a => a.EmpId == id);
        }

        //Update
        public void UpdateEmployee(Employees employees)
        {
            _context.Employees.Update(employees);
            _context.SaveChanges();
        }

        //Delete
        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }
    }
}
