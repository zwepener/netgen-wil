using System.ComponentModel.DataAnnotations;

namespace CodeCraft.Data.Models
{
    public class CourseCategory
    {
        [Required]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
