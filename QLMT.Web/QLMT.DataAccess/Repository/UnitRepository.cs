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
    public class UnitRepository : Repository<Unit>, IUnitRepository
    {
        private ApplicationDbContext _db;
        public UnitRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Unit obj)
        {
            _db.Units.Update(obj);
        }
    }
}
