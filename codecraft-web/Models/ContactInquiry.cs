using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace codecraft_web.Models
{
    public class ContactInquiry
    {
        [Key]
        public int Id { get; set; }
        [Required, DataType(DataType.EmailAddress), MaxLength(320)]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } // TIMESTAMP
    }
}
