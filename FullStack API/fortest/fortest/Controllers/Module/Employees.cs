using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using fortest.Controllers.StudentModule;

namespace fortest.Controllers.Module
{
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int EmpPhone { get; set; }
        public string Description { get; set; }

        public ICollection<Students> Students { get; set; }  
    }
}
