using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CodeCraft.Data.Models;

[Index(nameof(CourseId), nameof(DepartmentId), IsUnique = true)]
public class CourseDepartment
{
    ///
    /// Table Columns
    ///

    [Required]
    [Display(Name = "Course ID")]
    public required int CourseId { get; set; }

    [Required]
    [Display(Name = "Department ID")]
    public required int DepartmentId { get; set; }

    ///
    /// Relationship Entities
    ///

    [Display(Name = "Course")]
    public Course? Course { get; set; }

    [Display(Name = "Department")]
    public Department? Department { get; set; }
}
