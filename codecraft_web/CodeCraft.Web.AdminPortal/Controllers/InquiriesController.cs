using CodeCraft.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeCraft.Web.AdminPortal.Controllers;

[Authorize]
public class InquiriesController(CodeCraftDbContext context) : Controller
{
    private readonly CodeCraftDbContext _context = context;

    public async Task<IActionResult> Index()
    {
        return View(await _context.Inquiry.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var inquiry = await _context.Inquiry
            .FirstOrDefaultAsync(m => m.Id == id);
        if (inquiry == null)
        {
            return NotFound();
        }

        return View(inquiry);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var inquiry = await _context.Inquiry
            .FirstOrDefaultAsync(m => m.Id == id);
        if (inquiry == null)
        {
            return NotFound();
        }

        return View(inquiry);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var inquiry = await _context.Inquiry.FindAsync(id);
        if (inquiry != null)
        {
            _context.Inquiry.Remove(inquiry);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ContactInquiryExists(int id)
    {
        return _context.Inquiry.Any(e => e.Id == id);
    }
}
