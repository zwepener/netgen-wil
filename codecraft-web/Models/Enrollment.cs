using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codecraft_web.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Student))]
        public long StudentId { get; set; }
        [ForeignKey(nameof(Course))]
        public long CourseId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
    }
}
