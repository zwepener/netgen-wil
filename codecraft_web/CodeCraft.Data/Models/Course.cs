using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models
{
    /// <summary>
    /// Represents a course entity instance.
    /// </summary>
    [Index(nameof(Code), IsUnique = true)]
    public class Course
    {
        /// <summary>
        /// The id of this entity.
        /// This property can be used to uniquely identify this entity.
        /// </summary>
        [Display(Name = "Course ID")]
        public int Id { get; set; }
        /// <summary>
        /// The name of the course.
        /// </summary>
        [Display(Name = "Name")]
        public required string Name { get; set; }
        [Display(Name = "Code")]
        public required string Code { get; set; }
        /// <summary>
        /// The description of the course.
        /// </summary>
        [Display(Name = "Description")]
        public required string Description { get; set; }
        /// <summary>
        /// The duration of the course.
        /// Must be suffixed with:
        /// 'h' for 'hours', 'd' for 'days', 'm' for 'months', 'y' for 'years'.
        /// </summary>
        [Display(Name = "Duration")]
        public required string Duration { get; set; }
        public string FormattedDuration
        {
            get
            {
                Dictionary<char, string> suffixes = [];
                suffixes.Add('h', "Hour(s)");
                suffixes.Add('d', "Day(s)");
                suffixes.Add('m', "Month(s)");
                suffixes.Add('y', "Year(s)");

                string durInt = Duration[..^1];
                char suffix = Duration.Substring(Duration.Length - 1, 1)[0];

                return durInt + " " + suffixes[suffix];
            }
        }
        [Precision(18, 2)]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Student Count")]
        public int StudentCount
        {
            get
            {
                return Students.Count;
            }
        }
        [DataType(DataType.Date)]
        [Display(Name = "Application Open Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ApplicationOpenDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Application Close Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ApplicationCloseDate { get; set; }
        /// <summary>
        /// The date and time this entity was last updated.
        /// </summary>
        [Display(Name = "Updated At")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }
        /// <summary>
        /// The date and time this entity was created.
        /// </summary>
        [Display(Name = "Created At")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// The list of departments this course is apart of.
        /// </summary>
        public List<Department> Categories { get; } = [];
        /// <summary>
        /// The list of instructors that are qualified to teach this course.
        /// </summary>
        public List<Instructor> Instructors { get; } = [];
        /// <summary>
        /// A list of students that are enrolled in this course.
        /// </summary>
        public List<Student> Students { get; } = [];
    }
}
