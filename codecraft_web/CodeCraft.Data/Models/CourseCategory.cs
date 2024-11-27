namespace CodeCraft.Data.Models
{
    public class CourseCategory
    {
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
