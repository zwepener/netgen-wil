using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Web.Models
{
    /// <summary>
    /// Represents an enrollment entity instance.
    /// </summary>
    public class Enrollment
    {
        /// <summary>
        /// The id of this entity.
        /// This property can be used to uniquely identify this entity.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The enrolled student's student id.
        /// </summary>
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        /// <summary>
        /// The enrollment course's course id.
        /// </summary>
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
        /// <summary>
        /// The date and time this entity was created.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }
    }
}
