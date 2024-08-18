using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace codecraft_web.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(8), MaxLength(32)]
        public string Username { get; set; }
        [Required, DataType(DataType.Password), MinLength(8)]
        public string Password { get; set; }
        [Required, MaxLength(64)]
        public string FirstName { get; set; }
        [Required, MaxLength(64)]
        public string MiddleName { get; set; }
        [Required, MaxLength(64)]
        public string LastName { get; set; }
        [Required, DataType(DataType.EmailAddress), MaxLength(320)]
        public string Email { get; set; }
        [DataType(DataType.EmailAddress), MaxLength(320)]
        public string? EmailSecondary { get; set; }
        [Required, DataType(DataType.PhoneNumber), MaxLength(64)]
        public string Phone { get; set; }
        [DataType(DataType.PhoneNumber), MaxLength(64)]
        public string? PhoneSecondary { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required, MaxLength(10)]
        public string Gender { get; set; }
        [Required, MaxLength(64)]
        public string Experties { get; set; }
        [Required]
        public int Experience { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } // TIMESTAMP
        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; } // TIMESTAMP
    }
}
