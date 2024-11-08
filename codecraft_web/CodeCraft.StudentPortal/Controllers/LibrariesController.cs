using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.StudentPortal.Controllers
{
    public class LibrariesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
