using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QLMT.DataAccess.Repository.IRepository;
using QLMT.Models;
using System.Xml.Linq;

namespace QLMTWEB.Areas.Admin.Controllers.APIController
{
    [Route("api/[controller]")]
    public class UnitApiController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_unitOfWork.Unit.GetAll(), loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            var newUnit = new Unit();
            JsonConvert.PopulateObject(values, newUnit);
            _unitOfWork.Unit.Add(newUnit);
            _unitOfWork.Save();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var newUnit = _unitOfWork.Unit.GetFirstOrDefault(a => a.UnitId == key);
            JsonConvert.PopulateObject(values, newUnit);
            _unitOfWork.Save();

            return Ok();
        }

        [HttpDelete]
        public void Delete(int key)
        {
            var unit = _unitOfWork.Unit.GetFirstOrDefault(a => a.UnitId == key);
            _unitOfWork.Unit.Remove(unit);
            _unitOfWork.Save();
        }

    }
}
