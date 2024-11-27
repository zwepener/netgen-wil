using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models
{
    /// <summary>
    /// Represents an instructor testimonial entity instance.
    /// </summary>
    [Index(nameof(InstructorId), nameof(StudentId), IsUnique = true)]
    public class InstructorStudentTestimonial
    {
        /// <summary>
        /// The id of this entity.
        /// This property can be used to uniquely identify this entity.
        /// </summary>
        [Display(Name = "Testimonial ID")]
        public int Id { get; set; }
        /// <summary>
        /// The instructor id of the instructor this testimonial belongs to.
        /// </summary>
        [Display(Name = "Instructor ID")]
        public int InstructorId { get; set; }
        public Instructor? Instructor { get; set; }
        /// <summary>
        /// The student id of the student this testimonial is directed at.
        /// </summary>
        [Display(Name = "Target Student ID")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        /// <summary>
        /// The comment of the instructor about the specified student.
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
