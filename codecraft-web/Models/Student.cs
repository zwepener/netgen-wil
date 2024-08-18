using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codecraft_web.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(8), MaxLength(32)]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, MaxLength(64)]
        public string FirstName { get; set; }
        [MaxLength(64)]
        public string? MiddleName { get; set; }
        [Required, MaxLength(64)]
        public string LastName { get; set; }
        [Required, DataType(DataType.EmailAddress), MaxLength(320)] // RFC 5321 - 5322 standard
        public string Email { get; set; }
        [DataType(DataType.EmailAddress), MaxLength(320)] // RFC 5321 - 5322 standard
        public string? EmailSecondary { get; set; }
        [Required, DataType(DataType.PhoneNumber), MaxLength(24)]
        public string Phone { get; set; }
        [DataType(DataType.PhoneNumber), MaxLength(24)]
        public string? PhoneSecondary { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required, MaxLength(10)]
        public string Gender { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }
    }
}
