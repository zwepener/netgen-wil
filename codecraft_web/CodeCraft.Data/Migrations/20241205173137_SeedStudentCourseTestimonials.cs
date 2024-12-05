using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodeCraft.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedStudentCourseTestimonials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StudentCourseTestimonial",
                columns: new[] { "Id", "Comment", "CourseId", "IsFeatured", "StudentId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 1, true, 1, new DateTime(2024, 12, 5, 17, 31, 36, 478, DateTimeKind.Utc).AddTicks(8221) },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 2, true, 1, new DateTime(2024, 12, 5, 17, 31, 36, 478, DateTimeKind.Utc).AddTicks(8224) },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 3, true, 1, new DateTime(2024, 12, 5, 17, 31, 36, 478, DateTimeKind.Utc).AddTicks(8225) },
                    { 4, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 4, true, 1, new DateTime(2024, 12, 5, 17, 31, 36, 478, DateTimeKind.Utc).AddTicks(8226) },
                    { 5, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 5, true, 1, new DateTime(2024, 12, 5, 17, 31, 36, 478, DateTimeKind.Utc).AddTicks(8228) },
                    { 6, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 6, true, 1, new DateTime(2024, 12, 5, 17, 31, 36, 478, DateTimeKind.Utc).AddTicks(8229) },
                    { 7, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 7, true, 1, new DateTime(2024, 12, 5, 17, 31, 36, 478, DateTimeKind.Utc).AddTicks(8230) },
                    { 8, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 8, true, 1, new DateTime(2024, 12, 5, 17, 31, 36, 478, DateTimeKind.Utc).AddTicks(8232) },
                    { 9, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 9, true, 1, new DateTime(2024, 12, 5, 17, 31, 36, 478, DateTimeKind.Utc).AddTicks(8233) },
                    { 10, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 10, true, 1, new DateTime(2024, 12, 5, 17, 31, 36, 478, DateTimeKind.Utc).AddTicks(8234) },
                    { 11, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 11, true, 1, new DateTime(2024, 12, 5, 17, 31, 36, 478, DateTimeKind.Utc).AddTicks(8235) },
                    { 12, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 12, true, 1, new DateTime(2024, 12, 5, 17, 31, 36, 478, DateTimeKind.Utc).AddTicks(8237) },
                    { 13, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 13, true, 1, new DateTime(2024, 12, 5, 17, 31, 36, 478, DateTimeKind.Utc).AddTicks(8238) },
                    { 14, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 14, true, 1, new DateTime(2024, 12, 5, 17, 31, 36, 478, DateTimeKind.Utc).AddTicks(8239) },
                    { 15, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 15, true, 1, new DateTime(2024, 12, 5, 17, 31, 36, 478, DateTimeKind.Utc).AddTicks(8241) },
                    { 16, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 16, true, 1, new DateTime(2024, 12, 5, 17, 31, 36, 478, DateTimeKind.Utc).AddTicks(8242) },
                    { 17, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 17, true, 1, new DateTime(2024, 12, 5, 17, 31, 36, 478, DateTimeKind.Utc).AddTicks(8243) },
                    { 18, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 18, true, 1, new DateTime(2024, 12, 5, 17, 31, 36, 478, DateTimeKind.Utc).AddTicks(8245) },
                    { 19, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 19, true, 1, new DateTime(2024, 12, 5, 17, 31, 36, 478, DateTimeKind.Utc).AddTicks(8246) },
                    { 20, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 20, true, 1, new DateTime(2024, 12, 5, 17, 31, 36, 478, DateTimeKind.Utc).AddTicks(8247) },
                    { 21, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 21, true, 1, new DateTime(2024, 12, 5, 17, 31, 36, 478, DateTimeKind.Utc).AddTicks(8249) },
                    { 22, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 22, true, 1, new DateTime(2024, 12, 5, 17, 31, 36, 478, DateTimeKind.Utc).AddTicks(8250) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentCourseTestimonial",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentCourseTestimonial",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentCourseTestimonial",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudentCourseTestimonial",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StudentCourseTestimonial",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StudentCourseTestimonial",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StudentCourseTestimonial",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StudentCourseTestimonial",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StudentCourseTestimonial",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StudentCourseTestimonial",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "StudentCourseTestimonial",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "StudentCourseTestimonial",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "StudentCourseTestimonial",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "StudentCourseTestimonial",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "StudentCourseTestimonial",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "StudentCourseTestimonial",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "StudentCourseTestimonial",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "StudentCourseTestimonial",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "StudentCourseTestimonial",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "StudentCourseTestimonial",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "StudentCourseTestimonial",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "StudentCourseTestimonial",
                keyColumn: "Id",
                keyValue: 22);
        }
    }
}
