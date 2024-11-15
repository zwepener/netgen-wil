using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models
{
    /// <summary>
    /// Represents a course entity instance.
    /// </summary>
    public class Course
    {
        /// <summary>
        /// The id of this entity.
        /// This property can be used to uniquely identify this entity.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The name of the course.
        /// </summary>
        [MaxLength(32)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// The description of the course.
        /// </summary>
        public string Description { get; set; } = null!;
        /// <summary>
        /// The duration of the course.
        /// Measured in <c>Hours</c>.
        /// </summary>
        public short Duration { get; set; }
        /// <summary>
        /// The list of categories this course belongs to.
        /// </summary>
        public List<CourseCategory> Categories { get; } = [];
        /// <summary>
        /// The list of instructors that are qualified to teach this course.
        /// </summary>
        public List<Instructor> Instructors { get; } = [];
        /// <summary>
        /// A list of students that are enrolled in this course.
        /// </summary>
        public List<Student> Students { get; } = [];
        /// <summary>
        /// The date and time this entity was last updated.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }
        /// <summary>
        /// The date and time this entity was created.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }
    }
}
