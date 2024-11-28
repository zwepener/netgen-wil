using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodeCraft.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AspNetIdentity");

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Technologies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ApplicationOpenDate = table.Column<DateTime>(type: "date", nullable: false),
                    ApplicationCloseDate = table.Column<DateTime>(type: "date", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inquiry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquiry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "AspNetIdentity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "AspNetIdentity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    PhysicalAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseDepartment",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDepartment", x => new { x.CourseId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_CourseDepartment_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseDepartment_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                schema: "AspNetIdentity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "AspNetIdentity",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "AspNetIdentity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HireDate = table.Column<DateTime>(type: "date", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructor_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "AspNetIdentity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "AspNetIdentity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                schema: "AspNetIdentity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "AspNetIdentity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                schema: "AspNetIdentity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "AspNetIdentity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "AspNetIdentity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "AspNetIdentity",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "AspNetIdentity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                schema: "AspNetIdentity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "AspNetIdentity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorCourse",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorCourse", x => new { x.CourseId, x.InstructorId });
                    table.ForeignKey(
                        name: "FK_InstructorCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorCourse_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "date", nullable: false),
                    AdmitDate = table.Column<DateTime>(type: "date", nullable: false),
                    GraduateDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => new { x.CourseId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_Enrollment_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorStudentTestimonial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorStudentTestimonial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructorStudentTestimonial_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstructorStudentTestimonial_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourseTestimonial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourseTestimonial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCourseTestimonial_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourseTestimonial_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "ApplicationCloseDate", "ApplicationOpenDate", "Code", "Description", "DifficultyLevel", "Duration", "Name", "Price", "Technologies" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "PY412", "Explore the basics of computer programming using the Python programming language.", "Beginner", "6m", "Python Basics", 5000m, "Python" },
                    { 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "PY512", "Explore more advanced computer programming concepts using the Python programming language.", "Intermediate", "6m", "Programming With Python", 5000m, "Python" },
                    { 3, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "PY522", "Explore the most advanced computer programming concepts using the Python programming language.", "Advanced", "6m", "Advanced Python", 5000m, "Python" },
                    { 4, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "ML512", "Explore the basics of Machine Learning using the Python programming language.", "Advanced", "6m", "Machine Learning Basics", 5000m, "Python" },
                    { 5, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "ML522", "Explore the most advanced Machine Learning techniques using the Python programming language.", "Advanced", "6m", "Advanced Machine Learning", 5000m, "Python" },
                    { 6, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "AI521", "Explore the basics of Arificial Intelligence using the Python programming language.", "Advanced", "6m", "Understanding Arificial Intelligence", 5000m, "Python" },
                    { 7, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "AI612", "Become a certified Arificial Intelligence Engineer.", "Major", "6m", "Arificial Intelligence Engineering", 5000m, "Python,Java,C++" },
                    { 8, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "DL612", "Study the concept of Deep Learning, engineering complex deep neural networks that will revolutionize the modern world.", "Major", "6m", "Deep Learning", 5000m, "Python,Java,C++" },
                    { 9, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "JD412", "Explore the basics of computer programming using the Java programming language.", "Beginner", "6m", "Java Basics", 5000m, "Java" },
                    { 10, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "JD512", "Explore more advanced computer programming concepts using the Java programming language.", "Intermediate", "6m", "Programming With Java", 5000m, "Java" },
                    { 11, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "JD522", "Explore the most advanced computer programming concepts using the Java programming language.", "Advanced", "6m", "Advanced Java", 5000m, "Java" },
                    { 12, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "CWD412", "Build beautiful and responsive websites using HTML, CSS and JavaScript.", "Beginner", "6m", "Core Web Development", 5000m, "HTML,CSS,JavaScript" },
                    { 13, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "CWD422", "Design mobile-friendly websites using modern CSS techniques.", "Intermediate", "6m", "Modern Web Design", 5000m, "React,Vue,Svelte,Tailwind,Bootstrap,Angular" },
                    { 14, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "CWD512", "Become a full-stack developer using MongoDB, Express, React, and Node.", "Advanced", "6m", "Full-Stack Web Development", 5000m, "JavaScript,TypeScript,XML,JSON" },
                    { 15, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "DBQ412", "Master SQL queries to analyze and manipulate data.", "Beginner", "6m", "Database Queries Basics", 5000m, "SQL" },
                    { 16, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "CPP412", "Explore the basics of computer programming using the C++ programming language.", "Beginner", "6m", "C++ Basics", 5000m, "C++" },
                    { 17, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "CPP512", "Explore more advanced computer programming concepts using the C++ programming language.", "Intermediate", "6m", "Programming With C++", 5000m, "C++" },
                    { 18, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "CPP522", "Explore the most advanced computer programming concepts using the C++ programming language.", "Advanced", "6m", "Advanced C++", 5000m, "C++" },
                    { 19, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "CS512", "Explore the basics of Cyber Security.", "Intermediate", "6m", "Cyber Security Basics", 5000m, "Python,C++" },
                    { 20, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "CS522", "Explore the most advanced Cyber Security concepts and tecniques.", "Advanced", "6m", "Advanced Cyber Security", 5000m, "C,C++,Assembly,Python" },
                    { 21, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "AS612", "Become a certified Offensive Security specialist.", "Major", "6m", "Offensive Security", 5000m, "C,C++,Assembly,Python" },
                    { 22, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "DS612", "Become a certified Defensive Security specialist.", "Major", "6m", "Defensive Security", 5000m, "C,C++,Assembly,Python" }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Code", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "IT", "Explore a comprehensive range of Information Technology (IT) courses designed to equip learners with the knowledge and skills needed to excel in the dynamic field of IT. Our curriculum spans from fundamental concepts to advanced technical expertise, ensuring a well-rounded understanding of the latest technologies and industry practices.", "Information Technology" },
                    { 2, "ML", "Explore a comprehensive range of Machine Learning (ML) courses designed to equip learners with the knowledge and skills needed to excel in the dynamic field of Machine Learning. Our curriculum spans from fundamental concepts to advanced technical expertise, ensuring a well-rounded understanding of the latest technologies and industry practices.", "Machine Learning" },
                    { 3, "CS", "Explore a comprehensive range of Cyber Security (CS) courses designed to equip learners with the knowledge and skills needed to excel in the dynamic field of Cyber Security. Our curriculum spans from fundamental concepts to advanced technical expertise, ensuring a well-rounded understanding of the latest technologies and industry practices.", "Cyber Security" },
                    { 4, "WD", "Explore a comprehensive range of Web Development (WD) courses designed to equip learners with the knowledge and skills needed to excel in the dynamic field of Web Development. Our curriculum spans from fundamental concepts to advanced technical expertise, ensuring a well-rounded understanding of the latest technologies and industry practices.", "Web Development" }
                });

            migrationBuilder.InsertData(
                schema: "AspNetIdentity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhysicalAddress", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2f5423d9-3322-438a-b9dc-ec1ffdb3db87", 0, "cb0bff40-0e70-4b26-8fb3-d7cf7cb996e6", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@codecraft.co.za", true, "Jane", "Female", "Smith", false, null, "JANE.SMITH@CODECRAFT.CO.ZA", "JANE.SMITH@CODECRAFT.CO.ZA", "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", null, false, "42 Some St., Cape Town", "4a0823f6-24cc-4e1e-bb6f-ff4eb0b64153", false, "jane.smith@codecraft.co.za" },
                    { "3fe25d09-a2b3-4b40-9fdf-c2b24455411a", 0, "7fd3c43f-e81a-4ba8-b789-b0963f7ddd1c", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "instructor@codecraft.co.za", true, "Instructor", "Male", "Default", false, null, "INSTRUCTOR@CODECRAFT.CO.ZA", "INSTRUCTOR@CODECRAFT.CO.ZA", "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", null, false, "Default Address", "8b1635df-d03a-4250-a66d-af170d9ea0bb", false, "instructor@codecraft.co.za" },
                    { "40c697c6-41ec-42fd-93c9-5624d377b710", 0, "ed1febdb-c835-4815-ac44-8b361b094c23", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "david.khumalo@codecraft.co.za", true, "David", "Male", "Khumalo", false, null, "DAVID.KHUMALO@CODECRAFT.CO.ZA", "DAVID.KHUMAL@CODECRAFT.CO.ZA", "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", null, false, "42 Some St., Pretoria", "1b8ff0b5-be47-4ea0-8189-26ae351a32dd", false, "david.khumal@codecraft.co.za" },
                    { "41edb5b2-3dd8-4c40-b7db-96f609d2fdab", 0, "5158c5f7-71bf-4172-b1cb-cf56e782364e", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.johnson@codecraft.co.za", true, "Michael", "Male", "Johnson", false, null, "MICHAEL.JOHNSON@CODECRAFT.CO.ZA", "MICHAEL.JOHNSON@CODECRAFT.CO.ZA", "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", null, false, "42 Some St., Johannesburg", "2269380f-30b6-4d18-a8dc-177e1919e53b", false, "michael.johnson@codecraft.co.za" },
                    { "757d61fd-6c1c-4e4e-a4f4-8da6a37ff1bb", 0, "1fa8b7de-a3af-4ac1-bd6f-8ad9fdedae2d", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "themba.carter@codecraft.co.za", true, "Themba", "Male", "Carter", false, null, "THEMBA.CARTER@CODECRAFT.CO.ZA", "THEMBA.CARTER@CODECRAFT.CO.ZA", "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", null, false, "42 Some St., Port Elizabeth", "5ccafe4f-4f40-4c22-8373-b5621ab8db19", false, "themba.carter@codecraft.co.za" },
                    { "76735e5b-52ef-4c2f-b17b-2456ff4b9556", 0, "ac9ee81c-1e7c-48ad-aa00-1a3a458a7a64", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "james.wilson@codecraft.co.za", true, "James", "Male", "Wilson", false, null, "JAMES.WILSON@CODECRAFT.CO.ZA", "JAMES.WILSON@CODECRAFT.CO.ZA", "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", null, false, "42 Some St., Bloemfontein", "681a333f-960b-4ab6-8d6b-5784ffc42ea3", false, "james.wilson@codecraft.co.za" },
                    { "a660cfef-d951-47e4-b40d-2272788f94c1", 0, "6e7cfd5b-39e1-4d01-bafe-82797dc94370", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@codecraft.co.za", true, "Admin", "Male", "Default", false, null, "ADMIN@CODECRAFT.CO.ZA", "ADMIN@CODECRAFT.CO.ZA", "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", null, false, "Default Address", "59c5acb9-8dc1-42a0-ad58-0dfdfb7905ae", false, "admin@codecraft.co.za" },
                    { "d7574773-b281-4c29-8e6b-bf818d5680a2", 0, "4a209cca-a85a-45e6-b8f0-23fb55da0cfa", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lisa.roberts@codecraft.co.za", true, "Lisa", "Female", "Roberts", false, null, "LISA.ROBERTS@CODECRAFT.CO.ZA", "LISA.ROBERTS@CODECRAFT.CO.ZA", "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", null, false, "42 Some St., Durban", "9490411a-a9f9-4c3e-b24f-5782cd0791e5", false, "lisa.roberts@codecraft.co.za" },
                    { "efff6fe8-7d05-4adf-8ed1-92ed552c113f", 0, "46ab86ff-e807-4bac-8364-488b69e27512", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "student@codecraft.co.za", true, "Student", "Male", "Default", false, null, "STUDENT@CODECRAFT.CO.ZA", "STUDENT@CODECRAFT.CO.ZA", "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", null, false, "Default Address", "2999a4cd-b221-4d3d-b427-5d21e5e499db", false, "student@codecraft.co.za" }
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, "a660cfef-d951-47e4-b40d-2272788f94c1" });

            migrationBuilder.InsertData(
                table: "CourseDepartment",
                columns: new[] { "CourseId", "DepartmentId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 4, 2 },
                    { 5, 1 },
                    { 5, 2 },
                    { 6, 1 },
                    { 6, 2 },
                    { 7, 1 },
                    { 7, 2 },
                    { 8, 1 },
                    { 8, 2 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 12, 1 },
                    { 12, 4 },
                    { 13, 1 },
                    { 13, 4 },
                    { 14, 1 },
                    { 14, 4 },
                    { 15, 1 },
                    { 16, 1 },
                    { 17, 1 },
                    { 18, 1 },
                    { 19, 1 },
                    { 19, 3 },
                    { 20, 1 },
                    { 20, 3 },
                    { 21, 1 },
                    { 21, 3 },
                    { 22, 1 },
                    { 22, 3 }
                });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "Id", "Biography", "Education", "HireDate", "UserId" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam mattis lacus vitae erat feugiat, quis vestibulum sapien maximus.", "Computer Science, PHD", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3fe25d09-a2b3-4b40-9fdf-c2b24455411a" },
                    { 2, "Experienced software engineer specializing in Java and Python programming.", "Computer Science, PHD", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2f5423d9-3322-438a-b9dc-ec1ffdb3db87" },
                    { 3, "Expert in data science and machine learning with 5+ years of teaching experience.", "Computer Science, PHD", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "41edb5b2-3dd8-4c40-b7db-96f609d2fdab" },
                    { 4, "Specializes in web development using React and Node.js. Passionate about mentoring.", "Computer Science, PHD", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d7574773-b281-4c29-8e6b-bf818d5680a2" },
                    { 5, "Full-stack developer with expertise in PHP and Laravel. Loves teaching coding fundamentals.", "Computer Science, PHD", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "40c697c6-41ec-42fd-93c9-5624d377b710" },
                    { 6, "Creative designer and developer focusing on UI/UX and front-end frameworks like Angular.", "Computer Science, PHD", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "757d61fd-6c1c-4e4e-a4f4-8da6a37ff1bb" },
                    { 7, "Senior software developer with extensive experience in C# and .NET development.", "Computer Science, PHD", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "76735e5b-52ef-4c2f-b17b-2456ff4b9556" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, "efff6fe8-7d05-4adf-8ed1-92ed552c113f" });

            migrationBuilder.InsertData(
                table: "Enrollment",
                columns: new[] { "CourseId", "StudentId", "AdmitDate", "GraduateDate", "RegisterDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "InstructorCourse",
                columns: new[] { "CourseId", "InstructorId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 12, 1 },
                    { 13, 1 },
                    { 14, 1 },
                    { 15, 1 },
                    { 16, 1 },
                    { 17, 1 },
                    { 18, 1 },
                    { 19, 1 },
                    { 20, 1 },
                    { 21, 1 },
                    { 22, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_UserId",
                table: "Admin",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_Code",
                table: "Course",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseDepartment_CourseId_DepartmentId",
                table: "CourseDepartment",
                columns: new[] { "CourseId", "DepartmentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseDepartment_DepartmentId",
                table: "CourseDepartment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_Code",
                table: "Department",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_CourseId_StudentId",
                table: "Enrollment",
                columns: new[] { "CourseId", "StudentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_StudentId",
                table: "Enrollment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_UserId",
                table: "Instructor",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructorCourse_CourseId_InstructorId",
                table: "InstructorCourse",
                columns: new[] { "CourseId", "InstructorId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructorCourse_InstructorId",
                table: "InstructorCourse",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorStudentTestimonial_InstructorId_StudentId",
                table: "InstructorStudentTestimonial",
                columns: new[] { "InstructorId", "StudentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructorStudentTestimonial_StudentId",
                table: "InstructorStudentTestimonial",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "AspNetIdentity",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                schema: "AspNetIdentity",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserId",
                table: "Student",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseTestimonial_CourseId",
                table: "StudentCourseTestimonial",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseTestimonial_StudentId_CourseId",
                table: "StudentCourseTestimonial",
                columns: new[] { "StudentId", "CourseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "AspNetIdentity",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "AspNetIdentity",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                schema: "AspNetIdentity",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                schema: "AspNetIdentity",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                schema: "AspNetIdentity",
                table: "UserRole",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "CourseDepartment");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Inquiry");

            migrationBuilder.DropTable(
                name: "InstructorCourse");

            migrationBuilder.DropTable(
                name: "InstructorStudentTestimonial");

            migrationBuilder.DropTable(
                name: "RoleClaim",
                schema: "AspNetIdentity");

            migrationBuilder.DropTable(
                name: "StudentCourseTestimonial");

            migrationBuilder.DropTable(
                name: "UserClaim",
                schema: "AspNetIdentity");

            migrationBuilder.DropTable(
                name: "UserLogin",
                schema: "AspNetIdentity");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "AspNetIdentity");

            migrationBuilder.DropTable(
                name: "UserToken",
                schema: "AspNetIdentity");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "AspNetIdentity");

            migrationBuilder.DropTable(
                name: "User",
                schema: "AspNetIdentity");
        }
    }
}
