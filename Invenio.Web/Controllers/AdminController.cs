﻿using Microsoft.AspNetCore.Mvc;

namespace Invenio.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}