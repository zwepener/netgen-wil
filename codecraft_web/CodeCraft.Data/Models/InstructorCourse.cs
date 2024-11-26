using System.ComponentModel.DataAnnotations;

namespace CodeCraft.Data.Models
{
    public class InstructorCourse
    {
        [Required]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        [Required]
        public int InstructorId { get; set; }
        public Instructor? Instructor { get; set; }
    }
}
