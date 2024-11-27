using CodeCraft.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodeCraft.Data
{
    internal class Configurer
    {
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
                .UsingEntity<StudentCourse>();

            builder
                .Entity<Course>()
                .HasMany(e => e.Categories)
                .WithMany(e => e.Courses)
                .UsingEntity<CourseCategory>();
        }
        internal static void SetColumnDefaults(ModelBuilder builder)
        {
            // TODO: Add db trigger for computed columns
            // Database does not allow "GETDATE()" on computed columns (e.g., UpdatedAt),
            // won't cause issues, just won't update after initial insert...

            builder
                .Entity<Admin>()
                .Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<Admin>()
                .Property(e => e.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<ContactInquiry>()
                .Property(e => e.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<Course>()
                .Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
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
                .Entity<Department>()
                .Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<Instructor>()
                .Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<Instructor>()
                .Property(e => e.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<InstructorTestimonial>()
                .Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<InstructorTestimonial>()
                .Property(e => e.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<Student>()
                .Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<Student>()
                .Property(e => e.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<StudentCourse>()
                .Property(e => e.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<StudentTestimonial>()
                .Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<StudentTestimonial>()
                .Property(e => e.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");
        }
        internal static void SetColumnConstraints(ModelBuilder builder)
        {
            builder
                .Entity<Admin>()
                .HasIndex(e => e.UserId)
                .IsUnique();

            builder
                .Entity<Instructor>()
                .HasIndex(e => e.UserId)
                .IsUnique();

            builder
                .Entity<Student>()
                .HasIndex(e => e.UserId)
                .IsUnique();
        }
        internal static void SetEntitiesDeleteBehavior(ModelBuilder builder)
        {
            builder
                .Entity<InstructorTestimonial>()
                .HasOne(e => e.Student)
                .WithMany()
                .HasForeignKey(t => t.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<InstructorTestimonial>()
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
                    Name = "Programming With Python",
                    Code = "PRP412",
                    Description = "Learn the basics of how to program with Python.",
                    Duration = "6m",
                    Price = 0,
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
                }
            ];

            List<CourseCategory> defaultCourseCategories =
            [
                new CourseCategory
                {
                    CourseId = 1,
                    DepartmentId = 1,
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
                    PasswordHash = "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==" // 'Password1#'
                },
                new User
                {
                    Id = "3fe25d09-a2b3-4b40-9fdf-c2b24455411a",
                    Email = "instructor@codecraft.co.za",
                    NormalizedEmail = "INSTRUCTOR@CODECRAFT.CO.ZA",
                    EmailConfirmed = true,
                    UserName = "instructor@codecraft.co.za",
                    NormalizedUserName = "INSTRUCTOR@CODECRAFT.CO.ZA",
                    PasswordHash = "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==" // 'Password1#'
                },
                new User
                {
                    Id = "efff6fe8-7d05-4adf-8ed1-92ed552c113f",
                    Email = "student@codecraft.co.za",
                    NormalizedEmail = "STUDENT@CODECRAFT.CO.ZA",
                    EmailConfirmed = true,
                    UserName = "student@codecraft.co.za",
                    NormalizedUserName = "STUDENT@CODECRAFT.CO.ZA",
                    PasswordHash = "AQAAAAIAAYagAAAAEMhCQlGvJ2nIuutdo/24eJEwLaqi5L/1x1GVHoJMAeL6fETW0j+oOg0QS+Te+MI+Aw==" // 'Password1#'
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
                    FirstName = "Instructor",
                    LastName = "Default",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1970, 1, 1),
                    Education = "N/A",
                    HireDate = new DateTime(2024, 1, 1),
                    PhysicalAddress = "N/A",
                },
            ];

            List<InstructorCourse> defaultInstructorCourses =
            [
                new InstructorCourse
                {
                    CourseId = 1,
                    InstructorId = 1,
                }
            ];

            List<Student> defaultStudents =
            [
                new Student
                {
                    Id = 1,
                    UserId = "efff6fe8-7d05-4adf-8ed1-92ed552c113f",
                    FirstName = "Student",
                    LastName = "Default",
                    Gender = "Male",
                    DateOfBirth = new DateTime(2004, 3, 15),
                    PhysicalAddress = "N/A",
                },
            ];

            List<StudentCourse> defaultStudentCourses =
            [
                new StudentCourse
                {
                    CourseId = 1,
                    StudentId = 1,
                    RegisterDate = new DateTime(2024, 6, 30),
                    AdmitDate = new DateTime(2025, 1, 1),
                    GraduateDate = new DateTime(2025, 7, 1),
                }
            ];

            builder.Entity<Course>().HasData(defaultCourses);
            builder.Entity<Department>().HasData(defaultDepartments);
            builder.Entity<CourseCategory>().HasData(defaultCourseCategories);
            builder.Entity<User>().HasData(defaultUsers);
            builder.Entity<Admin>().HasData(defaultAdmins);
            builder.Entity<Instructor>().HasData(defaultInstructors);
            builder.Entity<InstructorCourse>().HasData(defaultInstructorCourses);
            builder.Entity<Student>().HasData(defaultStudents);
            builder.Entity<StudentCourse>().HasData(defaultStudentCourses);
        }
    }
    public class CodeCraftDbContext : IdentityDbContext<User>
    {
        public CodeCraftDbContext(DbContextOptions<CodeCraftDbContext> options) : base(options)
        {
        }

        public DbSet<Admin> Admin { get; set; } = default!;
        public DbSet<ContactInquiry> ContactInquiry { get; set; } = default!;
        public DbSet<Course> Course { get; set; } = default!;
        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<CourseCategory> CourseCategory { get; set; } = default!;
        public DbSet<Instructor> Instructor { get; set; } = default!;
        public DbSet<InstructorCourse> InstructorCourse { get; set; } = default!;
        public DbSet<InstructorTestimonial> InstructorTestimonial { get; set; } = default!;
        public DbSet<Student> Student { get; set; } = default!;
        public DbSet<StudentCourse> StudentCourse { get; set; } = default!;
        public DbSet<StudentTestimonial> StudentTestimonial { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=CodeCraftDB;Trusted_Connection=True;MultipleActiveResultSets=true"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Configurer.RenameDefaultIdentityTables(modelBuilder);

            Configurer.SetTableRelationships(modelBuilder);

            Configurer.SetColumnDefaults(modelBuilder);

            Configurer.SetColumnConstraints(modelBuilder);

            Configurer.SetEntitiesDeleteBehavior(modelBuilder);

            Configurer.SeedDatabase(modelBuilder);
        }
    }
}
