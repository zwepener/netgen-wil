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
            var codeCraftDbContext = _context.InstructorStudentTestimonial.Include(i => i.Instructor).Include(i => i.Student);
            return View(await codeCraftDbContext.ToListAsync());
        }

        // GET: InstructorTestimonials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructorStudentTestimonial = await _context.InstructorStudentTestimonial
                .Include(i => i.Instructor)
                .Include(i => i.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instructorStudentTestimonial == null)
            {
                return NotFound();
            }

            return View(instructorStudentTestimonial);
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
        public async Task<IActionResult> Create([Bind("Id,InstructorId,StudentId,Comment,UpdatedAt,CreatedAt")] InstructorStudentTestimonial instructorStudentTestimonial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instructorStudentTestimonial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "Id", "Id", instructorStudentTestimonial.InstructorId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", instructorStudentTestimonial.StudentId);
            return View(instructorStudentTestimonial);
        }

        // GET: InstructorTestimonials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructorStudentTestimonial = await _context.InstructorStudentTestimonial.FindAsync(id);
            if (instructorStudentTestimonial == null)
            {
                return NotFound();
            }
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "Id", "Id", instructorStudentTestimonial.InstructorId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", instructorStudentTestimonial.StudentId);
            return View(instructorStudentTestimonial);
        }

        // POST: InstructorTestimonials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InstructorId,StudentId,Comment,UpdatedAt,CreatedAt")] InstructorStudentTestimonial instructorStudentTestimonial)
        {
            if (id != instructorStudentTestimonial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instructorStudentTestimonial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructorTestimonialExists(instructorStudentTestimonial.Id))
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
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "Id", "Id", instructorStudentTestimonial.InstructorId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", instructorStudentTestimonial.StudentId);
            return View(instructorStudentTestimonial);
        }

        // GET: InstructorTestimonials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructorStudentTestimonial = await _context.InstructorStudentTestimonial
                .Include(i => i.Instructor)
                .Include(i => i.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instructorStudentTestimonial == null)
            {
                return NotFound();
            }

            return View(instructorStudentTestimonial);
        }

        // POST: InstructorTestimonials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instructorStudentTestimonial = await _context.InstructorStudentTestimonial.FindAsync(id);
            if (instructorStudentTestimonial != null)
            {
                _context.InstructorStudentTestimonial.Remove(instructorStudentTestimonial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstructorTestimonialExists(int id)
        {
            return _context.InstructorStudentTestimonial.Any(e => e.Id == id);
        }
    }
}
