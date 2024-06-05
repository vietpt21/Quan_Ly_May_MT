using Microsoft.AspNetCore.Mvc;

namespace QLMT.Web.Controllers
{
    public class InventoryController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
