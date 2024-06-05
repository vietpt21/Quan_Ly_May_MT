using Microsoft.AspNetCore.Mvc;

namespace QLMT.Web.Controllers
{
    public class LocationManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
