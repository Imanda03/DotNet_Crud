using fortest.Controllers.Module;
using fortest.Controllers.StudentModule;
using Microsoft.AspNetCore.Mvc;

namespace fortest.Controllers
{
    public class StudentController : ControllerBase
    {
        private readonly StudentsDetails _studentDetails;
        public StudentController(EmployeeDetails studentDetails)
        {
            _studentDetails = studentDetails;
        }

        [HttpGet("/student")]
        public ActionResult<IEnumerable<Students>> GetStudents()
        {
            var students = _studentDetails.GetStudents();
            return Ok(students);
        }

        [HttpGet("/student/{id}")]
        public ActionResult GetStudent(int id)
        {
            var student = _studentDetails.GetStudentById(id);
            return Ok(student);
        }


        [HttpPost("/student")]
        public IActionResult AddStudent([FromBody] Students student)
        {
            _studentDetails.AddStudent(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.StuId });
        }
    }
}
