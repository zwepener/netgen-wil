namespace CodeCraft.Data.Models
{
    public class InstructorCourse
    {
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public int InstructorId { get; set; }
        public Instructor? Instructor { get; set; }
    }
}
