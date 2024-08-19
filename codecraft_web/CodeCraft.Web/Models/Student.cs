﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Web.Models
{
    /// <summary>
    /// Represents a student entity instance.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// The id of this entity.
        /// This property can be used to uniquely identify this entity.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The user id of the student.
        /// </summary>
        public string UserId { get; set; } = null!;
        public IdentityUser User { get; set; } = null!;
        /// <summary>
        /// The first name of the student.
        /// </summary>
        [MaxLength(32)]
        public string FirstName { get; set; } = null!;
        /// <summary>
        /// The middle name of the student.
        /// Can be null.
        /// </summary>
        [MaxLength(32)]
        public string? MiddleName { get; set; }
        /// <summary>
        /// The last name of the student.
        /// </summary>
        [MaxLength(32)]
        public string LastName { get; set; } = null!;
        /// <summary>
        /// The date of birth of the student.
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// The date and time this entity was last updated.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime UpdatedAt { get; set; }
        /// <summary>
        /// The date and time this entity was created.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }
    }
}
