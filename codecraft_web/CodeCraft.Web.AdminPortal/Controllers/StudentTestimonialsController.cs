using CodeCraft.Data;
using CodeCraft.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodeCraft.Web.AdminPortal.Controllers
{
    [Authorize]
    public class StudentTestimonialsController : Controller
    {
        private readonly CodeCraftDbContext _context;

        public StudentTestimonialsController(CodeCraftDbContext context)
        {
            _context = context;
        }

        // GET: StudentTestimonials
        public async Task<IActionResult> Index()
        {
            var codeCraftDbContext = _context.StudentCourseTestimonial.Include(s => s.Course).Include(s => s.Student);
            return View(await codeCraftDbContext.ToListAsync());
        }

        // GET: StudentTestimonials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourseTestimonial = await _context.StudentCourseTestimonial
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentCourseTestimonial == null)
            {
                return NotFound();
            }

            return View(studentCourseTestimonial);
        }

        // GET: StudentTestimonials/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id");
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id");
            return View();
        }

        // POST: StudentTestimonials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,CourseId,Comment,UpdatedAt,CreatedAt")] StudentCourseTestimonial studentCourseTestimonial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentCourseTestimonial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", studentCourseTestimonial.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", studentCourseTestimonial.StudentId);
            return View(studentCourseTestimonial);
        }

        // GET: StudentTestimonials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourseTestimonial = await _context.StudentCourseTestimonial.FindAsync(id);
            if (studentCourseTestimonial == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", studentCourseTestimonial.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", studentCourseTestimonial.StudentId);
            return View(studentCourseTestimonial);
        }

        // POST: StudentTestimonials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,CourseId,Comment,UpdatedAt,CreatedAt")] StudentCourseTestimonial studentCourseTestimonial)
        {
            if (id != studentCourseTestimonial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentCourseTestimonial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentTestimonialExists(studentCourseTestimonial.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", studentCourseTestimonial.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", studentCourseTestimonial.StudentId);
            return View(studentCourseTestimonial);
        }

        // GET: StudentTestimonials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourseTestimonial = await _context.StudentCourseTestimonial
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentCourseTestimonial == null)
            {
                return NotFound();
            }

            return View(studentCourseTestimonial);
        }

        // POST: StudentTestimonials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentCourseTestimonial = await _context.StudentCourseTestimonial.FindAsync(id);
            if (studentCourseTestimonial != null)
            {
                _context.StudentCourseTestimonial.Remove(studentCourseTestimonial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentTestimonialExists(int id)
        {
            return _context.StudentCourseTestimonial.Any(e => e.Id == id);
        }
    }
}
