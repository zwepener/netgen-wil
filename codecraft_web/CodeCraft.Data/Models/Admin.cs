using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models
{
    public class Admin
    {
        [Key]
        [Display(Name = "Admin ID")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "User ID")]
        public string UserId { get; set; } = null!;
        public User? User { get; set; }
        [Display(Name = "Updated At")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }
        [Display(Name = "Created At")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }
    }
}
