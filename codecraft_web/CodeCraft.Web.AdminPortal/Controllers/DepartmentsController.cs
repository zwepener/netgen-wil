﻿using CodeCraft.Data;
using CodeCraft.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeCraft.Web.AdminPortal.Controllers;

[Authorize]
public class DepartmentsController(CodeCraftDbContext context) : Controller
{
    private readonly CodeCraftDbContext _context = context;

    public async Task<IActionResult> Index()
    {
        return View(await _context.Department.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Department? department = await _context.Department
            .FirstOrDefaultAsync(m => m.Id == id);
        if (department == null)
        {
            return NotFound();
        }

        return View(department);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Department department)
    {
        if (ModelState.IsValid)
        {
            _context.Add(department);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(department);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Department? department = await _context.Department.FindAsync(id);
        if (department == null)
        {
            return NotFound();
        }
        return View(department);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Department department)
    {
        if (id != department.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(department);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(department.Id))
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
        return View(department);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Department? department = await _context.Department
            .FirstOrDefaultAsync(m => m.Id == id);
        if (department == null)
        {
            return NotFound();
        }

        return View(department);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        Department? department = await _context.Department.FindAsync(id);
        if (department != null)
        {
            _context.Department.Remove(department);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DepartmentExists(int id)
    {
        return _context.Department.Any(e => e.Id == id);
    }
}
