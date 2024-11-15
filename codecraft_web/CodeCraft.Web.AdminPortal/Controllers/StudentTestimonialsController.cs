using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeCraft.Data;
using CodeCraft.Data.Models;

namespace CodeCraft.Web.AdminPortal.Controllers
{
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
            var codeCraftDbContext = _context.StudentTestimonial.Include(s => s.Student);
            return View(await codeCraftDbContext.ToListAsync());
        }

        // GET: StudentTestimonials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTestimonial = await _context.StudentTestimonial
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentTestimonial == null)
            {
                return NotFound();
            }

            return View(studentTestimonial);
        }

        // GET: StudentTestimonials/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FirstName");
            return View();
        }

        // POST: StudentTestimonials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,CourseId,Comment,UpdatedAt,CreatedAt")] StudentTestimonial studentTestimonial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentTestimonial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FirstName", studentTestimonial.StudentId);
            return View(studentTestimonial);
        }

        // GET: StudentTestimonials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTestimonial = await _context.StudentTestimonial.FindAsync(id);
            if (studentTestimonial == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FirstName", studentTestimonial.StudentId);
            return View(studentTestimonial);
        }

        // POST: StudentTestimonials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,CourseId,Comment,UpdatedAt,CreatedAt")] StudentTestimonial studentTestimonial)
        {
            if (id != studentTestimonial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentTestimonial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentTestimonialExists(studentTestimonial.Id))
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
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FirstName", studentTestimonial.StudentId);
            return View(studentTestimonial);
        }

        // GET: StudentTestimonials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTestimonial = await _context.StudentTestimonial
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentTestimonial == null)
            {
                return NotFound();
            }

            return View(studentTestimonial);
        }

        // POST: StudentTestimonials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentTestimonial = await _context.StudentTestimonial.FindAsync(id);
            if (studentTestimonial != null)
            {
                _context.StudentTestimonial.Remove(studentTestimonial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentTestimonialExists(int id)
        {
            return _context.StudentTestimonial.Any(e => e.Id == id);
        }
    }
}
