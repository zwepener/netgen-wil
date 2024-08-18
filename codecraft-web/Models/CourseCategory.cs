using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace codecraft_web.Models
{
    public class CourseCategory
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(32)]
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        public List<Course> Courses { get; } = [];
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }
    }
}
