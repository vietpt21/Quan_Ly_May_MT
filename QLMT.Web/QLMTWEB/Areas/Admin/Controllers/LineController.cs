using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using QLMT.DataAccess.Repository.IRepository;

namespace QLMTWEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LineController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
