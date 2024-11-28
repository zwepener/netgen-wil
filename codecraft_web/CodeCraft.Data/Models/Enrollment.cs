using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models;

[Index(nameof(CourseId), nameof(StudentId), IsUnique = true)]
public class Enrollment
{
    ///
    /// Table Columns
    ///

    [Required]
    public required int CourseId { get; set; }

    [Required]
    public required int StudentId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Column(TypeName = "date")]
    [Display(Name = "Registration Date")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM, yyyy}")]
    public required DateTime RegisterDate { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Column(TypeName = "date")]
    [Display(Name = "Admission Date")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM, yyyy}")]
    public required DateTime AdmitDate { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Column(TypeName = "date")]
    [Display(Name = "Graduation Date")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM, yyyy}")]
    public required DateTime GraduateDate { get; set; }

    [Display(Name = "Created At")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    ///
    /// Relationship Entities
    ///

    [Display(Name = "Course")]
    public Course? Course { get; set; }

    [Display(Name = "Student")]
    public Student? Student { get; set; }

    ///
    /// Custom Properties
    ///

    [Display(Name = "Created")]
    public string CreatedAgo
    {
        get
        {
            return Core.Utils.TimeAgo(CreatedAt);
        }
    }
}
