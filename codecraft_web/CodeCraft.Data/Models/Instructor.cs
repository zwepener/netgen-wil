﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models
{
    /// <summary>
    /// Represents a instructor entity instance.
    /// </summary>
    public class Instructor
    {
        /// <summary>
        /// The id of this entity.
        /// This property can be used to uniquely identify this entity.
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// The user id of the instructor.
        /// </summary>
        [Required]
        public string UserId { get; set; } = null!;
        public IdentityUser? User { get; set; }
        /// <summary>
        /// The first name of the instructor.
        /// </summary>
        [MaxLength(32)]
        public string FirstName { get; set; } = null!;
        /// <summary>
        /// The middle name of the instructor. Can be null.
        /// </summary>
        [MaxLength(32)]
        public string? MiddleName { get; set; }
        /// <summary>
        /// The last name of the instructor.
        /// </summary>
        [MaxLength(32)]
        public string LastName { get; set; } = null!;
        /// <summary>
        /// The date of birth of the instructor.
        /// </summary>
        public DateOnly DateOfBirth { get; set; }
        /// <summary>
        /// The field of experties this instructor specializes in.
        /// </summary>
        [MaxLength(32)]
        public string Experties { get; set; } = null!;
        /// <summary>
        /// The amount of experience this instructor of being an instructor.
        /// Measured in <c>Years</c>.
        /// </summary>
        public sbyte Experience { get; set; }
        /// <summary>
        /// A list of courses that this instructor is qualified to teach.
        /// </summary>
        public List<Course> Courses { get; } = [];
        /// <summary>
        /// The date and time this entity was last updated.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }
        /// <summary>
        /// The date and time this entity was created.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }
    }
}
