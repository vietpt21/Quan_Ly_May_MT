﻿using Microsoft.AspNetCore.Mvc;

namespace QLMTWEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NetworkRangeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
