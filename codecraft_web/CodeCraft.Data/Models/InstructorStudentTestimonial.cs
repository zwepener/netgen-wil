using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models;

[Index(nameof(InstructorId), nameof(StudentId), IsUnique = true)]
public class InstructorStudentTestimonial
{
    ///
    /// Table Columns
    ///

    [Key]
    [Display(Name = "Testimonial ID")]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Instructor ID")]
    public required int InstructorId { get; set; }

    [Required]
    [Display(Name = "Target Student ID")]
    public required int StudentId { get; set; }

    [Required]
    [Display(Name = "Comment")]
    public required string Comment { get; set; }

    [Display(Name = "Updated At")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    [Display(Name = "Created At")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    ///
    /// Relationship Entities
    ///

    [Display(Name = "Instructor")]
    public Instructor? Instructor { get; set; }

    [Display(Name = "Student")]
    public Student? Student { get; set; }

    ///
    /// Custom Properties
    ///

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
