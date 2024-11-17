using CodeCraft.Data;
using CodeCraft.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeCraft.Web.AdminPortal.Controllers
{
    [Authorize]
    public class ContactInquiriesController : Controller
    {
        private readonly CodeCraftDbContext _context;

        public ContactInquiriesController(CodeCraftDbContext context)
        {
            _context = context;
        }

        // GET: ContactInquiries
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactInquiry.ToListAsync());
        }

        // GET: ContactInquiries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInquiry = await _context.ContactInquiry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactInquiry == null)
            {
                return NotFound();
            }

            return View(contactInquiry);
        }

        // GET: ContactInquiries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactInquiries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Message,CreatedAt")] ContactInquiry contactInquiry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactInquiry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactInquiry);
        }

        // GET: ContactInquiries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInquiry = await _context.ContactInquiry.FindAsync(id);
            if (contactInquiry == null)
            {
                return NotFound();
            }
            return View(contactInquiry);
        }

        // POST: ContactInquiries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Message,CreatedAt")] ContactInquiry contactInquiry)
        {
            if (id != contactInquiry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactInquiry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactInquiryExists(contactInquiry.Id))
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
            return View(contactInquiry);
        }

        // GET: ContactInquiries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInquiry = await _context.ContactInquiry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactInquiry == null)
            {
                return NotFound();
            }

            return View(contactInquiry);
        }

        // POST: ContactInquiries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactInquiry = await _context.ContactInquiry.FindAsync(id);
            if (contactInquiry != null)
            {
                _context.ContactInquiry.Remove(contactInquiry);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactInquiryExists(int id)
        {
            return _context.ContactInquiry.Any(e => e.Id == id);
        }
    }
}
