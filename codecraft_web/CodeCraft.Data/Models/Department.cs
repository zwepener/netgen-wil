using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models
{
    /// <summary>
    /// Represents a course department entity instance.
    /// </summary>
    [Index(nameof(Code), IsUnique = true)]
    public class Department
    {
        /// <summary>
        /// The id of this entity.
        /// This property can be used to uniquely identify this entity.
        /// </summary>
        [Display(Name = "Department ID")]
        public int Id { get; set; }
        /// <summary>
        /// The name of the department.
        /// </summary>
        [Display(Name = "Name")]
        public required string Name { get; set; }
        [Display(Name = "Code")]
        public required string Code { get; set; }
        [Required]
        [Display(Name = "Description")]
        public required string Description { get; set; }
        /// <summary>
        /// The date and time this entity was last updated.
        /// </summary>
        [Display(Name = "Updated At")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }
        /// <summary>
        /// The date and time this entity was created.
        /// </summary>
        [Display(Name = "Created At")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// A list of courses that belong to this department.
        /// </summary>
        public List<Course> Courses { get; set; } = [];

    }
}
