using CodeCraft.Data;
using CodeCraft.Data.Models;
using CodeCraft.Web.PublicPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CodeCraft.Web.PublicPortal.Controllers
{
    public class HomeController(ILogger<HomeController> logger, CodeCraftDbContext context) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly CodeCraftDbContext _context = context;

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Fetching featured Student-Course Testimonials.");
            List<StudentCourseTestimonial> testimonials = await _context.StudentCourseTestimonial
                .Include(t => t.Student)
                .Include(t => t.Student!.User)
                .Include(t => t.Course)
                .Where(t => t.IsFeatured == true)
                .ToListAsync();

            HomeViewModel model = new()
            {
                Testimonials = testimonials
            };

            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
