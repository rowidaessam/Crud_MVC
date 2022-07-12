using CrudOperationMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudOperationMVC.Data
{
    public class ITIContextDB:DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(StdCour => new { StdCour.StudentID, StdCour.CourseID });

            modelBuilder.Entity<Student>()
              .HasMany(std => std.StudentCourses)
              .WithOne(e => e.Student);

            modelBuilder.Entity<Course>()
                .HasMany(sub => sub.StudentCourses)
                .WithOne(stdsub => stdsub.Course);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=ITIContextDB; Integrated security=true ");
            optionsBuilder.UseSqlServer("Server=.;Database=ITIContextDB; Trusted_Connection=true;");
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Student> students { get; set; }
        public virtual DbSet<Department> departments { get; set; }
        public virtual DbSet<Course> courses { get; set; }
    }
}
