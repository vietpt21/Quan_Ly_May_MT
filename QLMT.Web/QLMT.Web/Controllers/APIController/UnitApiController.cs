using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QLMT.DataAccess.Repository.IRepository;
using QLMT.Models;

namespace QLMT.Web.Controllers.APIController
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
        public object Get()
        {
            DataSourceLoadOptions loadOptions = new DataSourceLoadOptions();

            IEnumerable<Unit> objUnitList = _unitOfWork.Unit.GetAll(includeProperties: "Line");

            return DataSourceLoader.Load(objUnitList, loadOptions);
        }

        [HttpPost]
        public IActionResult Insert(int id, string values)
        {
            var unit = _unitOfWork.Unit.GetFirstOrDefault(o => o.UnitId == id);
            JsonConvert.PopulateObject(values, unit);
            _unitOfWork.Unit.Add(unit);
            _unitOfWork.Save();
            return Ok(unit);
        }
        [HttpPut]
        public IActionResult Update(int id, string values)
        {
            var unit = _unitOfWork.Unit.GetFirstOrDefault(o => o.UnitId == id);
            JsonConvert.PopulateObject(values, unit);
            _unitOfWork.Unit.Update(unit);
            _unitOfWork.Save();
            return Ok(unit);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            var unit = _unitOfWork.Unit.GetFirstOrDefault(o => o.UnitId == id);
            _unitOfWork.Unit.Remove(unit);
            _unitOfWork.Save();
        }

    }
}
