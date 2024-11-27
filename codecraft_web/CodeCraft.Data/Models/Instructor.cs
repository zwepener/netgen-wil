using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models
{
    /// <summary>
    /// Represents a instructor entity instance.
    /// </summary>
    [Index(nameof(UserId), IsUnique = true)]
    public class Instructor
    {
        /// <summary>
        /// The id of this entity.
        /// This property can be used to uniquely identify this entity.
        /// </summary>
        [Display(Name = "Instructor ID")]
        public int Id { get; set; }
        /// <summary>
        /// The user id of the instructor.
        /// </summary>
        [Display(Name = "User ID")]
        public required string UserId { get; set; }
        public User? User { get; set; }
        /// <summary>
        /// The first name of the instructor.
        /// </summary>
        [Display(Name = "First Name")]
        public required string FirstName { get; set; }
        /// <summary>
        /// The last name of the instructor.
        /// </summary>
        [Display(Name = "Last Name")]
        public required string LastName { get; set; }
        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        [Display(Name = "Gender")]
        public required string Gender { get; set; }
        /// <summary>
        /// The date of birth of the instructor.
        /// </summary>
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
        [Display(Name = "Physical Address")]
        public required string PhysicalAddress { get; set; }
        [Display(Name = "Education")]
        public required string Education { get; set; }
        /// <summary>
        /// The date and time this entity was last updated.
        /// </summary>
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
        /// <summary>
        /// A list of courses that this instructor is qualified to teach.
        /// </summary>
        public List<Course> Courses { get; } = [];
    }
}
