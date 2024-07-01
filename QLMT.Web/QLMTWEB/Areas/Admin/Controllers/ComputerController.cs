using Microsoft.AspNetCore.Mvc;

namespace QLMTWEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ComputerController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }
    }
}
