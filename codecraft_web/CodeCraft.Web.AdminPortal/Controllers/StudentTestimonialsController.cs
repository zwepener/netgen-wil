using CodeCraft.Data;
using CodeCraft.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodeCraft.Web.AdminPortal.Controllers;

[Authorize]
public class StudentTestimonialsController(CodeCraftDbContext context) : Controller
{
    private readonly CodeCraftDbContext _context = context;


    public async Task<IActionResult> Index()
    {
        var testimonials = _context.StudentCourseTestimonial.Include(s => s.Course).Include(s => s.Student);
        return View(await testimonials.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var testimonial = await _context.StudentCourseTestimonial
            .Include(s => s.Course)
            .Include(s => s.Student)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (testimonial == null)
        {
            return NotFound();
        }

        return View(testimonial);
    }

    public IActionResult Create()
    {
        ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id");
        ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(StudentCourseTestimonial testimonial)
    {
        if (ModelState.IsValid)
        {
            _context.Add(testimonial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", testimonial.CourseId);
        ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", testimonial.StudentId);
        return View(testimonial);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var testimonial = await _context.StudentCourseTestimonial.FindAsync(id);
        if (testimonial == null)
        {
            return NotFound();
        }
        ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", testimonial.CourseId);
        ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", testimonial.StudentId);
        return View(testimonial);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, StudentCourseTestimonial testimonial)
    {
        if (id != testimonial.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(testimonial);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestimonialExists(testimonial.Id))
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
        ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", testimonial.CourseId);
        ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", testimonial.StudentId);
        return View(testimonial);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var testimonial = await _context.StudentCourseTestimonial
            .Include(s => s.Course)
            .Include(s => s.Student)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (testimonial == null)
        {
            return NotFound();
        }

        return View(testimonial);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var testimonial = await _context.StudentCourseTestimonial.FindAsync(id);
        if (testimonial != null)
        {
            _context.StudentCourseTestimonial.Remove(testimonial);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TestimonialExists(int id)
    {
        return _context.StudentCourseTestimonial.Any(e => e.Id == id);
    }
}
