using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codecraft_web.Migrations
{
    /// <inheritdoc />
    public partial class ReCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseCourseCategory",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    CoursesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCourseCategory", x => new { x.CategoriesId, x.CoursesId });
                    table.ForeignKey(
                        name: "FK_CourseCourseCategory_CourseCategory_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "CourseCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseCourseCategory_Course_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseInstructor",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    InstructorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInstructor", x => new { x.CoursesId, x.InstructorsId });
                    table.ForeignKey(
                        name: "FK_CourseInstructor_Course_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseInstructor_Instructor_InstructorsId",
                        column: x => x.InstructorsId,
                        principalTable: "Instructor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseCourseCategory_CoursesId",
                table: "CourseCourseCategory",
                column: "CoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstructor_InstructorsId",
                table: "CourseInstructor",
                column: "InstructorsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseCourseCategory");

            migrationBuilder.DropTable(
                name: "CourseInstructor");
        }
    }
}
