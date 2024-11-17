﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.Web.StudentPortal.Controllers
{
    [Authorize]
    public class VideoLecturesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
