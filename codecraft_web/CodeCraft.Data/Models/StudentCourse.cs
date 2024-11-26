using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models
{
    public class StudentCourse
    {
        [Required]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        [Required]
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Registration Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RegisterDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Admission Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AdmitDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Graduation Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime GraduateDate { get; set; }
        [Display(Name = "Created At")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }
    }
}
