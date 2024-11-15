using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.Web.StudentPortal.Controllers
{
    public class ProfileManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
