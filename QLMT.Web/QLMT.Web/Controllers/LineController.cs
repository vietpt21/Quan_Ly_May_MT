using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using QLMT.DataAccess.Repository.IRepository;

namespace QLMT.Web.Controllers
{
   
    public class LineController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
