using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models;

[Index(nameof(UserId), IsUnique = true)]
public class Admin
{
    ///
    /// Table Columns
    ///

    [Key]
    [Display(Name = "Admin ID")]
    public required int Id { get; set; }

    [Required]
    [Display(Name = "User ID")]
    public required string UserId { get; set; }

    [Display(Name = "Updated At")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    [Display(Name = "Created At")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    ///
    /// Relationship Entities
    ///

    [Display(Name = "User")]
    public User? User { get; set; }

    ///
    /// Custom Properties
    ///

    [Display(Name = "Last Updated")]
    public string UpdatedAgo
    {
        get
        {
            return Core.Utils.TimeAgo(UpdatedAt);
        }
    }

    [Display(Name = "Created")]
    public string CreatedAgo
    {
        get
        {
            return Core.Utils.TimeAgo(CreatedAt);
        }
    }
}
