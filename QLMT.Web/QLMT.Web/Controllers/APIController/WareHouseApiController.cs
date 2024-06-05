using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QLMT.DataAccess.Repository.IRepository;
using QLMT.Models;

namespace QLMT.Web.Controllers.APIController
{
    [Route("api/[controller]")]
    public class WareHouseApiController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public WareHouseApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_unitOfWork.WareHouse.GetAll(), loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            var newWareHouse = new WareHouse();
            JsonConvert.PopulateObject(values, newWareHouse);
            _unitOfWork.WareHouse.Add(newWareHouse);
            _unitOfWork.Save();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var newWareHouse = _unitOfWork.WareHouse.GetFirstOrDefault(a => a.WareHouseId == key);
            JsonConvert.PopulateObject(values, newWareHouse);
            _unitOfWork.Save();

            return Ok();
        }
        [HttpDelete]
        public void Delete(int key)
        {
            var wareHouse = _unitOfWork.WareHouse.GetFirstOrDefault(a => a.WareHouseId == key);
            _unitOfWork.WareHouse.Remove(wareHouse);
            _unitOfWork.Save();
        }
    }
}
