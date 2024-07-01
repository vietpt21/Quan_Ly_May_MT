using Microsoft.AspNetCore.Mvc;

namespace QLMTWEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UnitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
