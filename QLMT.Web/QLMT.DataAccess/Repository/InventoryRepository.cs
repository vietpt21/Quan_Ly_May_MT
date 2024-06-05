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
    public class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        private ApplicationDbContext _db;
        public InventoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Inventory obj)
        {
            _db.Inventories.Update(obj);
        }
    }
}
