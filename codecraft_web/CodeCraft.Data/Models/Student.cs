using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models;

[Index(nameof(UserId), IsUnique = true)]
public class Student
{
    ///
    /// Table Columns
    ///

    [Key]
    [Display(Name = "Student ID")]
    public int Id { get; set; }

    [Required]
    [Display(Name = "User ID")]
    public required string UserId { get; set; }

    [Display(Name = "Updated At")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    [Display(Name = "Created At")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    ///
    /// Relationship Entities
    ///

    [Display(Name = "User")]
    public User? User { get; set; }

    [Display(Name = "Courses")]
    public List<Course> Courses { get; } = [];

    [Display(Name = "Course Testimonials")]
    public List<StudentCourseTestimonial> CourseTestimonials { get; } = [];

    ///
    /// Custom Properties
    ///

    [Display(Name = "Course Count")]
    public int CourseCount
    {
        get
        {
            return Courses.Count;
        }
    }

    [Display(Name = "Course Testimonial Count")]
    public int CourseTestimonialCount
    {
        get
        {
            return CourseTestimonials.Count;
        }
    }

    [Display(Name = "Last Updated")]
    public string UpdatedAgo
    {
        get
        {
            return Core.Utils.TimeAgo(UpdatedAt);
        }
    }

    [Display(Name = "Created")]
    public string CreatedAgo
    {
        get
        {
            return Core.Utils.TimeAgo(CreatedAt);
        }
    }
}
