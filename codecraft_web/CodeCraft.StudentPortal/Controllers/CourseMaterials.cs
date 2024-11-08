using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.StudentPortal.Controllers
{
    public class CourseMaterials : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
