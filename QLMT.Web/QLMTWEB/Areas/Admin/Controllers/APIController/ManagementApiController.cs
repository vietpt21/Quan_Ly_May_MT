using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QLMT.DataAccess.Data;
using QLMT.DataAccess.Repository.IRepository;
using QLMT.Models;
using System.Xml.Linq;

namespace QLMTWEB.Areas.Admin.Controllers.APIController
{
    [Route("api/[controller]")]
    public class ManagementApiController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IManagementRepository _managementRepository;


        public ManagementApiController(IManagementRepository managementRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _managementRepository = managementRepository;
        }

        /*  [HttpGet]
          public object Get(DataSourceLoadOptions loadOptions)
          {
              return DataSourceLoader.Load(_managementRepository.GetManagementData(), loadOptions);
          }*/
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_unitOfWork.Management.GetAll(), loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            try
            {
                var newManagement = new Management();
                JsonConvert.PopulateObject(values, newManagement);
                // Lấy tên từ các bảng liên quan dựa vào ID

                newManagement.UnitName = _unitOfWork.Unit.GetFirstOrDefault(u => u.UnitId == newManagement.UnitId)?.UnitName;
                newManagement.LineName = _unitOfWork.Line.GetFirstOrDefault(l => l.LineId == newManagement.LineId)?.LineName;
                newManagement.ComputerName = _unitOfWork.Computer.GetFirstOrDefault(c => c.ComputerId == newManagement.ComputerId)?.ComputerName;
                newManagement.RangeName = _unitOfWork.NetworkRange.GetFirstOrDefault(r => r.RangeId == newManagement.RangeId)?.RangeName;
                newManagement.IpAddress = _unitOfWork.NetworkRange.GetFirstOrDefault(r => r.RangeId == newManagement.RangeId)?.IpAddress;
                newManagement.ScreenName = _unitOfWork.Screen.GetFirstOrDefault(s => s.ScreenId == newManagement.ScreenId)?.ScreenName;

                _unitOfWork.Management.Add(newManagement);
                _unitOfWork.Save();

                return Ok(new { newManagement.Id });
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var newManagement = _unitOfWork.Management.GetFirstOrDefault(a => a.Id == key);
            JsonConvert.PopulateObject(values, newManagement);
            newManagement.UnitName = _unitOfWork.Unit.GetFirstOrDefault(u => u.UnitId == newManagement.UnitId)?.UnitName;
            newManagement.LineName = _unitOfWork.Line.GetFirstOrDefault(l => l.LineId == newManagement.LineId)?.LineName;
            newManagement.ComputerName = _unitOfWork.Computer.GetFirstOrDefault(c => c.ComputerId == newManagement.ComputerId)?.ComputerName;
            newManagement.RangeName = _unitOfWork.NetworkRange.GetFirstOrDefault(r => r.RangeId == newManagement.RangeId)?.RangeName;
            newManagement.ScreenName = _unitOfWork.Screen.GetFirstOrDefault(s => s.ScreenId == newManagement.ScreenId)?.ScreenName;
            _unitOfWork.Save();
            return Ok();
        }
        [HttpDelete]
        public void Delete(int key)
        {
            var management = _unitOfWork.Management.GetFirstOrDefault(a => a.Id == key);
            _unitOfWork.Management.Remove(management);
            _unitOfWork.Save();
        }
    }
}
