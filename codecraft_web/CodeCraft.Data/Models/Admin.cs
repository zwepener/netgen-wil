using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models
{
    [Index(nameof(UserId), IsUnique = true)]
    public class Admin
    {
        [Display(Name = "Admin ID")]
        public int Id { get; set; }
        [Display(Name = "User ID")]
        public required string UserId { get; set; }
        public User? User { get; set; }
        [Display(Name = "Updated At")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }
        [Display(Name = "Created At")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }
    }
}
