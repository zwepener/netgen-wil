using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models
{
    /// <summary>
    /// Represents a contact inquiry entity instance.
    /// </summary>
    public class ContactInquiry
    {
        /// <summary>
        /// The id of this entity.
        /// This property can be used to uniquely identify this entity.
        /// </summary>
        [Key]
        [Display(Name = "Inquiry ID")]
        public int Id { get; set; }
        /// <summary>
        /// The contact email address of the person than created the inquiry.
        /// </summary>
        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        /// <summary>
        /// The message content of the inquiry.
        /// </summary>
        [Required]
        [Display(Name = "Inquiry Message")]
        public string Message { get; set; } = null!;
        /// <summary>
        /// The date and time this entity was created.
        /// </summary>
        [Display(Name = "Created At")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }
    }
}
