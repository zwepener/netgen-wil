using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using codecraft_web.Models;

namespace codecraft_web.Data
{
    public class codecraft_webDBContext : DbContext
    {
        public codecraft_webDBContext (DbContextOptions<codecraft_webDBContext> options)
            : base(options)
        {
        }

        public DbSet<codecraft_web.Models.Student> Student { get; set; } = default!;
        public DbSet<codecraft_web.Models.Instructor> Instructor { get; set; } = default!;
        public DbSet<codecraft_web.Models.Admin> Admin { get; set; } = default!;
        public DbSet<codecraft_web.Models.ContactInquiry> ContactInquiry { get; set; } = default!;
        public DbSet<codecraft_web.Models.Course> Course { get; set; } = default!;
        public DbSet<codecraft_web.Models.CourseCategory> CourseCategory { get; set; } = default!;
        public DbSet<codecraft_web.Models.Enrollment> Enrollment { get; set; } = default!;
        public DbSet<codecraft_web.Models.InstructorTestimonial> InstructorTestimonial { get; set; } = default!;
        public DbSet<codecraft_web.Models.StudentTestimonial> StudentTestimonial { get; set; } = default!;
    }
}
