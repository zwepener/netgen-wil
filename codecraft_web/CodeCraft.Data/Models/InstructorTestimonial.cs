using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models
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
        [Key]
        [Display(Name = "Instructor Testimonial ID")]
        public int Id { get; set; }
        /// <summary>
        /// The instructor id of the instructor this testimonial belongs to.
        /// </summary>
        [Required]
        [Display(Name = "Instructor ID")]
        public int InstructorId { get; set; }
        public Instructor? Instructor { get; set; }
        /// <summary>
        /// The student id of the student this testimonial is directed at.
        /// </summary>
        [Required]
        [Display(Name = "Target Student ID")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        /// <summary>
        /// The comment of the instructor about the specified student.
        /// </summary>
        [MaxLength(255)]
        public string Comment { get; set; } = null!;
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
