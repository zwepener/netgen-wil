using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.StudentPortal.Controllers
{
    public class AssignmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
