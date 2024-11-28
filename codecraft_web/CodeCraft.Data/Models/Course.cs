﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models
{
    [Index(nameof(Code), IsUnique = true)]
    public class Course
    {
        ///
        /// Table Columns
        ///

        [Key]
        [Display(Name = "Course ID")]
        public required int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public required string Name { get; set; }

        [Required]
        [Display(Name = "Code")]
        public required string Code { get; set; }

        [Required]
        [Display(Name = "Description")]
        public required string Description { get; set; }

        [Required]
        [Display(Name = "Difficulty Level")]
        public required string DifficultyLevel { get; set; }

        [Required]
        [Display(Name = "Duration")]
        public required string Duration { get; set; }

        [Display(Name = "Technologies")]
        public string? Technologies { get; set; }

        [Required]
        [Precision(18, 2)]
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        public required decimal Price { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [Display(Name = "Application Open Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM, yyyy}")]
        public required DateTime ApplicationOpenDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [Display(Name = "Application Close Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM, yyyy}")]
        public required DateTime ApplicationCloseDate { get; set; }

        [Display(Name = "Updated At")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }

        [Display(Name = "Created At")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        ///
        /// Relationship Entities
        ///

        [Display(Name = "Departments")]
        public List<Department> Departments { get; } = [];

        [Display(Name = "Instructors")]
        public List<Instructor> Instructors { get; } = [];

        [Display(Name = "Students")]
        public List<Student> Students { get; } = [];

        ///
        /// Custom Properties
        ///

        [Display(Name = "Formatted Duration")]
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

        [Display(Name = "Department Count")]
        public int DepartmentCount
        {
            get
            {
                return Departments.Count;
            }
        }

        [Display(Name = "Instructor Count")]
        public int InstructorCount
        {
            get
            {
                return Instructors.Count;
            }
        }

        [Display(Name = "Student Count")]
        public int StudentCount
        {
            get
            {
                return Students.Count;
            }
        }
    }
}
