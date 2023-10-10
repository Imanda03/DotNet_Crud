using API.Controllers.Models;
using fortest.Controllers.Module;
using Microsoft.EntityFrameworkCore;

namespace fortest.Controllers.StudentModule
{
    public class StudentsDetails
    {
        private readonly EmployeeContext _studentContext;

        public StudentsDetails(EmployeeContext studentContext)
        {
            _studentContext = studentContext;
        }

        //Post
        public void AddStudent(Students students)
        {
            _studentContext.Students.Add(students);
            _studentContext.SaveChanges();
        }

        //Get single student
        public Students GetStudentById(int id)
        {
            return _studentContext.Students.First(b => b.StuId == id);
        }

        //Get
        public IEnumerable<Students> GetStudents()
        {
            return _studentContext.Students.ToList();
        }

        public static implicit operator StudentsDetails(EmployeeDetails v)
        {
            throw new NotImplementedException();
        }
    }
}
