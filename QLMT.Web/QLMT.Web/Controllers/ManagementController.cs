﻿using Microsoft.AspNetCore.Mvc;

namespace QLMT.Web.Controllers
{
    public class ManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
