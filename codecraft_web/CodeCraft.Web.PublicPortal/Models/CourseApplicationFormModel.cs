using CodeCraft.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.Web.PublicPortal.Models;

public class CourseApplicationFormModel
{
    public required int CourseId { get; set; }

    public required string CourseName { get; set; }

    [BindProperty]
    public CourseApplication Input { get; set; } = null!;
}
