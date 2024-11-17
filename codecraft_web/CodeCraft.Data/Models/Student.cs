using Microsoft.AspNetCore.Identity;
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
        [Key]
        [Display(Name = "Student ID")]
        public int Id { get; set; }
        /// <summary>
        /// The user id of the student.
        /// </summary>
        [Required]
        [Display(Name = "User ID")]
        public string UserId { get; set; } = null!;
        public IdentityUser? User { get; set; }
        /// <summary>
        /// The first name of the student.
        /// </summary>
        [MaxLength(32)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;
        /// <summary>
        /// The middle name of the student.
        /// Can be null.
        /// </summary>
        [MaxLength(32)]
        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }
        /// <summary>
        /// The last name of the student.
        /// </summary>
        [MaxLength(32)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;
        /// <summary>
        /// A list of courses that the student is enrolled in.
        /// </summary>
        public List<Course> Courses { get; } = [];
        /// <summary>
        /// The date of birth of the student.
        /// </summary>
        [Display(Name = "Date of Birth")]
        public DateOnly DateOfBirth { get; set; }
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
