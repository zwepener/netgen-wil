using CodeCraft.Data;
using CodeCraft.Web.AdminPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeCraft.Web.AdminPortal.Controllers;

[Authorize]
public class TestimonialsController(CodeCraftDbContext context) : Controller
{
    private readonly CodeCraftDbContext _context = context;

    public async Task<IActionResult> Index()
    {
        var studentCourseTestimonials = await _context.StudentCourseTestimonial
            .Include(i => i.Student)
            .ThenInclude(s => s!.User)
            .Include(i => i.Course)
            .ToListAsync();

        var instructorStudentTestimonials = await _context.InstructorStudentTestimonial
            .Include(i => i.Student)
            .ThenInclude(s => s!.User)
            .Include(i => i.Instructor)
            .ThenInclude(s => s!.User)
            .ToListAsync();

        TestimonialsViewModel model = new()
        {
            StudentCourseTestimonials = studentCourseTestimonials,
            InstructorStudentTestimonials = instructorStudentTestimonials
        };

        return View(model);
    }
}