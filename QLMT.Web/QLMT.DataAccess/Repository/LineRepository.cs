using QLMT.DataAccess.Data;
using QLMT.DataAccess.Repository.IRepository;
using QLMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLMT.DataAccess.Repository
{
    public class LineRepository : Repository<Line>, ILineRepository
    {
        private ApplicationDbContext _db;
        public LineRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Line obj)
        {
            _db.Lines.Update(obj);
        }
    }
}
