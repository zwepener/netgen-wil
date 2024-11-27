using CodeCraft.Data;
using CodeCraft.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeCraft.Web.StudentPortal.Controllers
{
    [Authorize]
    public class DashboardController(UserManager<User> userManager, CodeCraftDbContext context) : Controller
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly CodeCraftDbContext _context = context;

        public async Task<IActionResult> Index()
        {
            User? user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            Student? student = await _context.Student.FirstAsync();
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
    }
}
