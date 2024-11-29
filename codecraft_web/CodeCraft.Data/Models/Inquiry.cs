using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCraft.Data.Models;

public class Inquiry
{
    ///
    /// Table Columns
    ///

    [Key]
    [Display(Name = "Inquiry ID")]
    public required int Id { get; set; }

    [Required]
    [Display(Name = "From Name")]
    public required string Name { get; set; }

    [Required]
    [Display(Name = "Contact Email")]
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }

    [Required]
    [Display(Name = "Message")]
    public required string Message { get; set; }

    public bool IsResolved { get; set; } = false;

    [Display(Name = "Created At")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    ///
    /// Custom Properties
    ///

    [Display(Name = "Created")]
    public string CreatedAgo
    {
        get
        {
            return Core.Utils.TimeAgo(CreatedAt);
        }
    }
}
