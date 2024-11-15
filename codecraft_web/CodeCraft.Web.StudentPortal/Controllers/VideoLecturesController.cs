using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.Web.StudentPortal.Controllers
{
    public class VideoLecturesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
