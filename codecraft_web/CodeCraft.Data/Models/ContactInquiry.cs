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
        public int Id { get; set; }
        /// <summary>
        /// The contact email address of the person than created the inquiry.
        /// </summary>
        [MaxLength(320)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        /// <summary>
        /// The message content of the inquiry.
        /// </summary>
        public string Message { get; set; } = null!;
        /// <summary>
        /// The date and time this entity was created.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }
    }
}
