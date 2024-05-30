using Microsoft.AspNetCore.Mvc;

namespace QLMT.Web.Controllers
{
    public class ComputerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
