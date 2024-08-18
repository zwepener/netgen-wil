using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using codecraft_web.Data;
using codecraft_web.Models;

namespace codecraft_web.Controllers
{
    public class InstructorTestimonialsController : Controller
    {
        private readonly codecraft_webDBContext _context;

        public InstructorTestimonialsController(codecraft_webDBContext context)
        {
            _context = context;
        }

        // GET: InstructorTestimonials
        public async Task<IActionResult> Index()
        {
            return View(await _context.InstructorTestimonial.ToListAsync());
        }

        // GET: InstructorTestimonials/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructorTestimonial = await _context.InstructorTestimonial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instructorTestimonial == null)
            {
                return NotFound();
            }

            return View(instructorTestimonial);
        }

        // GET: InstructorTestimonials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InstructorTestimonials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InstructorId,StudentId,Comment,CreatedAt,UpdatedAt")] InstructorTestimonial instructorTestimonial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instructorTestimonial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instructorTestimonial);
        }

        // GET: InstructorTestimonials/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructorTestimonial = await _context.InstructorTestimonial.FindAsync(id);
            if (instructorTestimonial == null)
            {
                return NotFound();
            }
            return View(instructorTestimonial);
        }

        // POST: InstructorTestimonials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,InstructorId,StudentId,Comment,CreatedAt,UpdatedAt")] InstructorTestimonial instructorTestimonial)
        {
            if (id != instructorTestimonial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instructorTestimonial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructorTestimonialExists(instructorTestimonial.Id))
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
            return View(instructorTestimonial);
        }

        // GET: InstructorTestimonials/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructorTestimonial = await _context.InstructorTestimonial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instructorTestimonial == null)
            {
                return NotFound();
            }

            return View(instructorTestimonial);
        }

        // POST: InstructorTestimonials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var instructorTestimonial = await _context.InstructorTestimonial.FindAsync(id);
            if (instructorTestimonial != null)
            {
                _context.InstructorTestimonial.Remove(instructorTestimonial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstructorTestimonialExists(long id)
        {
            return _context.InstructorTestimonial.Any(e => e.Id == id);
        }
    }
}
