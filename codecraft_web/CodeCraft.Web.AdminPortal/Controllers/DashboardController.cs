using CodeCraft.Data;
using CodeCraft.Web.AdminPortal.Models;
using CodeCraft.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeCraft.Web.AdminPortal.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly CodeCraftDbContext _context;
        public DashboardController(CodeCraftDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Student> students = await _context.Student.Include(s => s.User).ToListAsync();
            List<Course> courses = await _context.Course.ToListAsync();

            return View
            (
                new DashboardModel
                {
                    Students = students,
                    Courses = courses,
                }
            );
        }
    }
}
