using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QLMT.DataAccess.Repository;
using QLMT.DataAccess.Repository.IRepository;
using QLMT.Models;
using System.Text;

namespace QLMT.Web.Controllers.APIController
{
    [Route("api/[controller]")]
    public class ComputerApiController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ComputerApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
       

        /*  [HttpGet]
          public object Get(DataSourceLoadOptions loadOptions)
          {
              return DataSourceLoader.Load(_unitOfWork.Computer.GetAll(), loadOptions);
          }
  */
        [HttpPost]
        public IActionResult Post(string values)
        {
            var newComputer = new Computer();
            JsonConvert.PopulateObject(values, newComputer);
            _unitOfWork.Computer.Add(newComputer);
            _unitOfWork.Save();

            return Ok();
        }
        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var newComputer = _unitOfWork.Computer.GetFirstOrDefault(a => a.ComputerId == key);
            JsonConvert.PopulateObject(values, newComputer);
            _unitOfWork.Save();

            return Ok();
        }

        [HttpDelete]
        public void Delete(int key)
        {
            var computer = _unitOfWork.Computer.GetFirstOrDefault(a => a.ComputerId == key);
            _unitOfWork.Computer.Remove(computer);
            _unitOfWork.Save();
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var data = _unitOfWork.Computer.GetAll();
            return DataSourceLoader.Load(data, loadOptions);
        }
    }
}
