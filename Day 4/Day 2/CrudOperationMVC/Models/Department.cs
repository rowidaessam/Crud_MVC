using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOperationMVC.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int deptId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 20)]
        public string DeptName { get; set; }
        public  Department()
        {
            students = new HashSet<Student>();
        }
        public ICollection <Student> students { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
