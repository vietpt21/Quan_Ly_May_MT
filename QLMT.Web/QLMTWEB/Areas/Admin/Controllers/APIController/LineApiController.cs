using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using MessagePack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QLMT.DataAccess.Data;
using QLMT.DataAccess.Repository;
using QLMT.DataAccess.Repository.IRepository;
using QLMT.Models;

namespace QLMTWEB.Areas.Admin.Controllers.APIController
{
    [Route("api/[controller]")]
    public class LineApiController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _db;
        public LineApiController(IUnitOfWork unitOfWork,ApplicationDbContext db)
        {
            _unitOfWork = unitOfWork;
            _db = db;
        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_unitOfWork.Line.GetAll(), loadOptions);
        }
      
        [HttpGet]
        [Route("{LineId:Int}")]
        public IActionResult GetLineById([FromQuery] DataSourceLoadOptions loadOptions, int? LineId)
        {
            try
            {
                if (LineId == null)
                {
                    return BadRequest("LineId must be provided.");
                }

                var line = _unitOfWork.Line.GetFirstOrDefault(x => x.LineId == LineId);

                if (line == null)
                {
                    return NotFound($"Line with LineId {LineId} not found.");
                }

                var result = DataSourceLoader.Load(new List<Line> { line }, loadOptions);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        /*  [HttpPost]
          public IActionResult Post(string values)
          {
              var newLine = new Line();
              JsonConvert.PopulateObject(values, newLine);
              _unitOfWork.Line.Add(newLine);
              _unitOfWork.Save();

              return Ok();
          }*/
        // POST: api/lineApi
        [HttpPost]
        public async Task<ActionResult<Line>> CreateLine([FromBody] Line line)
        {
            /* try
             {
                 if (line == null)
                     return BadRequest("Line is null");

                 var createdLine = await _db.Lines.AddAsync(line);
                 await _db.SaveChangesAsync();

                 return CreatedAtAction(nameof(GetLineById), new { id = line.LineId }, line);
             }
             catch (Exception ex)
             {
                 return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new line record: " + ex.Message);
             }*/
            // Add the new line to the context
            _db.Lines.Add(line);

            // Save changes to the database
            await _db.SaveChangesAsync();

            // Return the newly created line with the generated LineId
            return CreatedAtAction(nameof(GetLineById), new { id = line.LineId }, line);
        }

        /*  [HttpPut]
          [Route("{LineId:Int}")]
          public IActionResult Put(int key, string values)
          {
              var line = _unitOfWork.Line.GetFirstOrDefault(o => o.LineId == key);
              JsonConvert.PopulateObject(values, line);
              _unitOfWork.Save();
              return Ok(line);
          }*/
        // PUT: api/lineApi/{id}
        [HttpPut("{LineId:int}")]
        public async Task<IActionResult> UpdateLine(int LineId, [FromBody] Line line)
        {
            try
            {
                if (LineId != line.LineId)
                {
                    return BadRequest("Line ID mismatch");
                }

                var lineToUpdate = await _db.Lines.FirstOrDefaultAsync(l => l.LineId == LineId);

                if (lineToUpdate == null)
                {
                    return NotFound($"Line with Id = {LineId} not found");
                }

                // Update the existing Line's properties
                lineToUpdate.LineName = line.LineName;
                lineToUpdate.Note = line.Note;

                await _db.SaveChangesAsync();

                return NoContent(); // Optionally, you could return NoContent or Ok with the updated line object
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data: " + ex.Message);
            }
        }


        // DELETE: api/lineApi/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteLine(int id)
        {
            try
            {
                var lineToDelete = await _db.Lines.FindAsync(id);

                if (lineToDelete == null)
                {
                    return NotFound($"Line with Id = {id} not found");
                }

                _db.Lines.Remove(lineToDelete);
                await _db.SaveChangesAsync();

                return Ok($"Line with Id = {id} deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data: " + ex.Message);
            }
        }

        /* [HttpDelete]
         public void Delete(int key)
         {
             var line = _unitOfWork.Line.GetFirstOrDefault(a => a.LineId == key);
             _unitOfWork.Line.Remove(line);
             _unitOfWork.Save();
         }*/
    }

}
