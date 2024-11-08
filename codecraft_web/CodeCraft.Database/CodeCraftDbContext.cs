using CodeCraft.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodeCraft.Database
{
    public class CodeCraftDbContext : IdentityDbContext<IdentityUser>
    {
        public CodeCraftDbContext(DbContextOptions<CodeCraftDbContext> options)
            : base(options)
        {
        }
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
        }
        public DbSet<CodeCraft.Database.Models.ContactInquiry> ContactInquiry { get; set; } = default!;
        public DbSet<CodeCraft.Database.Models.Course> Course { get; set; } = default!;
        public DbSet<CodeCraft.Database.Models.CourseCategory> CourseCategory { get; set; } = default!;
        public DbSet<CodeCraft.Database.Models.Instructor> Instructor { get; set; } = default!;
        public DbSet<CodeCraft.Database.Models.InstructorTestimonial> InstructorTestimonial { get; set; } = default!;
        public DbSet<CodeCraft.Database.Models.Student> Student { get; set; } = default!;
        public DbSet<CodeCraft.Database.Models.StudentTestimonial> StudentTestimonial { get; set; } = default!;
    }
}
