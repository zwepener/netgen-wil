﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models
{
    public class Student
    {
        ///
        /// Table Columns
        ///

        [Key]
        [Display(Name = "Student ID")]
        public required int Id { get; set; }

        [Required]
        [Display(Name = "User ID")]
        public required string UserId { get; set; }

        [Display(Name = "Updated At")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }

        [Display(Name = "Created At")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        ///
        /// Relationship Entities
        ///

        [Display(Name = "User")]
        public User? User { get; set;  }

        [Display(Name = "Courses")]
        public List<Course> Courses { get; } = [];

        [Display(Name = "Course Testimonials")]
        public List<StudentCourseTestimonial> CourseTestimonials { get; } = [];

        ///
        /// Custom Properties
        ///

        [Display(Name = "Course Count")]
        public int CourseCount
        {
            get
            {
                return Courses.Count;
            }
        }

        [Display(Name = "Course Testimonial Count")]
        public int CourseTestimonialCount
        {
            get
            {
                return CourseTestimonials.Count;
            }
        }
    }
}
