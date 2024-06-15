using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using QLMT.DataAccess.Repository;
using QLMT.DataAccess.Repository.IRepository;
using QLMT.Models;
using System.Xml.Linq;
using QLMT.DataAccess.Data;

namespace QLMT.Web.Controllers
{
    public class ManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
