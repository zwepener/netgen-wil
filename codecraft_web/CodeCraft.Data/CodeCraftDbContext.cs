using CodeCraft.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodeCraft.Data
{
    public class CodeCraftDbContext : IdentityDbContext<IdentityUser>
    {
        public CodeCraftDbContext(DbContextOptions<CodeCraftDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            string schema = "AspNetIdentity";

            builder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable(name: "User", schema: schema);
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role", schema: schema);
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable(name: "UserRoles", schema: schema);
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable(name: "UserClaims", schema: schema);
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable(name: "UserLogins", schema: schema);
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable(name: "RoleClaims", schema: schema);
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable(name: "UserTokens", schema: schema);
            });

            builder
                .Entity<ContactInquiry>()
                .Property(entity => entity.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<Course>()
                .Property(entity => entity.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<Course>()
                .Property(entity => entity.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<CourseCategory>()
                .Property(entity => entity.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<CourseCategory>()
                .Property(entity => entity.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<Instructor>()
                .Property(entity => entity.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<Instructor>()
                .Property(entity => entity.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<InstructorTestimonial>()
                .Property(entity => entity.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<InstructorTestimonial>()
                .Property(entity => entity.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<InstructorTestimonial>()
                .HasOne(t => t.Student)
                .WithMany()
                .HasForeignKey(t => t.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<InstructorTestimonial>()
                .HasOne(t => t.Instructor)
                .WithMany()
                .HasForeignKey(t => t.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Student>()
                .Property(entity => entity.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<Student>()
                .Property(entity => entity.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<StudentTestimonial>()
                .Property(entity => entity.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<StudentTestimonial>()
                .Property(entity => entity.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
        }

        public DbSet<CodeCraft.Data.Models.ContactInquiry> ContactInquiry { get; set; } = default!;
        public DbSet<CodeCraft.Data.Models.Course> Course { get; set; } = default!;
        public DbSet<CodeCraft.Data.Models.CourseCategory> CourseCategory { get; set; } = default!;
        public DbSet<CodeCraft.Data.Models.Instructor> Instructor { get; set; } = default!;
        public DbSet<CodeCraft.Data.Models.InstructorTestimonial> InstructorTestimonial { get; set; } =
            default!;
        public DbSet<CodeCraft.Data.Models.Student> Student { get; set; } = default!;
        public DbSet<CodeCraft.Data.Models.StudentTestimonial> StudentTestimonial { get; set; } =
            default!;
    }
}
