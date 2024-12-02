using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeCraft.Data.Migrations
{
    /// <inheritdoc />
    public partial class StudentCourseTestimonial_AddProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>
            (
                name: "IsFeatured",
                table: "StudentCourseTestimonial",
                type: "bit",
                nullable: false,
                defaultValue: false
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn
            (
                name: "IsFeatured",
                table: "StudentCourseTestimonial"
            );
        }
    }
}
