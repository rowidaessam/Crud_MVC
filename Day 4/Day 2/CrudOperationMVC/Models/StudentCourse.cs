namespace CrudOperationMVC.Models
{
    public class StudentCourse
    {
        public int StudentID { get; set; } 
        public int CourseID { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        public int Grade { get; set; }
    }
}
