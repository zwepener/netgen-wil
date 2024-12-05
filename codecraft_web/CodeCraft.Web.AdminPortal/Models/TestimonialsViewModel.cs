using CodeCraft.Data.Models;

namespace CodeCraft.Web.AdminPortal.Models;

public class TestimonialsViewModel
{
    public List<StudentCourseTestimonial> StudentCourseTestimonials { get; set; } = [];

    public List<StudentCourseTestimonial> FeaturedStudentCourseTestimonials
    {
        get
        {
            return StudentCourseTestimonials.Where(i => i.IsFeatured).ToList();
        }
    }

    public List<InstructorStudentTestimonial> InstructorStudentTestimonials { get; set; } = [];
}