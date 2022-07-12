using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudOperationMVC.Migrations
{
    public partial class DepartmentCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "deptId",
                table: "courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_courses_deptId",
                table: "courses",
                column: "deptId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_departments_deptId",
                table: "courses",
                column: "deptId",
                principalTable: "departments",
                principalColumn: "deptId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_departments_deptId",
                table: "courses");

            migrationBuilder.DropIndex(
                name: "IX_courses_deptId",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "deptId",
                table: "courses");
        }
    }
}
