using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.StudentPortal.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
