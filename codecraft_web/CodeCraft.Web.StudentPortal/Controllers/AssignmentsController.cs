using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.Web.StudentPortal.Controllers
{
    public class AssignmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
