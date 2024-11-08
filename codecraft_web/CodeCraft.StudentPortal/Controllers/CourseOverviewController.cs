using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.StudentPortal.Controllers
{
    public class CourseOverviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
