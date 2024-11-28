using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CodeCraft.Data.Models
{
    [Index(nameof(CourseId), nameof(InstructorId), IsUnique = true)]
    public class InstructorCourse
    {
        ///
        /// Table Columns
        ///

        [Required]
        [Display(Name = "Course ID")]
        public required int CourseId { get; set; }


        [Required]
        [Display(Name = "Instructor ID")]
        public required int InstructorId { get; set; }


        ///
        /// Relationship Entities
        ///

        [Display(Name = "Course")]
        public Course? Course { get; set;  }

        [Display(Name = "Instructor")]
        public Instructor? Instructor { get; set; }
    }
}
