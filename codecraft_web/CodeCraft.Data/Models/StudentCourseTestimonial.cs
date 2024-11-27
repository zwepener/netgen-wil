using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models
{
    /// <summary>
    /// Represents a student testimonial entity instance.
    /// </summary>
    [Index(nameof(StudentId), nameof(CourseId), IsUnique = true)]
    public class StudentCourseTestimonial
    {
        /// <summary>
        /// The id of this entity.
        /// This property can be used to uniquely identify this entity.
        /// </summary>
        [Display(Name = "Testimonial ID")]
        public int Id { get; set; }
        /// <summary>
        /// The student id of the student this testimonial belongs to.
        /// </summary>
        [Display(Name = "Student ID")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        /// <summary>
        /// The course id of the course this testimonial is directed at.
        /// </summary>
        [Display(Name = "Target Course ID")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        /// <summary>
        /// The comment made by the student towards the course.
        /// </summary>
        [Display(Name = "Comment")]
        public required string Comment { get; set; }
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
