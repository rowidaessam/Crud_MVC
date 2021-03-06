// <auto-generated />
using CrudOperationMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CrudOperationMVC.Migrations
{
    [DbContext(typeof(ITIContextDB))]
    [Migration("20220627210112_StudentCoursesManyToMany")]
    partial class StudentCoursesManyToMany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("Studentsid")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "Studentsid");

                    b.HasIndex("Studentsid");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("CrudOperationMVC.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("CrudOperationMVC.Models.Department", b =>
                {
                    b.Property<int>("deptId")
                        .HasColumnType("int");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("deptId");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("CrudOperationMVC.Models.Student", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<int>("deptId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.HasIndex("deptId");

                    b.ToTable("students");
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.HasOne("CrudOperationMVC.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CrudOperationMVC.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("Studentsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CrudOperationMVC.Models.Student", b =>
                {
                    b.HasOne("CrudOperationMVC.Models.Department", "Department")
                        .WithMany("students")
                        .HasForeignKey("deptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("CrudOperationMVC.Models.Department", b =>
                {
                    b.Navigation("students");
                });
#pragma warning restore 612, 618
        }
    }
}
