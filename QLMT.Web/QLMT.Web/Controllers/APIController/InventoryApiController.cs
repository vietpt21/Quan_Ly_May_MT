using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QLMT.DataAccess.Repository.IRepository;
using QLMT.Models;

namespace QLMT.Web.Controllers.APIController
{
    [Route("api/[controller]")]
    public class InventoryApiController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public InventoryApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_unitOfWork.Inventoty.GetAll(), loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            var newInventory = new Inventory();
            JsonConvert.PopulateObject(values, newInventory);
            _unitOfWork.Inventoty.Add(newInventory);
            _unitOfWork.Save();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var newInventory = _unitOfWork.Inventoty.GetFirstOrDefault(a => a.InventotyId == key);
            JsonConvert.PopulateObject(values, newInventory);
            _unitOfWork.Save();

            return Ok();
        }
        [HttpDelete]
        public void Delete(int key)
        {
            var inventory = _unitOfWork.Inventoty.GetFirstOrDefault(a => a.InventotyId == key);
            _unitOfWork.Inventoty.Remove(inventory);
            _unitOfWork.Save();
        }
    }
}
