using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CodeCraft.Web.Models;

namespace CodeCraft.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable(name: "User");
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable(name: "UserRoles");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable(name: "UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable(name: "UserLogins");       
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable(name: "RoleClaims");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable(name: "UserTokens");
            });
        }
        public DbSet<CodeCraft.Web.Models.ContactInquiry> ContactInquiry { get; set; } = default!;
        public DbSet<CodeCraft.Web.Models.Course> Course { get; set; } = default!;
        public DbSet<CodeCraft.Web.Models.CourseCategory> CourseCategory { get; set; } = default!;
        public DbSet<CodeCraft.Web.Models.Enrollment> Enrollment { get; set; } = default!;
        public DbSet<CodeCraft.Web.Models.Instructor> Instructor { get; set; } = default!;
        public DbSet<CodeCraft.Web.Models.InstructorTestimonial> InstructorTestimonial { get; set; } = default!;
        public DbSet<CodeCraft.Web.Models.Student> Student { get; set; } = default!;
        public DbSet<CodeCraft.Web.Models.StudentTestimonial> StudentTestimonial { get; set; } = default!;
    }
}
