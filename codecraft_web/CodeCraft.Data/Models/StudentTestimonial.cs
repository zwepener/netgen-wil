﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models
{
    /// <summary>
    /// Represents a student testimonial entity instance.
    /// </summary>
    public class StudentTestimonial
    {
        /// <summary>
        /// The id of this entity.
        /// This property can be used to uniquely identify this entity.
        /// </summary>
        [Key]
        [Display(Name = "Student Testimonial ID")]
        public int Id { get; set; }
        /// <summary>
        /// The student id of the student this testimonial belongs to.
        /// </summary>
        [Required]
        [Display(Name = "Student ID")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        /// <summary>
        /// The course id of the course this testimonial is directed at.
        /// </summary>
        [Required]
        [Display(Name = "Target Course ID")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        /// <summary>
        /// The comment made by the student towards the course.
        /// </summary>
        [MaxLength(255)]
        public string Comment { get; set; } = null!;
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
    }
}