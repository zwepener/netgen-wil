using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.Web.StudentPortal.Controllers
{
    public class CourseMaterials : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
