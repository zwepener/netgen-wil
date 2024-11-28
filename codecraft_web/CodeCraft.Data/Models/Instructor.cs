using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models;

[Index(nameof(UserId), IsUnique = true)]
public class Instructor
{
    ///
    /// Table Columns
    ///

    [Key]
    [Display(Name = "Instructor ID")]
    public required int Id { get; set; }

    [Required]
    [Display(Name = "User ID")]
    public required string UserId { get; set; }

    [Required]
    [Display(Name = "Education")]
    public required string Education { get; set; }

    [Display(Name = "Bio")]
    [DisplayFormat(NullDisplayText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam mattis lacus vitae erat feugiat, quis vestibulum sapien maximus.")]
    public string? Biography { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Column(TypeName = "date")]
    [Display(Name = "Hired Date")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM, yyyy}")]
    public required DateTime HireDate { get; set; }

    [Display(Name = "Updated At")]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }

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

    [Display(Name = "Created")]
    public string CreatedAgo
    {
        get
        {
            return Core.Utils.TimeAgo(CreatedAt);
        }
    }
}
