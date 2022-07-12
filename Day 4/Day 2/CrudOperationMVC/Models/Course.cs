using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOperationMVC.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40, MinimumLength =20)]
        public string CourseName { get; set; }

        [ForeignKey("Department")]
        public int deptId { get; set; }
        public Department Department { get; set; }

        // public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();

        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();

    }
}
