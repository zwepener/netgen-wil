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
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<Course>()
                .Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<Course>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<CourseCategory>()
                .Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<CourseCategory>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<Instructor>()
                .HasIndex(e => e.UserId)
                .IsUnique();

            builder
                .Entity<Instructor>()
                .Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<Instructor>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<InstructorTestimonial>()
                .Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<InstructorTestimonial>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

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

            builder
                .Entity<Student>()
                .HasIndex(e => e.UserId)
                .IsUnique();

            builder
                .Entity<Student>()
                .Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<Student>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<StudentTestimonial>()
                .Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<StudentTestimonial>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<Admin>()
                .HasIndex(e => e.UserId)
                .IsUnique();

            builder
                .Entity<Admin>()
                .Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<Admin>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
        }

        public DbSet<ContactInquiry> ContactInquiry { get; set; } = default!;
        public DbSet<Course> Course { get; set; } = default!;
        public DbSet<CourseCategory> CourseCategory { get; set; } = default!;
        public DbSet<Instructor> Instructor { get; set; } = default!;
        public DbSet<InstructorTestimonial> InstructorTestimonial { get; set; } =
            default!;
        public DbSet<Student> Student { get; set; } = default!;
        public DbSet<StudentTestimonial> StudentTestimonial { get; set; } =
            default!;
        public DbSet<Admin> Admin { get; set; } = default!;
    }
}
