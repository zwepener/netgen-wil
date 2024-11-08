using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Database.Models
{
    /// <summary>
    /// Represents a course category entity instance.
    /// </summary>
    public class CourseCategory
    {
        /// <summary>
        /// The id of this entity.
        /// This property can be used to uniquely identify this entity.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The name of the category.
        /// </summary>
        [MaxLength(32)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// A list of courses that belong to this category.
        /// </summary>
        public List<Course> Courses { get; } = [];
        /// <summary>
        /// The date and time this entity was last updated.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime UpdatedAt { get; set; }
        /// <summary>
        /// The date and time this entity was created.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }
        
    }
}
