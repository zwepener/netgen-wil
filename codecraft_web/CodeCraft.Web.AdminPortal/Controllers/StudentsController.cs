using CodeCraft.Data;
using CodeCraft.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodeCraft.Web.AdminPortal.Controllers;

[Authorize]
public class StudentsController(CodeCraftDbContext context) : Controller
{
    private readonly CodeCraftDbContext _context = context;

    public async Task<IActionResult> Index()
    {
        var codeCraftDbContext = _context.Student.Include(s => s.User);
        return View(await codeCraftDbContext.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Student? student = await _context.Student
            .Include(s => s.User)
            .Include(s => s.Courses)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    public async Task<IActionResult> Create()
    {
        var existingStudentUserIds = await _context.Student
            .Select(s => s.UserId)
            .ToListAsync();

        var filteredUsers = _context.Users.Where(u => !existingStudentUserIds.Contains(u.Id));
        ViewData["Users"] = new SelectList(filteredUsers, "Id", "Email");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Student student)
    {
        if (ModelState.IsValid)
        {
            _context.Add(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        var existingStudentUserIds = await _context.Student
            .Select(s => s.UserId)
            .ToListAsync();

        var filteredUsers = _context.Users.Where(u => !existingStudentUserIds.Contains(u.Id));
        ViewData["Users"] = new SelectList(filteredUsers, "Id", "Email", student.UserId);
        return View(student);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Student? student = await _context.Student.FindAsync(id);
        if (student == null)
        {
            return NotFound();
        }

        var existingStudentUserIds = await _context.Student
                .Select(s => s.UserId)
                .Where(userId => userId != student.UserId)
                .ToArrayAsync();

        var filteredUsers = _context.Users.Where(u => !existingStudentUserIds.Contains(u.Id));
        ViewData["Users"] = new SelectList(filteredUsers, "Id", "Email", student.UserId);
        return View(student);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Student student)
    {
        if (id != student.Id)
        {
            return NotFound();
        }

        student.UpdatedAt = DateTime.Now;

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(student);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(student.Id))
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

        var existingStudentUserIds = await _context.Student
                .Select(s => s.UserId)
                .Where(userId => userId != student.UserId)
                .ToListAsync();

        var filteredUsers = _context.Users.Where(u => !existingStudentUserIds.Contains(u.Id));
        ViewData["Users"] = new SelectList(filteredUsers, "Id", "Email", student.UserId);
        return View(student);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await _context.Student
            .Include(s => s.User)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var student = await _context.Student.FindAsync(id);
        if (student != null)
        {
            _context.Student.Remove(student);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool StudentExists(int id)
    {
        return _context.Student.Any(e => e.Id == id);
    }
}
