using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QLMT.DataAccess.Repository.IRepository;
using QLMT.Models;

namespace QLMTWEB.Areas.Admin.Controllers.APIController
{
    [Route("api/[controller]")]
    public class LineApiController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LineApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_unitOfWork.Line.GetAll(), loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            var newLine = new Line();
            JsonConvert.PopulateObject(values, newLine);
            _unitOfWork.Line.Add(newLine);
            _unitOfWork.Save();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var newLine = _unitOfWork.Line.GetFirstOrDefault(a => a.LineId == key);
            JsonConvert.PopulateObject(values, newLine);
            _unitOfWork.Save();

            return Ok();
        }
        [HttpDelete]
        public void Delete(int key)
        {
            var line = _unitOfWork.Line.GetFirstOrDefault(a => a.LineId == key);
            _unitOfWork.Line.Remove(line);
            _unitOfWork.Save();
        }
    }
}
