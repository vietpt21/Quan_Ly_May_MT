using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLMT.DataAccess.Data;
using QLMT.Models;

namespace QLMT.Web.Controllers.APIController
{
    [Route("api/[controller]")]
    public class ManagementApiController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ManagementApiController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Management> Get()
        {
            var query = @"
            SELECT L.LineName, U.UnitName, C.ComputerName, S.ScreenName, NR.RangeName
            FROM LocationManagements lm
            INNER JOIN dbo.Units U ON lm.UnitId = U.UnitId
            INNER JOIN dbo.Lines L ON U.LineId = L.LineId
            INNER JOIN dbo.Computers C ON lm.ComputerId = C.ComputerId
            INNER JOIN dbo.NetworkRanges NR ON lm.RangeId = NR.RangeId
            INNER JOIN dbo.Screens S ON lm.ScreenId = S.ScreenId";

            return _db.Managements.FromSqlRaw(query).ToList();
        }
    }
}
