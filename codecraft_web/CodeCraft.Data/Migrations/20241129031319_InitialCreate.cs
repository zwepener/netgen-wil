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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                columns: new[] { "Id", "ApplicationCloseDate", "ApplicationOpenDate", "Code", "Description", "DifficultyLevel", "Duration", "Name", "Price", "Technologies", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "PY412", "Explore the basics of computer programming using the Python programming language.", "Beginner", "6m", "Python Basics", 5000m, "Python", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1491) },
                    { 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "PY512", "Explore more advanced computer programming concepts using the Python programming language.", "Intermediate", "6m", "Programming With Python", 5000m, "Python", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1499) },
                    { 3, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "PY522", "Explore the most advanced computer programming concepts using the Python programming language.", "Advanced", "6m", "Advanced Python", 5000m, "Python", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1501) },
                    { 4, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "ML512", "Explore the basics of Machine Learning using the Python programming language.", "Advanced", "6m", "Machine Learning Basics", 5000m, "Python", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1504) },
                    { 5, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "ML522", "Explore the most advanced Machine Learning techniques using the Python programming language.", "Advanced", "6m", "Advanced Machine Learning", 5000m, "Python", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1511) },
                    { 6, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "AI521", "Explore the basics of Arificial Intelligence using the Python programming language.", "Advanced", "6m", "Understanding Arificial Intelligence", 5000m, "Python", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1514) },
                    { 7, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "AI612", "Become a certified Arificial Intelligence Engineer.", "Major", "6m", "Arificial Intelligence Engineering", 5000m, "Python,Java,C++", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1516) },
                    { 8, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "DL612", "Study the concept of Deep Learning, engineering complex deep neural networks that will revolutionize the modern world.", "Major", "6m", "Deep Learning", 5000m, "Python,Java,C++", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1519) },
                    { 9, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "JD412", "Explore the basics of computer programming using the Java programming language.", "Beginner", "6m", "Java Basics", 5000m, "Java", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1521) },
                    { 10, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "JD512", "Explore more advanced computer programming concepts using the Java programming language.", "Intermediate", "6m", "Programming With Java", 5000m, "Java", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1523) },
                    { 11, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "JD522", "Explore the most advanced computer programming concepts using the Java programming language.", "Advanced", "6m", "Advanced Java", 5000m, "Java", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1526) },
                    { 12, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "CWD412", "Build beautiful and responsive websites using HTML, CSS and JavaScript.", "Beginner", "6m", "Core Web Development", 5000m, "HTML,CSS,JavaScript", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1528) },
                    { 13, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "CWD422", "Design mobile-friendly websites using modern CSS techniques.", "Intermediate", "6m", "Modern Web Design", 5000m, "React,Vue,Svelte,Tailwind,Bootstrap,Angular", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1531) },
                    { 14, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "CWD512", "Become a full-stack developer using MongoDB, Express, React, and Node.", "Advanced", "6m", "Full-Stack Web Development", 5000m, "JavaScript,TypeScript,XML,JSON", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1533) },
                    { 15, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "DBQ412", "Master SQL queries to analyze and manipulate data.", "Beginner", "6m", "Database Queries Basics", 5000m, "SQL", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1536) },
                    { 16, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "CPP412", "Explore the basics of computer programming using the C++ programming language.", "Beginner", "6m", "C++ Basics", 5000m, "C++", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1538) },
                    { 17, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "CPP512", "Explore more advanced computer programming concepts using the C++ programming language.", "Intermediate", "6m", "Programming With C++", 5000m, "C++", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1541) },
                    { 18, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "CPP522", "Explore the most advanced computer programming concepts using the C++ programming language.", "Advanced", "6m", "Advanced C++", 5000m, "C++", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1543) },
                    { 19, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "CS512", "Explore the basics of Cyber Security.", "Intermediate", "6m", "Cyber Security Basics", 5000m, "Python,C++", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1546) },
                    { 20, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "CS522", "Explore the most advanced Cyber Security concepts and tecniques.", "Advanced", "6m", "Advanced Cyber Security", 5000m, "C,C++,Assembly,Python", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1548) },
                    { 21, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "AS612", "Become a certified Offensive Security specialist.", "Major", "6m", "Offensive Security", 5000m, "C,C++,Assembly,Python", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1551) },
                    { 22, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "DS612", "Become a certified Defensive Security specialist.", "Major", "6m", "Defensive Security", 5000m, "C,C++,Assembly,Python", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1553) }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Code", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "IT", "Explore a comprehensive range of Information Technology (IT) courses designed to equip learners with the knowledge and skills needed to excel in the dynamic field of IT. Our curriculum spans from fundamental concepts to advanced technical expertise, ensuring a well-rounded understanding of the latest technologies and industry practices.", "Information Technology", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1559) },
                    { 2, "ML", "Explore a comprehensive range of Machine Learning (ML) courses designed to equip learners with the knowledge and skills needed to excel in the dynamic field of Machine Learning. Our curriculum spans from fundamental concepts to advanced technical expertise, ensuring a well-rounded understanding of the latest technologies and industry practices.", "Machine Learning", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1561) },
                    { 3, "CS", "Explore a comprehensive range of Cyber Security (CS) courses designed to equip learners with the knowledge and skills needed to excel in the dynamic field of Cyber Security. Our curriculum spans from fundamental concepts to advanced technical expertise, ensuring a well-rounded understanding of the latest technologies and industry practices.", "Cyber Security", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1563) },
                    { 4, "WD", "Explore a comprehensive range of Web Development (WD) courses designed to equip learners with the knowledge and skills needed to excel in the dynamic field of Web Development. Our curriculum spans from fundamental concepts to advanced technical expertise, ensuring a well-rounded understanding of the latest technologies and industry practices.", "Web Development", new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1564) }
                });

            migrationBuilder.InsertData(
                schema: "AspNetIdentity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhysicalAddress", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { "2f5423d9-3322-438a-b9dc-ec1ffdb3db87", 0, "96909d17-ff56-48f9-892d-2b149fd62b15", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@codecraft.co.za", true, "Jane", "Female", "Smith", false, null, "JANE.SMITH@CODECRAFT.CO.ZA", "JANE.SMITH@CODECRAFT.CO.ZA", "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", null, false, "42 Some St., Cape Town", "bcf3c808-dff1-4b95-8dad-9a4a3fa56339", false, new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1700), "jane.smith@codecraft.co.za" },
                    { "3fe25d09-a2b3-4b40-9fdf-c2b24455411a", 0, "b00dec2a-a93e-48cf-9a5b-4a0d7a9a4834", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "instructor@codecraft.co.za", true, "Instructor", "Male", "Default", false, null, "INSTRUCTOR@CODECRAFT.CO.ZA", "INSTRUCTOR@CODECRAFT.CO.ZA", "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", null, false, "Default Address", "a58f05ed-0854-4b65-8a0b-5514133376e7", false, new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1675), "instructor@codecraft.co.za" },
                    { "40c697c6-41ec-42fd-93c9-5624d377b710", 0, "d1a9157b-0162-4b62-9653-0f909144f70d", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "david.khumalo@codecraft.co.za", true, "David", "Male", "Khumalo", false, null, "DAVID.KHUMALO@CODECRAFT.CO.ZA", "DAVID.KHUMAL@CODECRAFT.CO.ZA", "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", null, false, "42 Some St., Pretoria", "635c655e-27b0-4cb3-9834-223bd8837e2a", false, new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1726), "david.khumal@codecraft.co.za" },
                    { "41edb5b2-3dd8-4c40-b7db-96f609d2fdab", 0, "4f336569-7cf2-4a1f-ac91-a3b32b327b5c", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.johnson@codecraft.co.za", true, "Michael", "Male", "Johnson", false, null, "MICHAEL.JOHNSON@CODECRAFT.CO.ZA", "MICHAEL.JOHNSON@CODECRAFT.CO.ZA", "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", null, false, "42 Some St., Johannesburg", "38593805-10f9-4c50-a6d2-05fd79b8d6bd", false, new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1707), "michael.johnson@codecraft.co.za" },
                    { "757d61fd-6c1c-4e4e-a4f4-8da6a37ff1bb", 0, "83b39022-24d0-4c54-bcb8-7397b5e64763", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "themba.carter@codecraft.co.za", true, "Themba", "Male", "Carter", false, null, "THEMBA.CARTER@CODECRAFT.CO.ZA", "THEMBA.CARTER@CODECRAFT.CO.ZA", "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", null, false, "42 Some St., Port Elizabeth", "3dde98d0-2d01-4252-93ee-ad8580319a97", false, new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1735), "themba.carter@codecraft.co.za" },
                    { "76735e5b-52ef-4c2f-b17b-2456ff4b9556", 0, "7376c397-fd4d-467d-916b-822896cdafbc", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "james.wilson@codecraft.co.za", true, "James", "Male", "Wilson", false, null, "JAMES.WILSON@CODECRAFT.CO.ZA", "JAMES.WILSON@CODECRAFT.CO.ZA", "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", null, false, "42 Some St., Bloemfontein", "b43e4fdc-22da-4dc6-a4a2-d104e47c892b", false, new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1744), "james.wilson@codecraft.co.za" },
                    { "a660cfef-d951-47e4-b40d-2272788f94c1", 0, "65c7e7b5-bbac-4eef-b323-528a55c2a17f", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@codecraft.co.za", true, "Admin", "Male", "Default", false, null, "ADMIN@CODECRAFT.CO.ZA", "ADMIN@CODECRAFT.CO.ZA", "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", null, false, "Default Address", "435faab8-3eaf-47e9-9cb8-6e31aaaaf60a", false, new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1594), "admin@codecraft.co.za" },
                    { "d7574773-b281-4c29-8e6b-bf818d5680a2", 0, "1acf4cae-c4e4-4702-88cf-264cb58e4fa9", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lisa.roberts@codecraft.co.za", true, "Lisa", "Female", "Roberts", false, null, "LISA.ROBERTS@CODECRAFT.CO.ZA", "LISA.ROBERTS@CODECRAFT.CO.ZA", "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", null, false, "42 Some St., Durban", "40cec38a-20e6-4611-9506-d2af5901b471", false, new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1715), "lisa.roberts@codecraft.co.za" },
                    { "efff6fe8-7d05-4adf-8ed1-92ed552c113f", 0, "da3d21f6-4250-41ed-8a64-7e6a77137973", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "student@codecraft.co.za", true, "Student", "Male", "Default", false, null, "STUDENT@CODECRAFT.CO.ZA", "STUDENT@CODECRAFT.CO.ZA", "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", null, false, "Default Address", "85853ff7-962e-4d1f-9e79-f295a0a2492e", false, new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1683), "student@codecraft.co.za" }
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "UpdatedAt", "UserId" },
                values: new object[] { 1, new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1759), "a660cfef-d951-47e4-b40d-2272788f94c1" });

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
                columns: new[] { "Id", "Biography", "Education", "HireDate", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam mattis lacus vitae erat feugiat, quis vestibulum sapien maximus.", "Computer Science, PHD", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1766), "3fe25d09-a2b3-4b40-9fdf-c2b24455411a" },
                    { 2, "Experienced software engineer specializing in Java and Python programming.", "Computer Science, PHD", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1769), "2f5423d9-3322-438a-b9dc-ec1ffdb3db87" },
                    { 3, "Expert in data science and machine learning with 5+ years of teaching experience.", "Computer Science, PHD", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1771), "41edb5b2-3dd8-4c40-b7db-96f609d2fdab" },
                    { 4, "Specializes in web development using React and Node.js. Passionate about mentoring.", "Computer Science, PHD", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1772), "d7574773-b281-4c29-8e6b-bf818d5680a2" },
                    { 5, "Full-stack developer with expertise in PHP and Laravel. Loves teaching coding fundamentals.", "Computer Science, PHD", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1774), "40c697c6-41ec-42fd-93c9-5624d377b710" },
                    { 6, "Creative designer and developer focusing on UI/UX and front-end frameworks like Angular.", "Computer Science, PHD", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1775), "757d61fd-6c1c-4e4e-a4f4-8da6a37ff1bb" },
                    { 7, "Senior software developer with extensive experience in C# and .NET development.", "Computer Science, PHD", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1777), "76735e5b-52ef-4c2f-b17b-2456ff4b9556" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "UpdatedAt", "UserId" },
                values: new object[] { 1, new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1798), "efff6fe8-7d05-4adf-8ed1-92ed552c113f" });

            migrationBuilder.InsertData(
                table: "Enrollment",
                columns: new[] { "CourseId", "StudentId", "AdmitDate", "GraduateDate", "RegisterDate", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1805) },
                    { 2, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1807) },
                    { 3, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1809) },
                    { 4, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1810) },
                    { 5, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1812) },
                    { 6, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1813) },
                    { 7, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1815) },
                    { 8, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1816) },
                    { 9, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1818) },
                    { 10, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1820) },
                    { 11, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1821) },
                    { 12, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1823) },
                    { 13, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1824) },
                    { 14, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1826) },
                    { 15, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1827) },
                    { 16, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1829) },
                    { 17, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1830) },
                    { 18, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1832) },
                    { 19, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1834) },
                    { 20, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1835) },
                    { 21, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1837) },
                    { 22, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 13, 19, 79, DateTimeKind.Utc).AddTicks(1838) }
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
