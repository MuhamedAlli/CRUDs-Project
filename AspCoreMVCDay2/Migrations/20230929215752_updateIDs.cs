using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspCoreMVCDay2.Migrations
{
    /// <inheritdoc />
    public partial class updateIDs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseResults_Courses_CoursesID",
                table: "CourseResults");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Departments",
                newName: "DepartmentID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Courses",
                newName: "CourseID");

            migrationBuilder.RenameColumn(
                name: "CoursesID",
                table: "CourseResults",
                newName: "CoursesCourseID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseResults_CoursesID",
                table: "CourseResults",
                newName: "IX_CourseResults_CoursesCourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseResults_Courses_CoursesCourseID",
                table: "CourseResults",
                column: "CoursesCourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseResults_Courses_CoursesCourseID",
                table: "CourseResults");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "Departments",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Courses",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "CoursesCourseID",
                table: "CourseResults",
                newName: "CoursesID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseResults_CoursesCourseID",
                table: "CourseResults",
                newName: "IX_CourseResults_CoursesID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseResults_Courses_CoursesID",
                table: "CourseResults",
                column: "CoursesID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
