using CodeCraft.Data;
using CodeCraft.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodeCraft.Web.AdminPortal.Controllers;

[Authorize]
public class AdminsController(CodeCraftDbContext context) : Controller
{
    private readonly CodeCraftDbContext _context = context;

    public async Task<IActionResult> Index()
    {
        var codeCraftDbContext = _context.Admin.Include(a => a.User);
        return View(await codeCraftDbContext.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var admin = await _context.Admin
            .Include(a => a.User)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (admin == null)
        {
            return NotFound();
        }

        return View(admin);
    }

    public async Task<IActionResult> Create()
    {
        var existingAdminUserIds = await _context.Admin
            .Select(a => a.UserId)
            .ToListAsync();

        var filteredUsers = _context.Users.Where(u => !existingAdminUserIds.Contains(u.Id));
        ViewData["UserId"] = new SelectList(filteredUsers, "Id", "Email");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Admin admin)
    {
        if (ModelState.IsValid)
        {
            _context.Add(admin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        var existingAdminUserIds = await _context.Admin
            .Select(a => a.UserId)
            .ToListAsync();

        var filteredUsers = _context.Users.Where(u => !existingAdminUserIds.Contains(u.Id));
        ViewData["UserId"] = new SelectList(filteredUsers, "Id", "Email", admin.UserId);
        return View(admin);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var admin = await _context.Admin.FindAsync(id);
        if (admin == null)
        {
            return NotFound();
        }

        var existingAdminUserIds = await _context.Admin
            .Select(a => a.UserId)
            .Where(userId => userId != admin.UserId)
            .ToListAsync();

        var filteredUsers = _context.Users.Where(u => !existingAdminUserIds.Contains(u.Id));
        ViewData["UserId"] = new SelectList(filteredUsers, "Id", "Email", admin.UserId);
        return View(admin);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Admin admin)
    {
        if (id != admin.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(admin);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(admin.Id))
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

        var existingAdminUserIds = await _context.Admin
            .Select(a => a.UserId)
            .Where(userId => userId != admin.UserId)
            .ToListAsync();

        var filteredUsers = _context.Users.Where(u => !existingAdminUserIds.Contains(u.Id));
        ViewData["UserId"] = new SelectList(filteredUsers, "Id", "Email", admin.UserId);
        return View(admin);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var admin = await _context.Admin
            .Include(a => a.User)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (admin == null)
        {
            return NotFound();
        }

        return View(admin);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var admin = await _context.Admin.FindAsync(id);
        if (admin != null)
        {
            _context.Admin.Remove(admin);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AdminExists(int id)
    {
        return _context.Admin.Any(e => e.Id == id);
    }
}
