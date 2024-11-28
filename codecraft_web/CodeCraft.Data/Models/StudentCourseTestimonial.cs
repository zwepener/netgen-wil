using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models;

[Index(nameof(StudentId), nameof(CourseId), IsUnique = true)]
public class StudentCourseTestimonial
{
    ///
    /// Table Columns
    ///

    [Key]
    [Display(Name = "Testimonial ID")]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Student ID")]
    public required int StudentId { get; set; }

    [Required]
    [Display(Name = "Target Course ID")]
    public required int CourseId { get; set; }

    [Required]
    [Display(Name = "Comment")]
    public required string Comment { get; set; }

    [Display(Name = "Updated At")]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }

    [Display(Name = "Created At")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    ///
    /// Relationship Entities
    ///

    [Display(Name = "Student")]
    public Student? Student { get; set; }

    [Display(Name = "Course")]
    public Course? Course { get; set; }
}
