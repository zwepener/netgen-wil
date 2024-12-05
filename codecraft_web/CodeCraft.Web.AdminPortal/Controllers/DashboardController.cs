using CodeCraft.Data;
using CodeCraft.Data.Models;
using CodeCraft.Web.AdminPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeCraft.Web.AdminPortal.Controllers;

[Authorize]
public class DashboardController(CodeCraftDbContext context) : Controller
{
    private readonly CodeCraftDbContext _context = context;

    public async Task<IActionResult> Index()
    {
        List<Student> students = await _context.Student.Include(s => s.User).ToListAsync();
        List<Course> courses = await _context.Course.ToListAsync();

        DashboardModel dashboardModel = new()
        {
            Students = students,
            Courses = courses,
        };

        return View(dashboardModel);
    }
}
