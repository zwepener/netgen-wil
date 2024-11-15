using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.Web.StudentPortal.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
