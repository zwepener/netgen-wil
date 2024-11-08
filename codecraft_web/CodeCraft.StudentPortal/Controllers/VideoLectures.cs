using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.StudentPortal.Controllers
{
    public class VideoLectures : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
