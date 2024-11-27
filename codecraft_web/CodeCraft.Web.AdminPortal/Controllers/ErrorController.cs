using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.Web.AdminPortal.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var viewName = statusCode.ToString();
            return View(viewName);
        }
    }
}
