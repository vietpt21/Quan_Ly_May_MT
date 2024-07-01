using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QLMT.DataAccess.Repository.IRepository;
using QLMT.Models;

namespace QLMTWEB.Areas.Admin.Controllers.APIController
{
    [Route("api/[controller]")]
    public class ScreenApiController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ScreenApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_unitOfWork.Screen.GetAll(), loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            var newScreen = new Screen();
            JsonConvert.PopulateObject(values, newScreen);
            _unitOfWork.Screen.Add(newScreen);
            _unitOfWork.Save();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var newScreen = _unitOfWork.Screen.GetFirstOrDefault(a => a.ScreenId == key);
            JsonConvert.PopulateObject(values, newScreen);
            _unitOfWork.Save();

            return Ok();
        }
        [HttpDelete]
        public void Delete(int key)
        {
            var screen = _unitOfWork.Screen.GetFirstOrDefault(a => a.ScreenId == key);
            _unitOfWork.Screen.Remove(screen);
            _unitOfWork.Save();
        }
    }
}
