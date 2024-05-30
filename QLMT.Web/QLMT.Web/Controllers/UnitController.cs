using Microsoft.AspNetCore.Mvc;

namespace QLMT.Web.Controllers
{
    public class UnitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
