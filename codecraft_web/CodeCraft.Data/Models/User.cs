using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models
{
    public class User : IdentityUser
    {
        ///
        /// Table Columns
        ///

        [Required]
        [PersonalData]
        [Display(Name = "First Name")]
        public required string FirstName { get; set; }

        [Required]
        [PersonalData]
        [Display(Name = "Last Name")]
        public required string LastName { get; set; }

        [Required]
        [PersonalData]
        [Display(Name = "Gender")]
        public required string Gender { get; set; }

        [Required]
        [PersonalData]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM, yyyy}")]
        public required DateTime DateOfBirth { get; set; }

        [Required]
        [ProtectedPersonalData]
        [Display(Name = "Physical Address")]
        public required string PhysicalAddress { get; set; }

        ///
        /// Custom Properties
        ///

        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [Display(Name = "Age")]
        public int Age
        {
            get
            {
                return (new DateTime(1, 1, 1) + (DateTime.Today - DateOfBirth)).Year - 1;
            }
        }
    }
}
