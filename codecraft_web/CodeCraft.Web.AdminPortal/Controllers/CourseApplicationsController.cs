using CodeCraft.Data;
using CodeCraft.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeCraft.Web.AdminPortal.Controllers;

[Authorize]
public class CourseApplicationsController(CodeCraftDbContext context, UserManager<User> userManager) : Controller
{
    private readonly CodeCraftDbContext _context = context;
    private readonly UserManager<User> _userManager = userManager;

    public async Task<IActionResult> Index()
    {
        var codeCraftDbContext = _context.CourseApplication.Include(c => c.Course);
        return View(await codeCraftDbContext.ToListAsync());
    }

    public async Task<IActionResult> Approve(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var courseApplication = await _context.CourseApplication
            .Include(c => c.Course)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (courseApplication == null)
        {
            return NotFound();
        }

        return View(courseApplication);
    }

    [HttpPost, ActionName("Approve")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ApproveConfirmed(int id)
    {
        var courseApplication = await _context.CourseApplication
            .Include(c => c.Course)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (courseApplication == null)
        {
            return NotFound();
        }

        Course? course = courseApplication.Course;
        if (course == null)
        {
            return await DeleteConfirmed(courseApplication.Id);
        }

        User? user = await _userManager.FindByEmailAsync(courseApplication.Email);
        if (user == null)
        {
            return await DeleteConfirmed(courseApplication.Id);
        }

        Student? student = await _context.Student.FirstOrDefaultAsync(student => student.UserId == user.Id);
        if (student == null)
        {
            student = new()
            {
                UserId = user.Id
            };

            await _context.Student.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        bool enrollmentExists = await _context.Enrollment.AnyAsync(e => e.CourseId == course.Id && e.StudentId == student.Id);
        if (enrollmentExists)
        {
            return await DeleteConfirmed(courseApplication.Id);
        }

        Enrollment enrollment = new()
        {
            CourseId = course.Id,
            StudentId = student.Id,
            RegisterDate = courseApplication.CreatedAt,
            AdmitDate = DateTime.Today,
            GraduateDate = Core.Utils.GetFutureDateTime(DateTime.Today, course.Duration)
        };

        await _context.Enrollment.AddAsync(enrollment);
        await _context.SaveChangesAsync();

        return await DeleteConfirmed(courseApplication.Id);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var courseApplication = await _context.CourseApplication
            .Include(c => c.Course)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (courseApplication == null)
        {
            return NotFound();
        }

        return View(courseApplication);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var courseApplication = await _context.CourseApplication.FindAsync(id);
        if (courseApplication != null)
        {
            _context.CourseApplication.Remove(courseApplication);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CourseApplicationExists(int id)
    {
        return _context.CourseApplication.Any(e => e.Id == id);
    }
}