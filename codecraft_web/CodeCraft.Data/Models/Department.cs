using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models
{
    /// <summary>
    /// Represents a course department entity instance.
    /// </summary>
    public class Department
    {
        /// <summary>
        /// The id of this entity.
        /// This property can be used to uniquely identify this entity.
        /// </summary>
        [Key]
        [Display(Name = "Department ID")]
        public int Id { get; set; }
        /// <summary>
        /// The name of the department.
        /// </summary>
        [Required]
        [Display(Name = "Department Name")]
        public string Name { get; set; } = null!;
        [Required]
        [Display(Name = "Department Code")]
        public string Code { get; set; } = null!;
        /// <summary>
        /// A list of courses that belong to this department.
        /// </summary>
        public List<Course> Courses { get; set; } = [];
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

    }
}
