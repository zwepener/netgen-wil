using CodeCraft.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CodeCraft.Web.PublicPortal.Models;

public class EnrollemntFormViewModel
{
    public List<Course> Courses { get; set; } = [];
}