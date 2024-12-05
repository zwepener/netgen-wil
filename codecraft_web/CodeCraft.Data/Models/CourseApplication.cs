using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models;

[Index(nameof(CourseId), nameof(Email), IsUnique = true)]
public class CourseApplication
{
    ///
    /// Table Columns
    ///

    [Key]
    [Display(Name = "Application ID")]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Course ID")]
    public int CourseId { get; set; }

    [Required]
    [Display(Name = "Name")]
    public string Name { get; set; } = null!;

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    ///
    /// Relationship Entities
    ///

    [Display(Name = "Course")]
    public Course? Course { get; set; }

    [Display(Name = "Created At")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }
}