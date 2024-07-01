using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QLMT.DataAccess.Repository.IRepository;
using QLMT.Models;

namespace QLMTWEB.Areas.Admin.Controllers.APIController
{
    [Route("api/[controller]")]
    public class NetworkRangeApiController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public NetworkRangeApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_unitOfWork.NetworkRange.GetAll(), loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            var newNetwork = new NetworkRange();
            JsonConvert.PopulateObject(values, newNetwork);
            _unitOfWork.NetworkRange.Add(newNetwork);
            _unitOfWork.Save();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var newNetwork = _unitOfWork.NetworkRange.GetFirstOrDefault(a => a.RangeId == key);
            JsonConvert.PopulateObject(values, newNetwork);
            _unitOfWork.Save();

            return Ok();
        }
        [HttpDelete]
        public void Delete(int key)
        {
            var network = _unitOfWork.NetworkRange.GetFirstOrDefault(a => a.RangeId == key);
            _unitOfWork.NetworkRange.Remove(network);
            _unitOfWork.Save();
        }
    }
}
