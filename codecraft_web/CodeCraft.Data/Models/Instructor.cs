using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models
{
    /// <summary>
    /// Represents a instructor entity instance.
    /// </summary>
    public class Instructor
    {
        /// <summary>
        /// The id of this entity.
        /// This property can be used to uniquely identify this entity.
        /// </summary>
        [Key]
        [Display(Name = "Instructor ID")]
        public int Id { get; set; }
        /// <summary>
        /// The user id of the instructor.
        /// </summary>
        [Required]
        [Display(Name = "User ID")]
        public string UserId { get; set; } = null!;
        public IdentityUser? User { get; set; }
        /// <summary>
        /// The first name of the instructor.
        /// </summary>
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;
        /// <summary>
        /// The last name of the instructor.
        /// </summary>
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; } = null!;
        /// <summary>
        /// The date of birth of the instructor.
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Age")]
        public int Age
        {
            get
            {
                return (new DateTime(1, 1, 1) + (DateTime.Today - DateOfBirth)).Year - 1;
            }
        }
        [Required]
        [Display(Name = "Physical Address")]
        public string PhysicalAddress { get; set; } = null!;
        [Required]
        [Display(Name = "Education")]
        public string Education { get; set; } = null!;
        /// <summary>
        /// A list of courses that this instructor is qualified to teach.
        /// </summary>
        public List<Course> Courses { get; } = [];
        /// <summary>
        /// The date and time this entity was last updated.
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Hired Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime HireDate { get; set; }
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
