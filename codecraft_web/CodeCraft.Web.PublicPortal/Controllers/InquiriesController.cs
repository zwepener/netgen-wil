using CodeCraft.Data;
using CodeCraft.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.Web.PublicPortal.Controllers;

public class InquiriesController : Controller
{
    private readonly CodeCraftDbContext _context;

    public InquiriesController(CodeCraftDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SubmitInquiry(Inquiry inquiry)
    {
        if (ModelState.IsValid)
        {
            _context.Inquiry.Add(inquiry);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        return PartialView("_ContactFormPartial", inquiry);
    }
}