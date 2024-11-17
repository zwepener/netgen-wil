using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.Web.StudentPortal.Controllers
{
    [Authorize]
    public class ProfileManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
