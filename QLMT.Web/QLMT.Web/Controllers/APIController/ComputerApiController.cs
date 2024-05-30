using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QLMT.DataAccess.Repository.IRepository;
using QLMT.Models;

namespace QLMT.Web.Controllers.APIController
{
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

        [HttpGet]
        public object Get()
        {
            DataSourceLoadOptions loadOptions = new DataSourceLoadOptions();

            IEnumerable<Computer> objComputerList = _unitOfWork.Computer.GetAll();

            return DataSourceLoader.Load(objComputerList, loadOptions);
        }

        [HttpPost]
        public IActionResult Insert(string values)
        {
            var newComputer = new Line();
            JsonConvert.PopulateObject(values, newComputer);
            _unitOfWork.Line.Add(newComputer);
            _unitOfWork.Save();

            return Ok(newComputer);
        }
        [HttpPut]
        public IActionResult Update(int id, string values)
        {
            var computer = _unitOfWork.Computer.GetFirstOrDefault(o => o.ComputerId == id);
            JsonConvert.PopulateObject(values, computer);
            _unitOfWork.Computer.Update(computer);
            _unitOfWork.Save();
            return Ok(computer);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var computer = _unitOfWork.Computer.GetFirstOrDefault(o => o.ComputerId == id);
            _unitOfWork.Computer.Remove(computer);
            _unitOfWork.Save();
        }
    }
}
