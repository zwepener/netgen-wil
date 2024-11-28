using CodeCraft.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeCraft.Web.PublicPortal.Controllers
{
    public class CoursesController : Controller
    {
        private readonly CodeCraftDbContext _context;

        public CoursesController(CodeCraftDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? difficulyLevel, string? duration, string? technologies)
        {
            var courses = from c in _context.Course select c;

            if (!String.IsNullOrEmpty(difficulyLevel))
            {
                courses = courses.Where(c => c.DifficultyLevel == difficulyLevel);
            }

            if (!String.IsNullOrEmpty(duration))
            {
                courses = courses.Where(c => c.Duration == duration);
            }

            if (!String.IsNullOrEmpty(technologies))
            {
                courses = courses.Where(c => c.Technologies != null);
                courses = courses.Where(c => c.Technologies!.ToUpper().Contains(technologies.ToUpper()));
            }

            return View(await courses.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }
    }
}
