using Microsoft.AspNetCore.Mvc;

namespace QLMT.Web.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
