using System.ComponentModel.DataAnnotations;

namespace CodeCraft.Web.AdminPortal.Models;

public class BreadCrumbViewModel
{
    [Required]
    public required string Header { get; set; }

    [Required]
    public required string SectionName { get; set; }

    [Required]
    public required string ActiveName { get; set; }
}
