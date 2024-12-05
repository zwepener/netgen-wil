using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models;

[Index(nameof(Code), IsUnique = true)]
public class Department
{
    ///
    /// Table Columns
    ///

    [Key]
    [Display(Name = "Department ID")]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Name")]
    public required string Name { get; set; }

    [Required]
    [Display(Name = "Code")]
    public required string Code { get; set; }

    [Required]
    [Display(Name = "Description")]
    public required string Description { get; set; }

    [Display(Name = "Updated At")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    [Display(Name = "Created At")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    ///
    /// Relationship Entities
    ///

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
