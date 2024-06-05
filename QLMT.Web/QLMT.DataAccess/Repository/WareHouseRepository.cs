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
    public class WareHouseRepository : Repository<WareHouse>, IWareHouseRepository
    {
        private ApplicationDbContext _db;
        public WareHouseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(WareHouse obj)
        {
            _db.WareHouses.Update(obj);
        }
    }
}
