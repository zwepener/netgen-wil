using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace codecraft_web.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(64)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public short DurationHours { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }
    }
}
