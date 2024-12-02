using CodeCraft.Data;
using CodeCraft.Data.Models;
using CodeCraft.Web.PublicPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeCraft.Web.PublicPortal.Controllers;

public class CoursesController(CodeCraftDbContext context, UserManager<User> userManager) : Controller
{
    private readonly CodeCraftDbContext _context = context;
    private readonly UserManager<User> _userManager = userManager;

    private static readonly List<string> _technologies = ["Python", "Java", "JavaScript", "C++", "HTML", "CSS", "SQL"];
    private static readonly List<string> _difficultyLevels = ["Beginner", "Intermediate", "Advanced", "Major"];

    private readonly CoursesViewModel.FiltersModel _baseFiltersModel = new()
    {
        DifficultyLevels = _difficultyLevels.Select(i => new CoursesViewModel.FilterModel()
        {
            Label = i,
            Value = i,
        }).ToList(),
        Technologies = _technologies.Select(i => new CoursesViewModel.FilterModel()
        {
            Label = i,
            Value = i,
        }).ToList(),
        Durations =
        [
            new CoursesViewModel.FilterModel() {
                Label = "1 Month",
                Value = "1m"
            },
            new CoursesViewModel.FilterModel() {
                Label = "6 Months",
                Value = "6m"
            },
            new CoursesViewModel.FilterModel() {
                Label = "12 Months",
                Value = "1y"
            }
        ]
    };

    public async Task<IActionResult> Index(CoursesViewModel coursesViewModel)
    {
        coursesViewModel.Filters ??= _baseFiltersModel;

        var courses = from c in _context.Course select c;

        var filters = coursesViewModel.Filters;

        if (filters.DifficultyLevels.Count > 0)
        {
            List<string> levels = filters.DifficultyLevels
                .Where(i => i.Enabled)
                .Select(i => i.Value)
                .ToList();

            if (levels.Count > 0)
            {
                courses = courses.Where(
                    course => levels.Any(level => course.DifficultyLevel.ToUpper().Contains(
                        level.ToUpper()
                    ))
                );
            }
        }

        if (filters.Durations.Count > 0)
        {
            List<string> durations = filters.Durations
                .Where(i => i.Enabled)
                .Select(i => i.Value)
                .ToList();

            if (durations.Count > 0)
            {
                courses = courses.Where(
                    course => durations.Any(
                        duration => course.Duration == duration
                    )
                );
            }
        }

        if (filters.Technologies.Count > 0)
        {
            List<string> technologies = filters.Technologies
                .Where(i => i.Enabled)
                .Select(i => i.Value)
                .ToList();

            if (technologies.Count > 0)
            {
                courses = courses
                    .Where(
                        course => !String.IsNullOrEmpty(course.Technologies)
                    )
                    .Where(
                        course => technologies.Any(
                            technology => course.Technologies!.ToUpper().Contains(
                                technology.ToUpper()
                            )
                        )
                    );
            }
        }

        coursesViewModel.Courses = await courses.ToListAsync();

        return View(coursesViewModel);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var course = await _context.Course
            .FirstOrDefaultAsync(m => m.Id == id);

        if (course == null)
        {
            return NotFound();
        }

        return View(course);
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Enroll(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Course? course = await _context.Course.FirstOrDefaultAsync(m => m.Id == id);
        if (course == null)
        {
            return NotFound();
        }

        User? user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToRoute("/Identity/Account/Login");
        }

        Student? student = await _context.Student.FirstOrDefaultAsync(m => m.UserId == user.Id);
        if (student == null)
        {
            student = new()
            {
                UserId = user.Id,
            };
            await _context.Student.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        Enrollment? enrollment = await _context.Enrollment.FirstOrDefaultAsync(e => e.StudentId == student.Id);
        if (enrollment == null)
        {
            enrollment = new()
            {
                StudentId = student.Id,
                CourseId = course.Id,
                RegisterDate = DateTime.Today,
                AdmitDate = DateTime.Today,
                GraduateDate = Core.Utils.GetFutureDateTime(DateTime.Today, course.Duration),
            };
            await _context.Enrollment.AddAsync(enrollment);
        }

        return RedirectToAction(nameof(Index));
    }
}