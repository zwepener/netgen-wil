using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Web.Models
{
    /// <summary>
    /// Represents an instructor testimonial entity instance.
    /// </summary>
    public class InstructorTestimonial
    {
        /// <summary>
        /// The id of this entity.
        /// This property can be used to uniquely identify this entity.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The instructor id of the instructor this testimonial belongs to.
        /// </summary>
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; } = null!;
        /// <summary>
        /// The student id of the student this testimonial is directed at.
        /// </summary>
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        /// <summary>
        /// The comment of the instructor about the specified student.
        /// </summary>
        [MaxLength(255)]
        public string Comment { get; set; } = null!;
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
