using CodeCraft.Data;
using CodeCraft.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodeCraft.Web.AdminPortal.Controllers;

[Authorize]
public class InstructorsController(CodeCraftDbContext context) : Controller
{
    private readonly CodeCraftDbContext _context = context;

    public async Task<IActionResult> Index()
    {
        List<Instructor> instructors = await _context.Instructor
            .Include(i => i.User)
            .ToListAsync();
        return View(instructors);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Instructor? instructor = await _context.Instructor
            .Include(i => i.User)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (instructor == null)
        {
            return NotFound();
        }

        return View(instructor);
    }

    public async Task<IActionResult> Create()
    {
        var existingInstructorUserIds = await _context.Instructor
            .Select(i => i.UserId)
            .ToListAsync();

        var filteredUsers = _context.Users.Where(u => !existingInstructorUserIds.Contains(u.Id));
        ViewData["Users"] = new SelectList(filteredUsers, "Id", "Email");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Instructor instructor)
    {
        if (ModelState.IsValid)
        {
            _context.Add(instructor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        var existingInstructorUserIds = await _context.Instructor
            .Select(i => i.UserId)
            .ToListAsync();

        var filteredUsers = _context.Users.Where(u => !existingInstructorUserIds.Contains(u.Id));
        ViewData["Users"] = new SelectList(filteredUsers, "Id", "Email", instructor.UserId);
        return View(instructor);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Instructor? instructor = await _context.Instructor
            .FindAsync(id);
        if (instructor == null)
        {
            return NotFound();
        }

        var existingInstructorUserIds = await _context.Instructor
            .Select(i => i.UserId)
            .Where(userId => userId != instructor.UserId)
            .ToListAsync();

        var filteredUsers = _context.Users.Where(u => !existingInstructorUserIds.Contains(u.Id));
        ViewData["Users"] = new SelectList(filteredUsers, "Id", "Email", instructor.UserId);
        return View(instructor);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Instructor instructor)
    {
        if (id != instructor.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(instructor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstructorExists(instructor.Id))
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

        var existingInstructorUserIds = await _context.Instructor
            .Select(i => i.UserId)
            .Where(userId => userId != instructor.UserId)
            .ToListAsync();

        var filteredUsers = _context.Users.Where(u => !existingInstructorUserIds.Contains(u.Id));
        ViewData["Users"] = new SelectList(filteredUsers, "Id", "Email", instructor.UserId);
        return View(instructor);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Instructor? instructor = await _context.Instructor
            .Include(i => i.User)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (instructor == null)
        {
            return NotFound();
        }

        return View(instructor);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        Instructor? instructor = await _context.Instructor.FindAsync(id);
        if (instructor != null)
        {
            _context.Instructor.Remove(instructor);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool InstructorExists(int id)
    {
        return _context.Instructor.Any(e => e.Id == id);
    }
}
