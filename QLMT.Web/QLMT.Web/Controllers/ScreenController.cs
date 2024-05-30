using Microsoft.AspNetCore.Mvc;

namespace QLMT.Web.Controllers
{
    public class ScreenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
