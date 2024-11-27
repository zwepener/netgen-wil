using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models
{
    /// <summary>
    /// Represents a student entity instance.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// The id of this entity.
        /// This property can be used to uniquely identify this entity.
        /// </summary>
        [Display(Name = "Student ID")]
        public int Id { get; set; }
        /// <summary>
        /// The user id of the student.
        /// </summary>
        [Display(Name = "User ID")]
        public required string UserId { get; set; }
        public User? User { get; set; }
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
        /// A list of courses that the student is enrolled in.
        /// </summary>
        public List<Course> Courses { get; } = [];
        public List<StudentCourseTestimonial> CourseTestimonials { get; } = [];
    }
}
