using CodeCraft.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CodeCraft.Data;

internal class Configurer
{
    internal static IConfigurationRoot GetConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddUserSecrets<CodeCraftDbContext>();
        return builder.Build();
    }
    internal static void RenameDefaultIdentityTables(ModelBuilder builder)
    {
        string schema = "AspNetIdentity";

        builder.Entity<User>(entity =>
        {
            entity.ToTable(name: "User", schema: schema);
        });

        builder.Entity<IdentityRole>(entity =>
        {
            entity.ToTable(name: "Role", schema: schema);
        });

        builder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.ToTable(name: "UserRole", schema: schema);
        });

        builder.Entity<IdentityUserClaim<string>>(entity =>
        {
            entity.ToTable(name: "UserClaim", schema: schema);
        });

        builder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.ToTable(name: "UserLogin", schema: schema);
        });

        builder.Entity<IdentityRoleClaim<string>>(entity =>
        {
            entity.ToTable(name: "RoleClaim", schema: schema);
        });

        builder.Entity<IdentityUserToken<string>>(entity =>
        {
            entity.ToTable(name: "UserToken", schema: schema);
        });
    }
    internal static void SetTableRelationships(ModelBuilder builder)
    {
        builder
            .Entity<Course>()
            .HasMany(e => e.Instructors)
            .WithMany(e => e.Courses)
            .UsingEntity<InstructorCourse>();

        builder
            .Entity<Course>()
            .HasMany(e => e.Students)
            .WithMany(e => e.Courses)
            .UsingEntity<Enrollment>();

        builder
            .Entity<Course>()
            .HasMany(e => e.Departments)
            .WithMany(e => e.Courses)
            .UsingEntity<CourseDepartment>();
    }
    internal static void SetColumnDefaults(ModelBuilder builder)
    {
        builder
            .Entity<Admin>()
            .Property(e => e.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("GETDATE()");

        builder
            .Entity<Course>()
            .Property(e => e.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("GETDATE()");

        builder
            .Entity<Department>()
            .Property(e => e.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("GETDATE()");

        builder
            .Entity<Enrollment>()
            .Property(e => e.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("GETDATE()");

        builder
            .Entity<Inquiry>()
            .Property(e => e.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("GETDATE()");

        builder
            .Entity<Instructor>()
            .Property(e => e.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("GETDATE()");

        builder
            .Entity<InstructorStudentTestimonial>()
            .Property(e => e.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("GETDATE()");

        builder
            .Entity<Student>()
            .Property(e => e.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("GETDATE()");

        builder
            .Entity<StudentCourseTestimonial>()
            .Property(e => e.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("GETDATE()");

        builder
            .Entity<User>()
            .Property(e => e.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("GETDATE()");
    }
    internal static void SetEntitiesDeleteBehavior(ModelBuilder builder)
    {
        builder
            .Entity<InstructorStudentTestimonial>()
            .HasOne(e => e.Student)
            .WithMany()
            .HasForeignKey(t => t.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Entity<InstructorStudentTestimonial>()
            .HasOne(e => e.Instructor)
            .WithMany()
            .HasForeignKey(t => t.InstructorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    internal static void SeedDatabase(ModelBuilder builder)
    {
        List<Course> defaultCourses =
        [
            new Course
            {
                Id = 1,
                Name = "Python Basics",
                Code = "PY412",
                Description = "Explore the basics of computer programming using the Python programming language.",
                DifficultyLevel = "Beginner",
                Technologies = "Python",
                Duration = "6m",
                Price = 5000,
                ApplicationOpenDate = new DateTime(2024, 6, 30),
                ApplicationCloseDate = new DateTime(2024, 12, 31),
            },
            new Course
            {
                Id = 2,
                Name = "Programming With Python",
                Code = "PY512",
                Description = "Explore more advanced computer programming concepts using the Python programming language.",
                DifficultyLevel = "Intermediate",
                Technologies = "Python",
                Duration = "6m",
                Price = 5000,
                ApplicationOpenDate = new DateTime(2024, 6, 30),
                ApplicationCloseDate = new DateTime(2024, 12, 31),
            },
            new Course
            {
                Id = 3,
                Name = "Advanced Python",
                Code = "PY522",
                Description = "Explore the most advanced computer programming concepts using the Python programming language.",
                DifficultyLevel = "Advanced",
                Technologies = "Python",
                Duration = "6m",
                Price = 5000,
                ApplicationOpenDate = new DateTime(2024, 6, 30),
                ApplicationCloseDate = new DateTime(2024, 12, 31),
            },
            new Course
            {
                Id = 4,
                Name = "Machine Learning Basics",
                Code = "ML512",
                Description = "Explore the basics of Machine Learning using the Python programming language.",
                DifficultyLevel = "Advanced",
                Technologies = "Python",
                Duration = "6m",
                Price = 5000,
                ApplicationOpenDate = new DateTime(2024, 6, 30),
                ApplicationCloseDate = new DateTime(2024, 12, 31),
            },
            new Course
            {
                Id = 5,
                Name = "Advanced Machine Learning",
                Code = "ML522",
                Description = "Explore the most advanced Machine Learning techniques using the Python programming language.",
                DifficultyLevel = "Advanced",
                Technologies = "Python",
                Duration = "6m",
                Price = 5000,
                ApplicationOpenDate = new DateTime(2024, 6, 30),
                ApplicationCloseDate = new DateTime(2024, 12, 31),
            },
            new Course
            {
                Id = 6,
                Name = "Understanding Arificial Intelligence",
                Code = "AI521",
                Description = "Explore the basics of Arificial Intelligence using the Python programming language.",
                DifficultyLevel = "Advanced",
                Technologies = "Python",
                Duration = "6m",
                Price = 5000,
                ApplicationOpenDate = new DateTime(2024, 6, 30),
                ApplicationCloseDate = new DateTime(2024, 12, 31),
            },
            new Course
            {
                Id = 7,
                Name = "Arificial Intelligence Engineering",
                Code = "AI612",
                Description = "Become a certified Arificial Intelligence Engineer.",
                DifficultyLevel = "Major",
                Technologies = "Python,Java,C++",
                Duration = "6m",
                Price = 5000,
                ApplicationOpenDate = new DateTime(2024, 6, 30),
                ApplicationCloseDate = new DateTime(2024, 12, 31),
            },
            new Course
            {
                Id = 8,
                Name = "Deep Learning",
                Code = "DL612",
                Description = "Study the concept of Deep Learning, engineering complex deep neural networks that will revolutionize the modern world.",
                DifficultyLevel = "Major",
                Technologies = "Python,Java,C++",
                Duration = "6m",
                Price = 5000,
                ApplicationOpenDate = new DateTime(2024, 6, 30),
                ApplicationCloseDate = new DateTime(2024, 12, 31),
            },
            new Course
            {
                Id = 9,
                Name = "Java Basics",
                Code = "JD412",
                Description = "Explore the basics of computer programming using the Java programming language.",
                DifficultyLevel = "Beginner",
                Technologies = "Java",
                Duration = "6m",
                Price = 5000,
                ApplicationOpenDate = new DateTime(2024, 6, 30),
                ApplicationCloseDate = new DateTime(2024, 12, 31),
            },
            new Course
            {
                Id = 10,
                Name = "Programming With Java",
                Code = "JD512",
                Description = "Explore more advanced computer programming concepts using the Java programming language.",
                DifficultyLevel = "Intermediate",
                Technologies = "Java",
                Duration = "6m",
                Price = 5000,
                ApplicationOpenDate = new DateTime(2024, 6, 30),
                ApplicationCloseDate = new DateTime(2024, 12, 31),
            },
            new Course
            {
                Id = 11,
                Name = "Advanced Java",
                Code = "JD522",
                Description = "Explore the most advanced computer programming concepts using the Java programming language.",
                DifficultyLevel = "Advanced",
                Technologies = "Java",
                Duration = "6m",
                Price = 5000,
                ApplicationOpenDate = new DateTime(2024, 6, 30),
                ApplicationCloseDate = new DateTime(2024, 12, 31),
            },
            new Course
            {
                Id = 12,
                Name = "Core Web Development",
                Code = "CWD412",
                Description = "Build beautiful and responsive websites using HTML, CSS and JavaScript.",
                DifficultyLevel = "Beginner",
                Technologies = "HTML,CSS,JavaScript",
                Duration = "6m",
                Price = 5000,
                ApplicationOpenDate = new DateTime(2024, 6, 30),
                ApplicationCloseDate = new DateTime(2024, 12, 31),
            },
            new Course
            {
                Id = 13,
                Name = "Modern Web Design",
                Code = "CWD422",
                Description = "Design mobile-friendly websites using modern CSS techniques.",
                DifficultyLevel = "Intermediate",
                Technologies = "React,Vue,Svelte,Tailwind,Bootstrap,Angular",
                Duration = "6m",
                Price = 5000,
                ApplicationOpenDate = new DateTime(2024, 6, 30),
                ApplicationCloseDate = new DateTime(2024, 12, 31),
            },
            new Course
            {
                Id = 14,
                Name = "Full-Stack Web Development",
                Code = "CWD512",
                Description = "Become a full-stack developer using MongoDB, Express, React, and Node.",
                DifficultyLevel = "Advanced",
                Technologies = "JavaScript,TypeScript,XML,JSON",
                Duration = "6m",
                Price = 5000,
                ApplicationOpenDate = new DateTime(2024, 6, 30),
                ApplicationCloseDate = new DateTime(2024, 12, 31),
            },
            new Course
            {
                Id = 15,
                Name = "Database Queries Basics",
                Code = "DBQ412",
                Description = "Master SQL queries to analyze and manipulate data.",
                DifficultyLevel = "Beginner",
                Technologies = "SQL",
                Duration = "6m",
                Price = 5000,
                ApplicationOpenDate = new DateTime(2024, 6, 30),
                ApplicationCloseDate = new DateTime(2024, 12, 31),
            },
            new Course
            {
                Id = 16,
                Name = "C++ Basics",
                Code = "CPP412",
                Description = "Explore the basics of computer programming using the C++ programming language.",
                DifficultyLevel = "Beginner",
                Technologies = "C++",
                Duration = "6m",
                Price = 5000,
                ApplicationOpenDate = new DateTime(2024, 6, 30),
                ApplicationCloseDate = new DateTime(2024, 12, 31),
            },
            new Course
            {
                Id = 17,
                Name = "Programming With C++",
                Code = "CPP512",
                Description = "Explore more advanced computer programming concepts using the C++ programming language.",
                DifficultyLevel = "Intermediate",
                Technologies = "C++",
                Duration = "6m",
                Price = 5000,
                ApplicationOpenDate = new DateTime(2024, 6, 30),
                ApplicationCloseDate = new DateTime(2024, 12, 31),
            },
            new Course
            {
                Id = 18,
                Name = "Advanced C++",
                Code = "CPP522",
                Description = "Explore the most advanced computer programming concepts using the C++ programming language.",
                DifficultyLevel = "Advanced",
                Technologies = "C++",
                Duration = "6m",
                Price = 5000,
                ApplicationOpenDate = new DateTime(2024, 6, 30),
                ApplicationCloseDate = new DateTime(2024, 12, 31),
            },
            new Course
            {
                Id = 19,
                Name = "Cyber Security Basics",
                Code = "CS512",
                Description = "Explore the basics of Cyber Security.",
                DifficultyLevel = "Intermediate",
                Technologies = "Python,C++",
                Duration = "6m",
                Price = 5000,
                ApplicationOpenDate = new DateTime(2024, 6, 30),
                ApplicationCloseDate = new DateTime(2024, 12, 31),
            },
            new Course
            {
                Id = 20,
                Name = "Advanced Cyber Security",
                Code = "CS522",
                Description = "Explore the most advanced Cyber Security concepts and tecniques.",
                DifficultyLevel = "Advanced",
                Technologies = "C,C++,Assembly,Python",
                Duration = "6m",
                Price = 5000,
                ApplicationOpenDate = new DateTime(2024, 6, 30),
                ApplicationCloseDate = new DateTime(2024, 12, 31),
            },
            new Course
            {
                Id = 21,
                Name = "Offensive Security",
                Code = "AS612",
                Description = "Become a certified Offensive Security specialist.",
                DifficultyLevel = "Major",
                Technologies = "C,C++,Assembly,Python",
                Duration = "6m",
                Price = 5000,
                ApplicationOpenDate = new DateTime(2024, 6, 30),
                ApplicationCloseDate = new DateTime(2024, 12, 31),
            },
            new Course
            {
                Id = 22,
                Name = "Defensive Security",
                Code = "DS612",
                Description = "Become a certified Defensive Security specialist.",
                DifficultyLevel = "Major",
                Technologies = "C,C++,Assembly,Python",
                Duration = "6m",
                Price = 5000,
                ApplicationOpenDate = new DateTime(2024, 6, 30),
                ApplicationCloseDate = new DateTime(2024, 12, 31),
            }
        ];

        List<Department> defaultDepartments =
        [
            new Department
            {
                Id = 1,
                Name = "Information Technology",
                Code = "IT",
                Description = "Explore a comprehensive range of Information Technology (IT) courses designed to equip learners with the knowledge and skills needed to excel in the dynamic field of IT. Our curriculum spans from fundamental concepts to advanced technical expertise, ensuring a well-rounded understanding of the latest technologies and industry practices."
            },
            new Department
            {
                Id = 2,
                Name = "Machine Learning",
                Code = "ML",
                Description = "Explore a comprehensive range of Machine Learning (ML) courses designed to equip learners with the knowledge and skills needed to excel in the dynamic field of Machine Learning. Our curriculum spans from fundamental concepts to advanced technical expertise, ensuring a well-rounded understanding of the latest technologies and industry practices."
            },
            new Department
            {
                Id = 3,
                Name = "Cyber Security",
                Code = "CS",
                Description = "Explore a comprehensive range of Cyber Security (CS) courses designed to equip learners with the knowledge and skills needed to excel in the dynamic field of Cyber Security. Our curriculum spans from fundamental concepts to advanced technical expertise, ensuring a well-rounded understanding of the latest technologies and industry practices."
            },
            new Department
            {
                Id = 4,
                Name = "Web Development",
                Code = "WD",
                Description = "Explore a comprehensive range of Web Development (WD) courses designed to equip learners with the knowledge and skills needed to excel in the dynamic field of Web Development. Our curriculum spans from fundamental concepts to advanced technical expertise, ensuring a well-rounded understanding of the latest technologies and industry practices."
            },
        ];

        List<CourseDepartment> defaultCourseCategories =
        [
            new CourseDepartment
            {
                CourseId = 1,
                DepartmentId = 1,
            },
            new CourseDepartment
            {
                CourseId = 2,
                DepartmentId = 1,
            },
            new CourseDepartment
            {
                CourseId = 3,
                DepartmentId = 1,
            },
            new CourseDepartment
            {
                CourseId = 4,
                DepartmentId = 1,
            },
            new CourseDepartment
            {
                CourseId = 4,
                DepartmentId = 2,
            },
            new CourseDepartment
            {
                CourseId = 5,
                DepartmentId = 1,
            },
            new CourseDepartment
            {
                CourseId = 5,
                DepartmentId = 2,
            },
            new CourseDepartment
            {
                CourseId = 6,
                DepartmentId = 1,
            },
            new CourseDepartment
            {
                CourseId = 6,
                DepartmentId = 2,
            },
            new CourseDepartment
            {
                CourseId = 7,
                DepartmentId = 1,
            },
            new CourseDepartment
            {
                CourseId = 7,
                DepartmentId = 2,
            },
            new CourseDepartment
            {
                CourseId = 8,
                DepartmentId = 1,
            },
            new CourseDepartment
            {
                CourseId = 8,
                DepartmentId = 2,
            },
            new CourseDepartment
            {
                CourseId = 9,
                DepartmentId = 1,
            },
            new CourseDepartment
            {
                CourseId = 10,
                DepartmentId = 1,
            },
            new CourseDepartment
            {
                CourseId = 11,
                DepartmentId = 1,
            },
            new CourseDepartment
            {
                CourseId = 12,
                DepartmentId = 1,
            },
            new CourseDepartment
            {
                CourseId = 12,
                DepartmentId = 4,
            },
            new CourseDepartment
            {
                CourseId = 13,
                DepartmentId = 1,
            },
            new CourseDepartment
            {
                CourseId = 13,
                DepartmentId = 4,
            },
            new CourseDepartment
            {
                CourseId = 14,
                DepartmentId = 1,
            },
            new CourseDepartment
            {
                CourseId = 14,
                DepartmentId = 4,
            },
            new CourseDepartment
            {
                CourseId = 15,
                DepartmentId = 1,
            },
            new CourseDepartment
            {
                CourseId = 16,
                DepartmentId = 1,
            },
            new CourseDepartment
            {
                CourseId = 17,
                DepartmentId = 1,
            },
            new CourseDepartment
            {
                CourseId = 18,
                DepartmentId = 1,
            },
            new CourseDepartment
            {
                CourseId = 19,
                DepartmentId = 1,
            },
            new CourseDepartment
            {
                CourseId = 19,
                DepartmentId = 3,
            },
            new CourseDepartment
            {
                CourseId = 20,
                DepartmentId = 1,
            },
            new CourseDepartment
            {
                CourseId = 20,
                DepartmentId = 3,
            },
            new CourseDepartment
            {
                CourseId = 21,
                DepartmentId = 1,
            },
            new CourseDepartment
            {
                CourseId = 21,
                DepartmentId = 3,
            },
            new CourseDepartment
            {
                CourseId = 22,
                DepartmentId = 1,
            },
            new CourseDepartment
            {
                CourseId = 22,
                DepartmentId = 3,
            }
        ];

        List<User> defaultUsers =
        [
            new User
            {
                Id = "a660cfef-d951-47e4-b40d-2272788f94c1",
                Email = "admin@codecraft.co.za",
                NormalizedEmail = "ADMIN@CODECRAFT.CO.ZA",
                EmailConfirmed = true,
                UserName = "admin@codecraft.co.za",
                NormalizedUserName = "ADMIN@CODECRAFT.CO.ZA",
                PasswordHash = "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", // 'Password1#'
                FirstName = "Admin",
                LastName = "Default",
                Gender = "Male",
                PhysicalAddress = "Default Address",
                DateOfBirth = new DateTime(1970, 1, 1),
            },
            new User
            {
                Id = "3fe25d09-a2b3-4b40-9fdf-c2b24455411a",
                Email = "instructor@codecraft.co.za",
                NormalizedEmail = "INSTRUCTOR@CODECRAFT.CO.ZA",
                EmailConfirmed = true,
                UserName = "instructor@codecraft.co.za",
                NormalizedUserName = "INSTRUCTOR@CODECRAFT.CO.ZA",
                PasswordHash = "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", // 'Password1#'
                FirstName = "Instructor",
                LastName = "Default",
                Gender = "Male",
                PhysicalAddress = "Default Address",
                DateOfBirth = new DateTime(1970, 1, 1),
            },
            new User
            {
                Id = "efff6fe8-7d05-4adf-8ed1-92ed552c113f",
                Email = "student@codecraft.co.za",
                NormalizedEmail = "STUDENT@CODECRAFT.CO.ZA",
                EmailConfirmed = true,
                UserName = "student@codecraft.co.za",
                NormalizedUserName = "STUDENT@CODECRAFT.CO.ZA",
                PasswordHash = "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", // 'Password1#'
                FirstName = "Student",
                LastName = "Default",
                Gender = "Male",
                PhysicalAddress = "Default Address",
                DateOfBirth = new DateTime(1970, 1, 1),
            },
            new User
            {
                Id = "2f5423d9-3322-438a-b9dc-ec1ffdb3db87",
                Email = "jane.smith@codecraft.co.za",
                NormalizedEmail = "JANE.SMITH@CODECRAFT.CO.ZA",
                EmailConfirmed = true,
                UserName = "jane.smith@codecraft.co.za",
                NormalizedUserName = "JANE.SMITH@CODECRAFT.CO.ZA",
                PasswordHash = "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", // 'Password1#'
                FirstName = "Jane",
                LastName = "Smith",
                Gender = "Female",
                PhysicalAddress = "42 Some St., Cape Town",
                DateOfBirth = new DateTime(1970, 1, 1),
            },
            new User
            {
                Id = "41edb5b2-3dd8-4c40-b7db-96f609d2fdab",
                Email = "michael.johnson@codecraft.co.za",
                NormalizedEmail = "MICHAEL.JOHNSON@CODECRAFT.CO.ZA",
                EmailConfirmed = true,
                UserName = "michael.johnson@codecraft.co.za",
                NormalizedUserName = "MICHAEL.JOHNSON@CODECRAFT.CO.ZA",
                PasswordHash = "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", // 'Password1#'
                FirstName = "Michael",
                LastName = "Johnson",
                Gender = "Male",
                PhysicalAddress = "42 Some St., Johannesburg",
                DateOfBirth = new DateTime(1970, 1, 1),
            },
            new User
            {
                Id = "d7574773-b281-4c29-8e6b-bf818d5680a2",
                Email = "lisa.roberts@codecraft.co.za",
                NormalizedEmail = "LISA.ROBERTS@CODECRAFT.CO.ZA",
                EmailConfirmed = true,
                UserName = "lisa.roberts@codecraft.co.za",
                NormalizedUserName = "LISA.ROBERTS@CODECRAFT.CO.ZA",
                PasswordHash = "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", // 'Password1#'
                FirstName = "Lisa",
                LastName = "Roberts",
                Gender = "Female",
                PhysicalAddress = "42 Some St., Durban",
                DateOfBirth = new DateTime(1970, 1, 1),
            },
            new User
            {
                Id = "40c697c6-41ec-42fd-93c9-5624d377b710",
                Email = "david.khumalo@codecraft.co.za",
                NormalizedEmail = "DAVID.KHUMALO@CODECRAFT.CO.ZA",
                EmailConfirmed = true,
                UserName = "david.khumal@codecraft.co.za",
                NormalizedUserName = "DAVID.KHUMAL@CODECRAFT.CO.ZA",
                PasswordHash = "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", // 'Password1#'
                FirstName = "David",
                LastName = "Khumalo",
                Gender = "Male",
                PhysicalAddress = "42 Some St., Pretoria",
                DateOfBirth = new DateTime(1970, 1, 1),
            },
            new User
            {
                Id = "757d61fd-6c1c-4e4e-a4f4-8da6a37ff1bb",
                Email = "themba.carter@codecraft.co.za",
                NormalizedEmail = "THEMBA.CARTER@CODECRAFT.CO.ZA",
                EmailConfirmed = true,
                UserName = "themba.carter@codecraft.co.za",
                NormalizedUserName = "THEMBA.CARTER@CODECRAFT.CO.ZA",
                PasswordHash = "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", // 'Password1#'
                FirstName = "Themba",
                LastName = "Carter",
                Gender = "Male",
                PhysicalAddress = "42 Some St., Port Elizabeth",
                DateOfBirth = new DateTime(1970, 1, 1),
            },
            new User
            {
                Id = "76735e5b-52ef-4c2f-b17b-2456ff4b9556",
                Email = "james.wilson@codecraft.co.za",
                NormalizedEmail = "JAMES.WILSON@CODECRAFT.CO.ZA",
                EmailConfirmed = true,
                UserName = "james.wilson@codecraft.co.za",
                NormalizedUserName = "JAMES.WILSON@CODECRAFT.CO.ZA",
                PasswordHash = "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==", // 'Password1#'
                FirstName = "James",
                LastName = "Wilson",
                Gender = "Male",
                PhysicalAddress = "42 Some St., Bloemfontein",
                DateOfBirth = new DateTime(1970, 1, 1),
            },
        ];

        List<Admin> defaultAdmins =
        [
            new Admin
            {
                Id = 1,
                UserId = "a660cfef-d951-47e4-b40d-2272788f94c1"
            },
        ];

        List<Instructor> defaultInstructors =
        [
            new Instructor
            {
                Id = 1,
                UserId = "3fe25d09-a2b3-4b40-9fdf-c2b24455411a",
                Biography = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam mattis lacus vitae erat feugiat, quis vestibulum sapien maximus.",
                Education = "Computer Science, PHD",
                HireDate = new DateTime(2024, 1, 1),
            },
            new Instructor
            {
                Id = 2,
                UserId = "2f5423d9-3322-438a-b9dc-ec1ffdb3db87",
                Biography = "Experienced software engineer specializing in Java and Python programming.",
                Education = "Computer Science, PHD",
                HireDate = new DateTime(2024, 1, 1),
            },
            new Instructor
            {
                Id = 3,
                UserId = "41edb5b2-3dd8-4c40-b7db-96f609d2fdab",
                Biography = "Expert in data science and machine learning with 5+ years of teaching experience.",
                Education = "Computer Science, PHD",
                HireDate = new DateTime(2024, 1, 1),
            },
            new Instructor
            {
                Id = 4,
                UserId = "d7574773-b281-4c29-8e6b-bf818d5680a2",
                Biography = "Specializes in web development using React and Node.js. Passionate about mentoring.",
                Education = "Computer Science, PHD",
                HireDate = new DateTime(2024, 1, 1),
            },
            new Instructor
            {
                Id = 5,
                UserId = "40c697c6-41ec-42fd-93c9-5624d377b710",
                Biography = "Full-stack developer with expertise in PHP and Laravel. Loves teaching coding fundamentals.",
                Education = "Computer Science, PHD",
                HireDate = new DateTime(2024, 1, 1),
            },
            new Instructor
            {
                Id = 6,
                UserId = "757d61fd-6c1c-4e4e-a4f4-8da6a37ff1bb",
                Biography = "Creative designer and developer focusing on UI/UX and front-end frameworks like Angular.",
                Education = "Computer Science, PHD",
                HireDate = new DateTime(2024, 1, 1),
            },
            new Instructor
            {
                Id = 7,
                UserId = "76735e5b-52ef-4c2f-b17b-2456ff4b9556",
                Biography = "Senior software developer with extensive experience in C# and .NET development.",
                Education = "Computer Science, PHD",
                HireDate = new DateTime(2024, 1, 1),
            },
        ];

        List<InstructorCourse> defaultInstructorCourses =
        [
            new InstructorCourse
            {
                CourseId = 1,
                InstructorId = 1,
            },
            new InstructorCourse
            {
                CourseId = 2,
                InstructorId = 1,
            },
            new InstructorCourse
            {
                CourseId = 3,
                InstructorId = 1,
            },
            new InstructorCourse
            {
                CourseId = 4,
                InstructorId = 1,
            },
            new InstructorCourse
            {
                CourseId = 5,
                InstructorId = 1,
            },
            new InstructorCourse
            {
                CourseId = 6,
                InstructorId = 1,
            },
            new InstructorCourse
            {
                CourseId = 7,
                InstructorId = 1,
            },
            new InstructorCourse
            {
                CourseId = 8,
                InstructorId = 1,
            },
            new InstructorCourse
            {
                CourseId = 9,
                InstructorId = 1,
            },
            new InstructorCourse
            {
                CourseId = 10,
                InstructorId = 1,
            },
            new InstructorCourse
            {
                CourseId = 11,
                InstructorId = 1,
            },
            new InstructorCourse
            {
                CourseId = 12,
                InstructorId = 1,
            },
            new InstructorCourse
            {
                CourseId = 13,
                InstructorId = 1,
            },
            new InstructorCourse
            {
                CourseId = 14,
                InstructorId = 1,
            },
            new InstructorCourse
            {
                CourseId = 15,
                InstructorId = 1,
            },
            new InstructorCourse
            {
                CourseId = 16,
                InstructorId = 1,
            },
            new InstructorCourse
            {
                CourseId = 17,
                InstructorId = 1,
            },
            new InstructorCourse
            {
                CourseId = 18,
                InstructorId = 1,
            },
            new InstructorCourse
            {
                CourseId = 19,
                InstructorId = 1,
            },
            new InstructorCourse
            {
                CourseId = 20,
                InstructorId = 1,
            },
            new InstructorCourse
            {
                CourseId = 21,
                InstructorId = 1,
            },
            new InstructorCourse
            {
                CourseId = 22,
                InstructorId = 1,
            }
        ];

        List<Student> defaultStudents =
        [
            new Student
            {
                Id = 1,
                UserId = "efff6fe8-7d05-4adf-8ed1-92ed552c113f",
            },
        ];

        List<Enrollment> defaultStudentCourses =
        [
            new Enrollment
            {
                CourseId = 1,
                StudentId = 1,
                RegisterDate = new DateTime(2024, 6, 30),
                AdmitDate = new DateTime(2025, 1, 1),
                GraduateDate = new DateTime(2025, 7, 1),
            },
            new Enrollment
            {
                CourseId = 2,
                StudentId = 1,
                RegisterDate = new DateTime(2024, 6, 30),
                AdmitDate = new DateTime(2025, 1, 1),
                GraduateDate = new DateTime(2025, 7, 1),
            },
            new Enrollment
            {
                CourseId = 3,
                StudentId = 1,
                RegisterDate = new DateTime(2024, 6, 30),
                AdmitDate = new DateTime(2025, 1, 1),
                GraduateDate = new DateTime(2025, 7, 1),
            },
            new Enrollment
            {
                CourseId = 4,
                StudentId = 1,
                RegisterDate = new DateTime(2024, 6, 30),
                AdmitDate = new DateTime(2025, 1, 1),
                GraduateDate = new DateTime(2025, 7, 1),
            },
            new Enrollment
            {
                CourseId = 5,
                StudentId = 1,
                RegisterDate = new DateTime(2024, 6, 30),
                AdmitDate = new DateTime(2025, 1, 1),
                GraduateDate = new DateTime(2025, 7, 1),
            },
            new Enrollment
            {
                CourseId = 6,
                StudentId = 1,
                RegisterDate = new DateTime(2024, 6, 30),
                AdmitDate = new DateTime(2025, 1, 1),
                GraduateDate = new DateTime(2025, 7, 1),
            },
            new Enrollment
            {
                CourseId = 7,
                StudentId = 1,
                RegisterDate = new DateTime(2024, 6, 30),
                AdmitDate = new DateTime(2025, 1, 1),
                GraduateDate = new DateTime(2025, 7, 1),
            },
            new Enrollment
            {
                CourseId = 8,
                StudentId = 1,
                RegisterDate = new DateTime(2024, 6, 30),
                AdmitDate = new DateTime(2025, 1, 1),
                GraduateDate = new DateTime(2025, 7, 1),
            },
            new Enrollment
            {
                CourseId = 9,
                StudentId = 1,
                RegisterDate = new DateTime(2024, 6, 30),
                AdmitDate = new DateTime(2025, 1, 1),
                GraduateDate = new DateTime(2025, 7, 1),
            },
            new Enrollment
            {
                CourseId = 10,
                StudentId = 1,
                RegisterDate = new DateTime(2024, 6, 30),
                AdmitDate = new DateTime(2025, 1, 1),
                GraduateDate = new DateTime(2025, 7, 1),
            },
            new Enrollment
            {
                CourseId = 11,
                StudentId = 1,
                RegisterDate = new DateTime(2024, 6, 30),
                AdmitDate = new DateTime(2025, 1, 1),
                GraduateDate = new DateTime(2025, 7, 1),
            },
            new Enrollment
            {
                CourseId = 12,
                StudentId = 1,
                RegisterDate = new DateTime(2024, 6, 30),
                AdmitDate = new DateTime(2025, 1, 1),
                GraduateDate = new DateTime(2025, 7, 1),
            },
            new Enrollment
            {
                CourseId = 13,
                StudentId = 1,
                RegisterDate = new DateTime(2024, 6, 30),
                AdmitDate = new DateTime(2025, 1, 1),
                GraduateDate = new DateTime(2025, 7, 1),
            },
            new Enrollment
            {
                CourseId = 14,
                StudentId = 1,
                RegisterDate = new DateTime(2024, 6, 30),
                AdmitDate = new DateTime(2025, 1, 1),
                GraduateDate = new DateTime(2025, 7, 1),
            },
            new Enrollment
            {
                CourseId = 15,
                StudentId = 1,
                RegisterDate = new DateTime(2024, 6, 30),
                AdmitDate = new DateTime(2025, 1, 1),
                GraduateDate = new DateTime(2025, 7, 1),
            },
            new Enrollment
            {
                CourseId = 16,
                StudentId = 1,
                RegisterDate = new DateTime(2024, 6, 30),
                AdmitDate = new DateTime(2025, 1, 1),
                GraduateDate = new DateTime(2025, 7, 1),
            },
            new Enrollment
            {
                CourseId = 17,
                StudentId = 1,
                RegisterDate = new DateTime(2024, 6, 30),
                AdmitDate = new DateTime(2025, 1, 1),
                GraduateDate = new DateTime(2025, 7, 1),
            },
            new Enrollment
            {
                CourseId = 18,
                StudentId = 1,
                RegisterDate = new DateTime(2024, 6, 30),
                AdmitDate = new DateTime(2025, 1, 1),
                GraduateDate = new DateTime(2025, 7, 1),
            },
            new Enrollment
            {
                CourseId = 19,
                StudentId = 1,
                RegisterDate = new DateTime(2024, 6, 30),
                AdmitDate = new DateTime(2025, 1, 1),
                GraduateDate = new DateTime(2025, 7, 1),
            },
            new Enrollment
            {
                CourseId = 20,
                StudentId = 1,
                RegisterDate = new DateTime(2024, 6, 30),
                AdmitDate = new DateTime(2025, 1, 1),
                GraduateDate = new DateTime(2025, 7, 1),
            },
            new Enrollment
            {
                CourseId = 21,
                StudentId = 1,
                RegisterDate = new DateTime(2024, 6, 30),
                AdmitDate = new DateTime(2025, 1, 1),
                GraduateDate = new DateTime(2025, 7, 1),
            },
            new Enrollment
            {
                CourseId = 22,
                StudentId = 1,
                RegisterDate = new DateTime(2024, 6, 30),
                AdmitDate = new DateTime(2025, 1, 1),
                GraduateDate = new DateTime(2025, 7, 1),
            }
        ];

        builder.Entity<Course>().HasData(defaultCourses);
        builder.Entity<Department>().HasData(defaultDepartments);
        builder.Entity<CourseDepartment>().HasData(defaultCourseCategories);
        builder.Entity<User>().HasData(defaultUsers);
        builder.Entity<Admin>().HasData(defaultAdmins);
        builder.Entity<Instructor>().HasData(defaultInstructors);
        builder.Entity<InstructorCourse>().HasData(defaultInstructorCourses);
        builder.Entity<Student>().HasData(defaultStudents);
        builder.Entity<Enrollment>().HasData(defaultStudentCourses);
    }
}

public class CodeCraftDbContext(DbContextOptions<CodeCraftDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Admin> Admin { get; set; } = default!;
    public DbSet<Inquiry> Inquiry { get; set; } = default!;
    public DbSet<Course> Course { get; set; } = default!;
    public DbSet<Department> Department { get; set; } = default!;
    public DbSet<CourseDepartment> CourseDepartment { get; set; } = default!;
    public DbSet<Instructor> Instructor { get; set; } = default!;
    public DbSet<InstructorCourse> InstructorCourse { get; set; } = default!;
    public DbSet<InstructorStudentTestimonial> InstructorStudentTestimonial { get; set; } = default!;
    public DbSet<Student> Student { get; set; } = default!;
    public DbSet<Enrollment> Enrollment { get; set; } = default!;
    public DbSet<StudentCourseTestimonial> StudentCourseTestimonial { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var configuration = Configurer.GetConfiguration();

        string? connectionString = (Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING") ?? configuration.GetConnectionString("DefaultConnection")) ?? throw new InvalidOperationException("Connection string not found.");

        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        Configurer.RenameDefaultIdentityTables(modelBuilder);

        Configurer.SetTableRelationships(modelBuilder);

        Configurer.SetColumnDefaults(modelBuilder);

        Configurer.SetEntitiesDeleteBehavior(modelBuilder);

        Configurer.SeedDatabase(modelBuilder);
    }
}
