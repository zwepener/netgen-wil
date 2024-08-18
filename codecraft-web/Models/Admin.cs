using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace codecraft_web.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(8), MaxLength(32)]
        public string Username { get; set; }
        [Required, DataType(DataType.Password), MinLength(8)]
        public string Password { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }
    }
}
