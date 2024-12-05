using CodeCraft.Data;
using CodeCraft.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.Web.PublicPortal.Controllers;

public class InquiriesController(CodeCraftDbContext context) : Controller
{
    private readonly CodeCraftDbContext _context = context;

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SubmitInquiry(Inquiry inquiry)
    {
        if (ModelState.IsValid)
        {
            inquiry.IsResolved = false;

            await _context.Inquiry.AddAsync(inquiry);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index", "Home");
    }
}