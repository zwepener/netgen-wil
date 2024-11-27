using CodeCraft.Data;
using CodeCraft.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodeCraft.Web.AdminPortal.Controllers
{
    [Authorize]
    public class InstructorTestimonialsController : Controller
    {
        private readonly CodeCraftDbContext _context;

        public InstructorTestimonialsController(CodeCraftDbContext context)
        {
            _context = context;
        }

        // GET: InstructorTestimonials
        public async Task<IActionResult> Index()
        {
            var codeCraftDbContext = _context.InstructorTestimonial.Include(i => i.Instructor).Include(i => i.Student);
            return View(await codeCraftDbContext.ToListAsync());
        }

        // GET: InstructorTestimonials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructorTestimonial = await _context.InstructorTestimonial
                .Include(i => i.Instructor)
                .Include(i => i.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instructorTestimonial == null)
            {
                return NotFound();
            }

            return View(instructorTestimonial);
        }

        // GET: InstructorTestimonials/Create
        public IActionResult Create()
        {
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "Id", "Id");
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id");
            return View();
        }

        // POST: InstructorTestimonials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InstructorId,StudentId,Comment,UpdatedAt,CreatedAt")] InstructorStudentTestimonial instructorTestimonial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instructorTestimonial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "Id", "Id", instructorTestimonial.InstructorId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", instructorTestimonial.StudentId);
            return View(instructorTestimonial);
        }

        // GET: InstructorTestimonials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructorTestimonial = await _context.InstructorTestimonial.FindAsync(id);
            if (instructorTestimonial == null)
            {
                return NotFound();
            }
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "Id", "Id", instructorTestimonial.InstructorId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", instructorTestimonial.StudentId);
            return View(instructorTestimonial);
        }

        // POST: InstructorTestimonials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InstructorId,StudentId,Comment,UpdatedAt,CreatedAt")] InstructorStudentTestimonial instructorTestimonial)
        {
            if (id != instructorTestimonial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instructorTestimonial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructorTestimonialExists(instructorTestimonial.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "Id", "Id", instructorTestimonial.InstructorId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", instructorTestimonial.StudentId);
            return View(instructorTestimonial);
        }

        // GET: InstructorTestimonials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructorTestimonial = await _context.InstructorTestimonial
                .Include(i => i.Instructor)
                .Include(i => i.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instructorTestimonial == null)
            {
                return NotFound();
            }

            return View(instructorTestimonial);
        }

        // POST: InstructorTestimonials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instructorTestimonial = await _context.InstructorTestimonial.FindAsync(id);
            if (instructorTestimonial != null)
            {
                _context.InstructorTestimonial.Remove(instructorTestimonial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstructorTestimonialExists(int id)
        {
            return _context.InstructorTestimonial.Any(e => e.Id == id);
        }
    }
}
