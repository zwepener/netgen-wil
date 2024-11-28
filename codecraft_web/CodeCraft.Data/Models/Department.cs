using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models
{
    [Index(nameof(Code), IsUnique = true)]
    public class Department
    {
        ///
        /// Table Columns
        ///

        [Key]
        [Display(Name = "Department ID")]
        public required int Id { get; set; }

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
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }

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
    }
}
