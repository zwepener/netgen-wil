using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.Web.StudentPortal.Controllers
{
    public class LibrariesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
