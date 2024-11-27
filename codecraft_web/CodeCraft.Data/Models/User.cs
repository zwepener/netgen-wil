using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CodeCraft.Data.Models
{
    public class User : IdentityUser
    {
        [PersonalData]
        [Display(Name = "First Name")]
        public required string FirstName { get; set; }
        [PersonalData]
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
        [PersonalData]
        [Display(Name = "Gender")]
        public required string Gender { get; set; }
        [PersonalData]
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
        [ProtectedPersonalData]
        [Display(Name = "Physical Address")]
        public required string PhysicalAddress { get; set; }
    }
}
