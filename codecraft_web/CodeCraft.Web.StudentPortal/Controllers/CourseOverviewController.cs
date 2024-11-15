using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.Web.StudentPortal.Controllers
{
    public class CourseOverviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
