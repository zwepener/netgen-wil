using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codecraft_web.Models
{
    public class StudentTestimonial
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Student))]
        public string StudentId { get; set; }
        [Required, MaxLength(255)]
        public string Comment { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }
    }
}
