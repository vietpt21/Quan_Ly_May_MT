using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QLMT.DataAccess.Repository.IRepository;
using QLMT.Models;

namespace QLMTWEB.Areas.Admin.Controllers.APIController
{
    [Route("api/[controller]")]
    public class LocationManagementApiController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocationManagementApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_unitOfWork.LocationManagement.GetAll(), loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            var newLocationManagement = new LocationManagement();
            JsonConvert.PopulateObject(values, newLocationManagement);
            _unitOfWork.LocationManagement.Add(newLocationManagement);
            _unitOfWork.Save();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var newLocationManagement = _unitOfWork.LocationManagement.GetFirstOrDefault(a => a.ManagementId == key);
            JsonConvert.PopulateObject(values, newLocationManagement);
            _unitOfWork.Save();

            return Ok();
        }
        [HttpDelete]
        public void Delete(int key)
        {
            var locationManagement = _unitOfWork.LocationManagement.GetFirstOrDefault(a => a.ManagementId == key);
            _unitOfWork.LocationManagement.Remove(locationManagement);
            _unitOfWork.Save();
        }
    }
}
