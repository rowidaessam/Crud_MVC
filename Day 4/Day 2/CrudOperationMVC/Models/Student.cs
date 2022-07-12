using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOperationMVC.Models
{
    public class Student
    {
        public int id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 20)]
        public string name { get; set; }
        [Range(20,40)]
        public int age { get; set; }
        //[Required(ErrorMessage = "Please Choose Student Image")]
        //[Display(Name = "Student Image")]
        //[NotMapped]
        //public IFormFile formFile { get; set; }
        [ForeignKey("Department")]
        public int deptId { get; set; }
        public Department Department { get; set; }
        //public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
        
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();

    }
}
