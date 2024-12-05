using CodeCraft.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeCraft.Web.PublicPortal.Controllers
{
    public class InstructorsController(CodeCraftDbContext context) : Controller
    {
        private readonly CodeCraftDbContext _context = context;

        public async Task<IActionResult> Index()
        {
            var codeCraftDbContext = _context.Instructor.Include(i => i.User);
            return View(await codeCraftDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructor
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }
    }
}
