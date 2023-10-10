using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using fortest.Controllers.Module;

namespace fortest.Controllers.StudentModule
{
    public class Students
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StuId { get; set; }
        public string StuName { get; set; }

        public string StuDetails { get; set; }
        
        public Employees Employees { get; set; }
    }
}
