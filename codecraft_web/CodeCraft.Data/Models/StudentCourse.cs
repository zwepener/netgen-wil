﻿using System.ComponentModel.DataAnnotations;

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
    }
}
